using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

using Reloaded.Mod.Interfaces;

using gbfr.qol.weaponCustomizationTool.Configuration;
using gbfr.qol.weaponCustomizationTool.Template;
using gbfrelink.utility.manager.Interfaces;

using GBFRDataTools.Files;
using GBFRDataTools.FlatBuffers;

using FlatSharp;
using GBFRDataTools.Files.BinaryXML;
using System.Xml;

namespace gbfr.qol.weaponCustomizationTool;

/// <summary>
/// Your mod logic goes here.
/// </summary>
public class Mod : ModBase // <= Do not Remove.
{
    /// <summary>
    /// Provides access to the mod loader API.
    /// </summary>
    private readonly IModLoader _modLoader;

    /// <summary>
    /// Provides access to the Reloaded logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Entry point into the mod, instance that created this class.
    /// </summary>
    private readonly IMod _owner;

    /// <summary>
    /// Provides access to this mod's base configuration.
    /// </summary>
    private Config _configuration;
    private readonly CaptainConfig _captain;
    private readonly KatalinaConfig _katalina;
    private readonly RackamConfig _rackam;
    private readonly IoConfig _io;
    private readonly EugenConfig _eugen;
    private readonly RosettaConfig _rosetta;
    private readonly FerryConfig _ferry;
    private readonly LancelotConfig _lancelot;
    private readonly VaneConfig _vane;
    private readonly PercivalConfig _percival;
    private readonly SiegfriedConfig _siegfried;
    private readonly CharlottaConfig _charlotta;
    private readonly YodarhaConfig _yodarha;
    private readonly NarmayaConfig _narmaya;
    private readonly GhandagozaConfig _ghandagoza;
    private readonly ZetaConfig _zeta;
    private readonly VaseragaConfig _vaseraga;
    private readonly CagliostroConfig _cagliostro;
    private readonly IdConfig _id;
    private readonly SandalphonConfig _sandalphon;
    private readonly SeofonConfig _seofon;
    private readonly TweyenConfig _tweyen;

    /// <summary>
    /// The configuration of the currently executing mod.
    /// </summary>
    private readonly IModConfig _modConfig;

    private WeakReference<IDataManager> _dataManagerRef;

    private ObjReadAppend _objRead;

    private ModelInfo _modelInfo;

    private Dictionary<string, byte[]> _originalFiles = new();

    private Dictionary<string, byte[]> _workingFiles = new();

    public Mod(CustomContext context)
    {
        _modLoader = context.ModLoader;
        _logger = context.Logger;
        _owner = context.Owner;
        _configuration = context.Configuration;
        _modConfig = context.ModConfig;
        _captain = context.CaptainModConfig;
        _katalina = context.KatalinaModConfig;
        _rackam = context.RackamModConfig;
        _io = context.IoModConfig;
        _eugen = context.EugenModConfig;
        _rosetta = context.RosettaModConfig;
        _ferry = context.FerryModConfig;
        _lancelot = context.LancelotModConfig;
        _vane = context.VaneModConfig;
        _percival = context.PercivalModConfig;
        _siegfried = context.SiegfriedModConfig;
        _charlotta = context.CharlottaModConfig;
        _yodarha = context.YodarhaModConfig;
        _narmaya = context.NarmayaModConfig;
        _ghandagoza = context.GhandagozaModConfig;
        _zeta = context.ZetaModConfig;
        _vaseraga = context.VaseragaModConfig;
        _cagliostro = context.CagliostroModConfig;
        _id = context.IdModConfig;
        _sandalphon = context.SandalphonModConfig;
        _seofon = context.SeofonModConfig;
        _tweyen = context.TweyenModConfig;

#if DEBUG_DEFAULT || DEBUG_NORESTRICTIONS
        // NOTE (Nenkai): Only works with unpacked exe (use steamless)
        // Ensure that another mod isn't also launching the debugger (use release mode for any other mods)
        Debugger.Launch();
#endif

        _logger.WriteLine($"[{_modConfig.ModId}] Initializing...");
        _dataManagerRef = _modLoader.GetController<IDataManager>();
        if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
            return;

        ApplyConfiguration();
        manager.UpdateIndex();

        _logger.WriteLine($"[{_modConfig.ModId}] Initialized.");
    }

    public void ApplyConfiguration()
    {
        if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
            return;

        Dictionary<uint, uint> modelSwapList = new()
        {
            { (uint)AllWeaponObjId.Captain_Travellers_Sword, (uint)_captain.Swap_TravellersSword                        },
            { (uint)AllWeaponObjId.Captain_Durandal, (uint)_captain.Swap_Durandal                                       },
            { (uint)AllWeaponObjId.Captain_Sword_of_Eos, (uint)_captain.Swap_SwordofEos                                 },
            { (uint)AllWeaponObjId.Captain_Albacore_Blade, (uint)_captain.Swap_AlbacoreBlade                            },
            { (uint)AllWeaponObjId.Captain_Ultima_Sword, (uint)_captain.Swap_UltimaSword                                },
            { (uint)AllWeaponObjId.Captain_Seven_Star_Sword, (uint)_captain.Swap_SevenStarSword                         },
            { (uint)AllWeaponObjId.Captain_Partenza, (uint)_captain.Swap_Partenza                                       },

            { (uint)AllWeaponObjId.Katalina_Rukalsa, (uint)_katalina.Swap_Rukalsa                                       },
            { (uint)AllWeaponObjId.Katalina_Flame_Rapier, (uint)_katalina.Swap_FlameRapier                              },
            { (uint)AllWeaponObjId.Katalina_Murgleis, (uint)_katalina.Swap_Murgleis                                     },
            { (uint)AllWeaponObjId.Katalina_Luminiera_Sword_Omega, (uint)_katalina.Swap_LuminieraSwordOmega             },
            { (uint)AllWeaponObjId.Katalina_Ephemeron, (uint)_katalina.Swap_Ephemeron                                   },
            { (uint)AllWeaponObjId.Katalina_Blutgang, (uint)_katalina.Swap_Blutgang                                     },

            { (uint)AllWeaponObjId.Rackam_Flintspike, (uint)_rackam.Swap_Flintspike                                     },
            { (uint)AllWeaponObjId.Rackam_Wheellock_Axe, (uint)_rackam.Swap_WheellockAxe                                },
            { (uint)AllWeaponObjId.Rackam_Benedia, (uint)_rackam.Swap_Benedia                                           },
            { (uint)AllWeaponObjId.Rackam_Tiamat_Bolt_Omega, (uint)_rackam.Swap_TiamatBoltOmega                         },
            { (uint)AllWeaponObjId.Rackam_Stormcloud, (uint)_rackam.Swap_Stormcloud                                     },
            { (uint)AllWeaponObjId.Rackam_Freikugel, (uint)_rackam.Swap_Freikugel                                       },

            { (uint)AllWeaponObjId.Io_Little_Witch_Scepter, (uint)_io.Swap_LittleWitchScepter                           },
            { (uint)AllWeaponObjId.Io_Zhezl, (uint)_io.Swap_Zhezl                                                       },
            { (uint)AllWeaponObjId.Io_Gambanteinn, (uint)_io.Swap_Gambanteinn                                           },
            { (uint)AllWeaponObjId.Io_Colossus_Cane_Omega, (uint)_io.Swap_ColossusCaneOmega                             },
            { (uint)AllWeaponObjId.Io_Tupsimati, (uint)_io.Swap_Tupsimati                                               },
            { (uint)AllWeaponObjId.Io_Caduceus, (uint)_io.Swap_Caduceus                                                 },

            { (uint)AllWeaponObjId.Eugen_Dreyse, (uint)_eugen.Swap_Dreyse                                               },
            { (uint)AllWeaponObjId.Eugen_Matchlock, (uint)_eugen.Swap_Matchlock                                         },
            { (uint)AllWeaponObjId.Eugen_AK4A, (uint)_eugen.Swap_AK4A                                                   },
            { (uint)AllWeaponObjId.Eugen_Leviathan_Muzzle, (uint)_eugen.Swap_LeviathanMuzzle                            },
            { (uint)AllWeaponObjId.Eugen_Clarion, (uint)_eugen.Swap_Clarion                                             },
            { (uint)AllWeaponObjId.Eugen_Draconic_Fire, (uint)_eugen.Swap_DraconicFire                                  },

            { (uint)AllWeaponObjId.Rosetta_Egoism, (uint)_rosetta.Swap_Egoism                                           },
            { (uint)AllWeaponObjId.Rosetta_Swordbreaker, (uint)_rosetta.Swap_Swordbreaker                               },
            { (uint)AllWeaponObjId.Rosetta_Love_Eternal, (uint)_rosetta.Swap_LoveEternal                                },
            { (uint)AllWeaponObjId.Rosetta_Rose_Crystal_Knife, (uint)_rosetta.Swap_RoseCrystalKnife                     },
            { (uint)AllWeaponObjId.Rosetta_Cortana, (uint)_rosetta.Swap_Cortana                                         },
            { (uint)AllWeaponObjId.Rosetta_Dagger_of_Bahamut_Coda, (uint)_rosetta.Swap_DaggerofBahamutCoda              },

            { (uint)AllWeaponObjId.Ferry_Geisterpeitche, (uint)_ferry.Swap_Geisterpeitche                               },
            { (uint)AllWeaponObjId.Ferry_Leather_Belt, (uint)_ferry.Swap_LeatherBelt                                    },
            { (uint)AllWeaponObjId.Ferry_Ethereal_Lasher, (uint)_ferry.Swap_EtherealLasher                              },
            { (uint)AllWeaponObjId.Ferry_Flame_Lit_Curl, (uint)_ferry.Swap_FlameLitCurl                                 },
            { (uint)AllWeaponObjId.Ferry_Live_Wire, (uint)_ferry.Swap_LiveWire                                          },
            { (uint)AllWeaponObjId.Ferry_Erinnerung, (uint)_ferry.Swap_Erinnerung                                       },

            { (uint)AllWeaponObjId.Lancelot_Altachiara, (uint)_lancelot.Swap_Altachiara                                 },
            { (uint)AllWeaponObjId.Lancelot_Hoarfrost_Blade_Persius, (uint)_lancelot.Swap_HoarfrostBladePersius         },
            { (uint)AllWeaponObjId.Lancelot_Blanc_Comme_Neige, (uint)_lancelot.Swap_BlancCommeNeige                     },
            { (uint)AllWeaponObjId.Lancelot_Vegalta, (uint)_lancelot.Swap_Vegalta                                       },
            { (uint)AllWeaponObjId.Lancelot_Knight_of_Ice, (uint)_lancelot.Swap_KnightOfIce                             },
            { (uint)AllWeaponObjId.Lancelot_Damascus_Knife, (uint)_lancelot.Swap_DamascusKnife                          },

            { (uint)AllWeaponObjId.Vane_Alabarda, (uint)_vane.Swap_Alabarda                                             },
            { (uint)AllWeaponObjId.Vane_Swan, (uint)_vane.Swap_Swan                                                     },
            { (uint)AllWeaponObjId.Vane_Treuer_Krieger, (uint)_vane.Swap_TreuerKrieger                                  },
            { (uint)AllWeaponObjId.Vane_Ukonvasara, (uint)_vane.Swap_Ukonvasara                                         },
            { (uint)AllWeaponObjId.Vane_Blossom_Axe, (uint)_vane.Swap_BlossomAxe                                        },
            { (uint)AllWeaponObjId.Vane_Mjolnir, (uint)_vane.Swap_Mjolnir                                               },

            { (uint)PercivalWeaponObjId.Flamberge, (uint)_percival.Swap_Flamberge                                       },
            { (uint)PercivalWeaponObjId.Lohengrin, (uint)_percival.Swap_Lohengrin                                       },
            { (uint)PercivalWeaponObjId.Antwerp, (uint)_percival.Swap_Antwerp                                           },
            { (uint)PercivalWeaponObjId.Joyeuse, (uint)_percival.Swap_Joyeuse                                           },
            { (uint)PercivalWeaponObjId.Lord_of_Flames, (uint)_percival.Swap_LordOfFlames                               },
            { (uint)PercivalWeaponObjId.Gottfried, (uint)_percival.Swap_Gottfried                                       },

            { (uint)SiegfriedWeaponObjId.Integrity, (uint)_siegfried.Swap_Integrity                                     },
            { (uint)SiegfriedWeaponObjId.Broadsword_of_Earth, (uint)_siegfried.Swap_BroadswordofEarth                   },
            { (uint)SiegfriedWeaponObjId.Ascalon, (uint)_siegfried.Swap_Ascalon                                         },
            { (uint)SiegfriedWeaponObjId.Hrunting, (uint)_siegfried.Swap_Hrunting                                       },
            { (uint)SiegfriedWeaponObjId.Windhose, (uint)_siegfried.Swap_Windhose                                       },
            { (uint)SiegfriedWeaponObjId.Balmung, (uint)_siegfried.Swap_Balmung                                         },

            { (uint)CharlottaWeaponObjId.Claiomh_Solais, (uint)_charlotta.Swap_ClaiomhSolais                            },
            { (uint)CharlottaWeaponObjId.Arondight, (uint)_charlotta.Swap_Arondight                                     },
            { (uint)CharlottaWeaponObjId.Claidheamh_Soluis, (uint)_charlotta.Swap_ClaidheamhSoluis                      },
            { (uint)CharlottaWeaponObjId.Ushumgal, (uint)_charlotta.Swap_Ushumgal                                       },
            { (uint)CharlottaWeaponObjId.Sahrivar, (uint)_charlotta.Swap_Sahrivar                                       },
            { (uint)CharlottaWeaponObjId.Galatine, (uint)_charlotta.Swap_Galatine                                       },

            { (uint)YodarhaWeaponObjId.Kiku_Ichimonji, (uint)_yodarha.Swap_KikuIchimonji                                },
            { (uint)YodarhaWeaponObjId.Asura, (uint)_yodarha.Swap_Asura                                                 },
            { (uint)YodarhaWeaponObjId.Fudo_Kuniyuki, (uint)_yodarha.Swap_FudoKuniyuki                                  },
            { (uint)YodarhaWeaponObjId.Higurashi, (uint)_yodarha.Swap_Higurashi                                         },
            { (uint)YodarhaWeaponObjId.Xeno_Phantom_Demon_Blade, (uint)_yodarha.Swap_XenoPhantomDemonBlade              },
            { (uint)YodarhaWeaponObjId.Swordfish, (uint)_yodarha.Swap_Swordfish                                         },

            { (uint)NarmayaWeaponObjId.Nakamaki_Nodachi, (uint)_narmaya.Swap_NakamakiNodachi                            },
            { (uint)NarmayaWeaponObjId.Kotetsu, (uint)_narmaya.Swap_Kotetsu                                             },
            { (uint)NarmayaWeaponObjId.Venustas, (uint)_narmaya.Swap_Venustas                                           },
            { (uint)NarmayaWeaponObjId.Flourithium_Blade, (uint)_narmaya.Swap_Flourithium_Blade                         },
            { (uint)NarmayaWeaponObjId.Blade_of_Purification, (uint)_narmaya.Swap_BladeofPurification                   },
            { (uint)NarmayaWeaponObjId.Ameno_Habakiri, (uint)_narmaya.Swap_AmenoHabakiri                                },

            { (uint)GhandagozaWeaponObjId.Brahma_Gauntlet, (uint)_ghandagoza.Swap_BrahmaGauntlet                        },
            { (uint)GhandagozaWeaponObjId.Rope_Knuckles, (uint)_ghandagoza.Swap_RopeKnuckles                            },
            { (uint)GhandagozaWeaponObjId.Crimson_Finger, (uint)_ghandagoza.Swap_CrimsonFinger                          },
            { (uint)GhandagozaWeaponObjId.Golden_Fists_of_Ura, (uint)_ghandagoza.Swap_GoldenFistsOfUra                  },
            { (uint)GhandagozaWeaponObjId.Arkab, (uint)_ghandagoza.Swap_Arkab                                           },
            { (uint)GhandagozaWeaponObjId.Sky_Piercer, (uint)_ghandagoza.Swap_SkyPiercer                                },

            { (uint)ZetaWeaponObjId.Spear_of_Arvess, (uint)_zeta.Swap_SpearofArvess                                     },
            { (uint)ZetaWeaponObjId.Sunspot_Spear, (uint)_zeta.Swap_Sunspot_Spear                                       },
            { (uint)ZetaWeaponObjId.Brionac, (uint)_zeta.Swap_Brionac                                                   },
            { (uint)ZetaWeaponObjId.Gisla, (uint)_zeta.Swap_Gisla                                                       },
            { (uint)ZetaWeaponObjId.Huanglong_Spear, (uint)_zeta.Swap_HuanglongSpear                                    },
            { (uint)ZetaWeaponObjId.Gae_Bulg, (uint)_zeta.Swap_GaeBulg                                                  },

            { (uint)VaseragaWeaponObjId.Great_Scythe_Grynoth, (uint)_vaseraga.Swap_GreatScytheGrynoth                   },
            { (uint)VaseragaWeaponObjId.Alsarav, (uint)_vaseraga.Swap_Alsarav                                           },
            { (uint)VaseragaWeaponObjId.Wurtzite_Scythe, (uint)_vaseraga.Swap_WurtziteScythe                            },
            { (uint)VaseragaWeaponObjId.Soul_Eater, (uint)_vaseraga.Swap_SoulEater                                      },
            { (uint)VaseragaWeaponObjId.Cosmic_Scythe, (uint)_vaseraga.Swap_CosmicScythe                                },
            { (uint)VaseragaWeaponObjId.Ereshkigal, (uint)_vaseraga.Swap_Ereshkigal                                     },

            { (uint)CagliostroWeaponObjId.Magnum_Opus, (uint)_cagliostro.Swap_MagnumOpus                                },
            { (uint)CagliostroWeaponObjId.Dream_Atlas, (uint)_cagliostro.Swap_DreamAtlas                                },
            { (uint)CagliostroWeaponObjId.Transmigration_Tome, (uint)_cagliostro.Swap_TransmigrationTome                },
            { (uint)CagliostroWeaponObjId.Sacred_Codex, (uint)_cagliostro.Swap_SacredCodex                              },
            { (uint)CagliostroWeaponObjId.Arshivelle, (uint)_cagliostro.Swap_Arshivelle                                 },
            { (uint)CagliostroWeaponObjId.Zosimos, (uint)_cagliostro.Swap_Zosimos                                       },

            { (uint)IdWeaponObjId.Ragnarok, (uint)_id.Swap_Ragnarok                                                     },
            { (uint)IdWeaponObjId.Aviaeth_Faussart, (uint)_id.Swap_AviaethFaussart                                      },
            { (uint)IdWeaponObjId.Susanoo, (uint)_id.Swap_Susanoo                                                       },
            { (uint)IdWeaponObjId.Premium_Sword, (uint)_id.Swap_PremiumSword                                            },
            { (uint)IdWeaponObjId.Ecke_Sachs, (uint)_id.Swap_EckeSachs                                                  },
            { (uint)IdWeaponObjId.Sword_of_Bahamut, (uint)_id.Swap_SwordofBahamut                                       },

            { (uint)SandalphonWeaponObjId.Apprentice, (uint)_sandalphon.Swap_Apprentice                                 },
            { (uint)SandalphonWeaponObjId.WorldEnder, (uint)_sandalphon.Swap_WorldEnder                                 },

            { (uint)SeofonWeaponObjId.Sette_di_Spade, (uint)_seofon.Swap_SettediSpade                                   },
            { (uint)SeofonWeaponObjId.Gateway_Star_Sword, (uint)_seofon.Swap_GatewayStarSword                           },

            { (uint)TweyenWeaponObjId.Bow_of_Dismissal, (uint)_tweyen.Swap_BowofDismissal                               },
            { (uint)TweyenWeaponObjId.Desolation_Crown_Bow, (uint)_tweyen.Swap_DesolationCrownBow                       },
        };

        Dictionary<uint, uint> effectSwapList = new()
        {
            { (uint)CaptainEffectWeaponObjId.Ascension, (uint)_captain.EffectSwap_SwordOfEos                            },
            { (uint)CaptainEffectWeaponObjId.Terminus, (uint)_captain.EffectSwap_SevenStarSword                         },

            { (uint)KatalinaEffectWeaponObjId.Ascension, (uint)_katalina.EffectSwap_Murgleis                            },
            { (uint)KatalinaEffectWeaponObjId.Terminus, (uint)_katalina.EffectSwap_Blutgang                             },

            { (uint)RackamEffectWeaponObjId.Ascension, (uint)_rackam.EffectSwap_Benedia                                 },
            { (uint)RackamEffectWeaponObjId.Terminus, (uint)_rackam.EffectSwap_Freikugel                                },

            { (uint)IoEffectWeaponObjId.Ascension, (uint)_io.EffectSwap_Gambanteinn                                     },
            { (uint)IoEffectWeaponObjId.Terminus, (uint)_io.EffectSwap_Caduceus                                         },

            { (uint)EugenEffectWeaponObjId.Ascension, (uint)_eugen.EffectSwap_AK4A                                      },
            { (uint)EugenEffectWeaponObjId.Terminus, (uint)_eugen.EffectSwap_DraconicFire                               },

            { (uint)RosettaEffectWeaponObjId.Ascension, (uint)_rosetta.EffectSwap_LoveEternal                           },
            { (uint)RosettaEffectWeaponObjId.Flame, (uint)_rosetta.EffectSwap_Cortana                                   },
            { (uint)RosettaEffectWeaponObjId.Terminus, (uint)_rosetta.EffectSwap_DaggerOfBahamutCoda                    },

            { (uint)FerryEffectWeaponObjId.Ghostly, (uint)_ferry.EffectSwap_Geisterpeitche                              },
            { (uint)FerryEffectWeaponObjId.Ascension, (uint)_ferry.EffectSwap_EtherealLasher                            },
            { (uint)FerryEffectWeaponObjId.Flame, (uint)_ferry.EffectSwap_FlameLitCurl                                  },
            { (uint)FerryEffectWeaponObjId.Electric, (uint)_ferry.EffectSwap_LiveWire                                },
            { (uint)FerryEffectWeaponObjId.Terminus, (uint)_ferry.EffectSwap_Erinnerung                                 },

            { (uint)LancelotEffectWeaponObjId.Ascension, (uint)_lancelot.EffectSwap_KnightOfIce                         },
            { (uint)LancelotEffectWeaponObjId.Terminus, (uint)_lancelot.EffectSwap_DamascusKnife                        },

            { (uint)VaneEffectWeaponObjId.Ascension, (uint)_vane.EffectSwap_TreuerKrieger                               },
            { (uint)VaneEffectWeaponObjId.Terminus, (uint)_vane.EffectSwap_Mjolnir                                      },

            { (uint)PercivalEffectWeaponObjId.Ascension, (uint)_percival.EffectSwap_LordOfFlames                        },
            { (uint)PercivalEffectWeaponObjId.Terminus, (uint)_percival.EffectSwap_Gottfried                            },

            { (uint)SiegfriedEffectWeaponObjId.Ascension, (uint)_siegfried.EffectSwap_Ascalon                           },
            { (uint)SiegfriedEffectWeaponObjId.Terminus, (uint)_siegfried.EffectSwap_Balmung                            },

            { (uint)CharlottaEffectWeaponObjId.Ascension, (uint)_charlotta.EffectSwap_Claidheamh                        },
            { (uint)CharlottaEffectWeaponObjId.Terminus, (uint)_charlotta.EffectSwap_Galatine                           },

            { (uint)YodarhaEffectWeaponObjId.Ascension, (uint)_yodarha.EffectSwap_FudoKuniyuki                          },
            { (uint)YodarhaEffectWeaponObjId.Terminus, (uint)_yodarha.EffectSwap_Swordfish                              },

            { (uint)NarmayaEffectWeaponObjId.Ascension, (uint)_narmaya.EffectSwap_Venustas                              },
            { (uint)NarmayaEffectWeaponObjId.Terminus, (uint)_narmaya.EffectSwap_AmenoHabakiri                          },

            { (uint)GhandagozaEffectWeaponObjId.Ascension, (uint)_ghandagoza.EffectSwap_GoldenFistsOfUra                },
            { (uint)GhandagozaEffectWeaponObjId.Terminus, (uint)_ghandagoza.EffectSwap_SkyPiercer                       },

            { (uint)ZetaEffectWeaponObjId.Ascension, (uint)_zeta.EffectSwap_Brionac                                     },
            { (uint)ZetaEffectWeaponObjId.Terminus, (uint)_zeta.EffectSwap_GaeBulg                                      },

            { (uint)VaseragaEffectWeaponObjId.Ascension, (uint)_vaseraga.EffectSwap_WurtziteScythe                      },
            { (uint)VaseragaEffectWeaponObjId.Terminus, (uint)_vaseraga.EffectSwap_Ereshkigal                           },

            { (uint)CagliostroEffectWeaponObjId.Ascension, (uint)_cagliostro.EffectSwap_TransmigrationTome              },
            { (uint)CagliostroEffectWeaponObjId.Terminus, (uint)_cagliostro.EffectSwap_Zosimos                          },

            { (uint)IdEffectWeaponObjId.Ascension, (uint)_id.EffectSwap_Susanoo                                         },
            { (uint)IdEffectWeaponObjId.Terminus, (uint)_id.EffectSwap_PrimalSwordOfBahamut                             },

            // Intentionally no Sandalphon, Seofon, or Tweyen since they only have 1 effect each
        };

        string infoFile = "system/objread/info.objread";
        if (!manager.FileExists(infoFile, includeExternal: false))
            return;

        byte[] fileBytes = manager.GetArchiveFile(infoFile);
        _objRead = ObjReadAppend.Serializer.Parse(fileBytes);

        foreach (var weapon in effectSwapList)  // Must come before ProcessModels to ensure effect swapping works correctly
            ProcessEffectSwap(weapon.Key, weapon.Value);

        foreach (var weapon in modelSwapList)
            ProcessModels(weapon.Key, weapon.Value);

        byte[] outputBuffer = new byte[ObjReadAppend.Serializer.GetMaxSize(_objRead)];
        int length = ObjReadAppend.Serializer.Write(outputBuffer, _objRead);

        manager.AddOrUpdateExternalFile(infoFile,
            outputBuffer.AsSpan(0, length).ToArray());

        ///----------------------------------------------------------------------------///

        Dictionary<string, WeaponEffectControlType> effectControlList = new() // Dynamic because some of Ferry's weapons + 1 of Rosetta's weapons use bool instead of WeaponEffectControlType
        {
            { ObjIdToModelId((uint)CaptainEffectWeaponObjId.Ascension), _captain.EffectControl_SwordOfEos               },
            { ObjIdToModelId((uint)CaptainEffectWeaponObjId.Terminus), _captain.EffectControl_SevenStarSword            },

            { ObjIdToModelId((uint)KatalinaEffectWeaponObjId.Ascension), _katalina.EffectControl_Murgleis               },
            { ObjIdToModelId((uint) KatalinaEffectWeaponObjId.Terminus), _katalina.EffectControl_Blutgang               },

            { ObjIdToModelId((uint) RackamEffectWeaponObjId.Ascension), _rackam.EffectControl_Benedia                   },
            { ObjIdToModelId((uint) RackamEffectWeaponObjId.Terminus), _rackam.EffectControl_Freikugel                  },

            { ObjIdToModelId((uint) IoEffectWeaponObjId.Ascension), _io.EffectControl_Gambanteinn                       },
            { ObjIdToModelId((uint) IoEffectWeaponObjId.Terminus), _io.EffectControl_Caduceus                           },

            { ObjIdToModelId((uint) EugenEffectWeaponObjId.Ascension), _eugen.EffectControl_AK4A                        },
            { ObjIdToModelId((uint) EugenEffectWeaponObjId.Terminus), _eugen.EffectControl_DraconicFire                 },

            { ObjIdToModelId((uint) RosettaEffectWeaponObjId.Ascension), _rosetta.EffectControl_LoveEternal                         },
            { ObjIdToModelId((uint) RosettaEffectWeaponObjId.Flame), (WeaponEffectControlType)_rosetta.EffectControl_Cortana        },
            { ObjIdToModelId((uint) RosettaEffectWeaponObjId.Terminus), _rosetta.EffectControl_DaggerOfBahamutCoda                  },

            { ObjIdToModelId((uint) FerryEffectWeaponObjId.Ghostly), (WeaponEffectControlType)_ferry.EffectControl_Geisterpeitche   },
            { ObjIdToModelId((uint) FerryEffectWeaponObjId.Ascension), _ferry.EffectControl_EtherealLasher                          },
            { ObjIdToModelId((uint) FerryEffectWeaponObjId.Flame), (WeaponEffectControlType)_ferry.EffectControl_FlameLitCurl       },
            { ObjIdToModelId((uint) FerryEffectWeaponObjId.Electric), (WeaponEffectControlType)_ferry.EffectControl_LiveWire     },
            { ObjIdToModelId((uint) FerryEffectWeaponObjId.Terminus), _ferry.EffectControl_Erinnerung                               },

            { ObjIdToModelId((uint) LancelotEffectWeaponObjId.Ascension), _lancelot.EffectControl_KnightOfIce           },
            { ObjIdToModelId((uint) LancelotEffectWeaponObjId.Terminus), _lancelot.EffectControl_DamascusKnife          },

            { ObjIdToModelId((uint) VaneEffectWeaponObjId.Ascension), _vane.EffectControl_TreuerKrieger                 },
            { ObjIdToModelId((uint) VaneEffectWeaponObjId.Terminus), _vane.EffectControl_Mjolnir                        },

            { ObjIdToModelId((uint) PercivalEffectWeaponObjId.Ascension), _percival.EffectControl_LordOfFlames          },
            { ObjIdToModelId((uint) PercivalEffectWeaponObjId.Terminus), _percival.EffectControl_Gottfried              },

            { ObjIdToModelId((uint) SiegfriedEffectWeaponObjId.Ascension), _siegfried.EffectControl_Ascalon             },
            { ObjIdToModelId((uint) SiegfriedEffectWeaponObjId.Terminus), _siegfried.EffectControl_Balmung              },

            { ObjIdToModelId((uint) CharlottaEffectWeaponObjId.Ascension), _charlotta.EffectControl_Claidheamh          },
            { ObjIdToModelId((uint) CharlottaEffectWeaponObjId.Terminus), _charlotta.EffectControl_Galatine             },

            { ObjIdToModelId((uint) YodarhaEffectWeaponObjId.Ascension), _yodarha.EffectControl_FudoKuniyuki            },
            { ObjIdToModelId((uint) YodarhaEffectWeaponObjId.Terminus), _yodarha.EffectControl_Swordfish                },

            { ObjIdToModelId((uint) NarmayaEffectWeaponObjId.Ascension), _narmaya.EffectControl_Venustas                },
            { ObjIdToModelId((uint) NarmayaEffectWeaponObjId.Terminus), _narmaya.EffectControl_AmenoHabakiri            },

            { ObjIdToModelId((uint) GhandagozaEffectWeaponObjId.Ascension), _ghandagoza.EffectControl_GoldenFistsOfUra  },
            { ObjIdToModelId((uint) GhandagozaEffectWeaponObjId.Terminus), _ghandagoza.EffectControl_SkyPiercer         },

            { ObjIdToModelId((uint) ZetaEffectWeaponObjId.Ascension), _zeta.EffectControl_Brionac                       },
            { ObjIdToModelId((uint) ZetaEffectWeaponObjId.Terminus), _zeta.EffectControl_GaeBulg                        },

            { ObjIdToModelId((uint) VaseragaEffectWeaponObjId.Ascension), _vaseraga.EffectControl_WurtziteScythe        },
            { ObjIdToModelId((uint) VaseragaEffectWeaponObjId.Terminus), _vaseraga.EffectControl_Ereshkigal             },

            { ObjIdToModelId((uint) CagliostroEffectWeaponObjId.Ascension), _cagliostro.EffectControl_TransmigrationTome},
            { ObjIdToModelId((uint) CagliostroEffectWeaponObjId.Terminus), _cagliostro.EffectControl_Zosimos            },

            { ObjIdToModelId((uint) IdEffectWeaponObjId.Ascension), _id.EffectControl_Susanoo                           },
            { ObjIdToModelId((uint) IdEffectWeaponObjId.Terminus), _id.EffectControl_PrimalSwordOfBahamut               },

            { ObjIdToModelId((uint) SandalphonEffectWeaponObjId.Terminus), _sandalphon.EffectControl_WorldEnder         },

            { ObjIdToModelId((uint) SeofonEffectWeaponObjId.Terminus), _seofon.EffectControl_GatewayStarSword           },

            { ObjIdToModelId((uint) TweyenEffectWeaponObjId.Terminus), _tweyen.EffectControl_DesolationCrownBow         },
        };

        foreach (var weapon in effectControlList)
            ProcessEffectControl(weapon.Key, weapon.Value);

        ///----------------------------------------------------------------------------///

        Dictionary<uint, uint> captainIdList = new()
        {
            { (uint)AllWeaponObjId.Captain_Durandal, (uint)_captain.Swap_Durandal                               },
            { (uint)AllWeaponObjId.Captain_Sword_of_Eos, (uint)_captain.Swap_SwordofEos                         },
            { (uint)AllWeaponObjId.Captain_Albacore_Blade, (uint)_captain.Swap_AlbacoreBlade                    },
            { (uint)AllWeaponObjId.Captain_Ultima_Sword, (uint)_captain.Swap_UltimaSword                        },
            { (uint)AllWeaponObjId.Captain_Seven_Star_Sword, (uint)_captain.Swap_SevenStarSword                 },
            { (uint)AllWeaponObjId.Captain_Partenza, (uint)_captain.Swap_Partenza                               },
        };

        Dictionary<uint, uint> narmayaIdList = new()
        {
            { (uint)NarmayaWeaponObjId.Nakamaki_Nodachi, (uint)_narmaya.Swap_NakamakiNodachi                    },
            { (uint)NarmayaWeaponObjId.Kotetsu, (uint)_narmaya.Swap_Kotetsu                                     },
            { (uint)NarmayaWeaponObjId.Venustas, (uint)_narmaya.Swap_Venustas                                   },
            { (uint)NarmayaWeaponObjId.Flourithium_Blade, (uint)_narmaya.Swap_Flourithium_Blade                 },
            { (uint)NarmayaWeaponObjId.Blade_of_Purification, (uint)_narmaya.Swap_BladeofPurification           },
            { (uint)NarmayaWeaponObjId.Ameno_Habakiri, (uint)_narmaya.Swap_AmenoHabakiri                        },
        };


        foreach (var elem in captainIdList)
        {
            if (elem.Key != elem.Value && (_captain.SheathSwapToggle == true && ObjIdToCharacterId(elem.Value) == "0000"))
            {
                ProcessSheaths(captainIdList, "0101");
                break;
            }
        }

        foreach (var elem in narmayaIdList)
        {
            if (elem.Key != elem.Value && _narmaya.SheathSwapToggle == true && ObjIdToCharacterId(elem.Key) == "1400")
            {
                ProcessSheaths(narmayaIdList, "1400");
                break;
            }
        }
    }

    public void ProcessEffectSwap(uint sourceHex, uint targetHex)
    {
        if (targetHex == sourceHex) // If no change
            return;

        try
        {
            var sourceResult = _objRead.Entries.FirstOrDefault(e => e.SearchObjidKey == sourceHex);

            if (sourceResult is null)
            {
                _logger.WriteLine($"Can't find {ObjIdToModelId(sourceHex)} in info.objread to swap effects. Either doesn't have an effect or something broke.");
                return;
            }

            _logger.WriteLine($"Swapping {ObjIdToModelId(sourceHex)} effect with {ObjIdToModelId(targetHex)}");

            sourceResult.EffectsObjid = targetHex;

            if (Enum.IsDefined(typeof(FerryWeaponObjId), sourceHex)
                && Enum.IsDefined(typeof(FerryWeaponObjId), targetHex)) // If both weapons are from Ferry
            {
                ProcessCallSelector(ObjIdToModelId(sourceHex), ObjIdToModelId(targetHex));
            }

        }
        catch (Exception ex)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] Failed to apply {ObjIdToModelId(sourceHex)} effect swap to {ObjIdToModelId(targetHex)} - {ex.Message}");
        }
    }

    public void ProcessModels(uint sourceHex, uint targetHex)
    {
        if (targetHex == sourceHex)
            return;

        try
        {
            var sourceResult = _objRead.Entries.FirstOrDefault(e => e.SearchObjidKey == sourceHex);

            if (sourceResult is null)
            {
                _logger.WriteLine($"Replacing {ObjIdToModelId(sourceHex)} with {ObjIdToModelId(targetHex)}. No entry found, making new entry.");

                sourceResult = NewInfo(sourceHex);

#if DEBUG_DEFAULT || DEBUG_NORESTRICTIONS
                _logger.WriteLine($"{sourceResult.SearchObjidKey}");
#endif
            }
            else
            {
                _logger.WriteLine($"Replacing {ObjIdToModelId(sourceHex)} with {ObjIdToModelId(targetHex)}");
            }

            if (HasEffect(sourceHex) && !HasEffect(targetHex) && _configuration.ToggleEffectPreservation == true) // Effect preservation
            {
                var targetResult = _objRead.Entries.FirstOrDefault(e => e.SearchObjidKey == targetHex);

                var sourceEffect = sourceResult.EffectsObjid;

                _logger.WriteLine($"Preserving {ObjIdToModelId(sourceHex)} effect, writing to {ObjIdToModelId(targetHex)}.");

                if (targetResult is null)
                {
                    targetResult = NewInfo(targetHex);
                    _logger.WriteLine($"No {ObjIdToModelId(targetHex)} entry found, making new entry.");
                }
                
                targetResult.EffectsObjid = sourceEffect; // Does it this way instead of sourceHex to preserve Effect Swap changes
            }

            if (Enum.IsDefined(typeof(FerryWeaponObjId), sourceHex) && Enum.IsDefined(typeof(FerryWeaponObjId), targetHex)) // If both weapons are from Ferry
            {
                ProcessCallSelector(ObjIdToModelId(sourceHex), ObjIdToModelId(targetHex));
            }

            sourceResult.ModelObjid = targetHex;
            sourceResult.PhysicsObjid = targetHex;
            sourceResult.UnkObjid8 = targetHex;
        }
        catch (Exception ex)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] Failed to apply {ObjIdToModelId(sourceHex)} model patch - {ex.Message}");
        }
    }

    public void ProcessEffectControl(string sourceName, WeaponEffectControlType controlType)
    {
        if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
            return;

        if (controlType == WeaponEffectControlType.Enabled)
            return;

        string effectFile = $"effect/{sourceName}.bxm";

        if (!manager.FileExists(effectFile, includeExternal: false) && !_originalFiles.TryGetValue(effectFile, out _)) // Exits if file doesn't exist in archive or backup
        {
            _logger.WriteLine($"Couldn't fine {effectFile}");
            return;
        }

        try
        {
            byte[] file = (manager.FileExists(effectFile, includeExternal: false)) ? manager.GetArchiveFile(effectFile) : _originalFiles[effectFile]; // If file exists in archive use it, else use backup

            using var ms = new MemoryStream(file);
            XmlDocument xmlDoc = XmlBin.Read(ms);
            if (controlType == WeaponEffectControlType.Disabled)
                xmlDoc["root"]["est"].RemoveAll();
            else
            {
                bool found = false;
                var est = xmlDoc["root"]["est"];
                foreach (XmlNode node in est.ChildNodes)
                {
                    if (node.Name == "data")
                    {
                        foreach (XmlAttribute attr in node.Attributes)
                        {
                            if ((controlType == WeaponEffectControlType.IdleOnly && (attr.Value == "2010" || attr.Value == "2110")) ||
                                (controlType == WeaponEffectControlType.CombatOnly && (attr.Value == "2020" || attr.Value == "2120")))
                            {
                                est.RemoveChild(node);
                                found = true;
                                break;
                            }
                        }

                        if (found)
                            break;
                    }
                }
            }

            using var outputXmlStream = new MemoryStream();
            XmlBin.Write(outputXmlStream, xmlDoc);

            if (!_originalFiles.TryGetValue(effectFile, out _)) // Backs up the file in memory
            {
                byte[] sourceBytes = manager.GetArchiveFile(effectFile);
                _originalFiles.Add(effectFile, sourceBytes);
            }

            manager.AddOrUpdateExternalFile(effectFile, outputXmlStream.ToArray());
        }
        catch (Exception ex)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] Failed to apply {sourceName} effect patch - {ex.Message}");
        }
    }

    public void ProcessSheaths(Dictionary<uint, uint> idList, string characterId)
    {
        if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
            return;

        int skipCount = 0;
        foreach (var elem in idList)
        {
            if ((characterId == "1400" && ObjIdToCharacterId(elem.Value) != "1400") || (characterId == "0101" && ObjIdToCharacterId(elem.Value) != "0000") || elem.Key == elem.Value)
            {
                skipCount++;
            }
        }
        if (skipCount == idList.Count) // Skips the whole method if all the values are matching and/or other characters' weapons
        {
            return;
        }

        _logger.WriteLine($"Swapping sheaths for {(characterId == "0101" ? "Djeeta" : "Narmaya")}");

        string characterMInfo;

        if (characterId == "1400" || characterId == "0101")
        {
            characterMInfo = $"model/pl/pl{characterId}/pl{characterId}.minfo";
        }
        else
        {
            _logger.WriteLine($"Character {characterId} does not have a swappable sheath, this method should not have been called.");
            return;
        }

        if (!manager.FileExists(characterMInfo, includeExternal: false))
        {
            _logger.WriteLine($"\nCan't find {characterMInfo}, skipping sheath swap.\nIf the character model has been modified by another mod the sheath can not be changed.\n");
            return;
        }

        byte[] fileBytes = manager.GetArchiveFile(characterMInfo);
        _modelInfo = ModelInfo.Serializer.Parse(fileBytes);
        var modelInfoBackup = ModelInfo.Serializer.Parse(fileBytes);

        foreach (var elem in idList)
        {
            if ((characterId == "1400" && ObjIdToCharacterId(elem.Value) != "1400") || (characterId == "0101" && ObjIdToCharacterId(elem.Value) != "0000") || elem.Key == elem.Value) // Skip if config is set to another character's weapon or the same
            {
                continue;
            }

            string sourceSheath = ObjIdToSheathId(elem.Key);
            string targetSheath = ObjIdToSheathId(elem.Value);

            _logger.WriteLine($"Changing {sourceSheath} to {targetSheath}");

            if (characterId == "1400")
            {
                Dictionary<string, int> subMeshNumber = new()
                {
                    { "a50_sheath", 0 },
                    { "a40_sheath", 1 },
                    { "a30_sheath", 2 },
                    { "a20_sheath", 3 },
                    { "a10_sheath", 4 },
                    { "a00_sheath", 5 },
                };

                List<int> sourceLodIndices = new();
                List<int> targetLodIndices = new();

                for (int i = 0; i < modelInfoBackup.Lods.Count; i++)
                {
                    for (int j = 0; j < modelInfoBackup.Lods[i].Chunks.Count; j++)
                    {
                        if (modelInfoBackup.Lods[i].Chunks[j].SubMeshId == subMeshNumber[sourceSheath])
                        {
                            sourceLodIndices.Add(j);
                            break;
                        }
                    }

                    for (int j = 0; j < modelInfoBackup.Lods[i].Chunks.Count; j++)
                    {
                        if (modelInfoBackup.Lods[i].Chunks[j].SubMeshId == subMeshNumber[targetSheath])
                        {
                            targetLodIndices.Add(j);
                            break;
                        }
                    }
                }

                if (sourceLodIndices.Count != targetLodIndices.Count)
                {
                    _logger.WriteLine($"{sourceSheath} indices mismatch, exiting ProcessSheaths");
                    return;
                }

                for (int i = 0; i < _modelInfo.Lods.Count; i++)
                {
                    for (int j = 0; j < sourceLodIndices.Count; j++)
                    {
                        var sourceLodData = _modelInfo.Lods[i].Chunks[sourceLodIndices[j]];
                        var targetLodData = modelInfoBackup.Lods[i].Chunks[targetLodIndices[j]];

                        sourceLodData.MaterialId = targetLodData.MaterialId;
                    }
                }
            }

            int sourceIndex = -1;
            int targetIndex = -1;

            for (int i = 0; i < modelInfoBackup.SubMeshes.Count; i++)
            {
                if (modelInfoBackup.SubMeshes[i].Name == sourceSheath)
                {
                    sourceIndex = i;
                    break;
                }
            }

            for (int i = 0; i < modelInfoBackup.SubMeshes.Count; i++)
            {
                if (modelInfoBackup.SubMeshes[i].Name == targetSheath)
                {
                    targetIndex = i;
                    break;
                }
            }

            var sourceData = _modelInfo.SubMeshes[sourceIndex];
            var targetData = modelInfoBackup.SubMeshes[targetIndex];

            string sourceDataName;
            BoundaryBox sourceDataBbox;

            if ((characterId == "0101" && _captain.SheathSwapToggle == true) || elem.Key == (uint)CaptainWeaponObjId.Partenza)
            {
                sourceData.Name = targetData.Name;
                sourceData.Bbox = targetData.Bbox;
            }
            else if (characterId == "1400")
            {
                sourceDataName = sourceData.Name;
                sourceDataBbox = sourceData.Bbox;

                sourceData.Name = targetData.Name;
                sourceData.Bbox = targetData.Bbox;
                _modelInfo.SubMeshes[targetIndex].Name = sourceDataName;
                _modelInfo.SubMeshes[targetIndex].Bbox = sourceDataBbox;
            }
        }

        byte[] outputBuffer = new byte[ModelInfo.Serializer.GetMaxSize(_modelInfo)];
        int length = ModelInfo.Serializer.Write(outputBuffer, _modelInfo);

        manager.AddOrUpdateExternalFile(characterMInfo,
            outputBuffer.AsSpan(0, length).ToArray());
    }

    public void ProcessCallSelector(string sourceName, string targetName) // callselector.bxm also includes data for Sandalphon and Seofon, unsure what that data is for
    {
        if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
        {
            _logger.WriteLine($"Can't find manager to replace Ferry attack effects.");
            return;
        }

        string effectFile = $"effect/callselector.bxm";

        if (!manager.FileExists(effectFile, includeExternal: false) && !_workingFiles.TryGetValue(effectFile, out _)) // Exits if file doesn't exist in archive or backup
        {
            _logger.WriteLine($"Couldn't fine {effectFile}");
            return;
        }

        try
        {
            byte[] file = (manager.FileExists(effectFile, includeExternal: false)) ? manager.GetArchiveFile(effectFile) : _workingFiles[effectFile]; // If file exists in archive use it, else use backup

            using var ms = new MemoryStream(file);
            XmlDocument xmlDoc = XmlBin.Read(ms);

            char targetSuffix;

            if (WeaponEffects.FerryCallSelectorSuffixes().ContainsKey(targetName))
            {
                targetSuffix = WeaponEffects.FerryCallSelectorSuffixes()[targetName];
            }
            else // Add Seofon and Sandalphon here eventually if necessary
            {
                _logger.WriteLine("Something went wrong with ProcessCallSelector, no matching key for target in dictionary");
                return;
            }

            var root = xmlDoc["root"];
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Attributes["ObjId"].Value.Equals(sourceName, StringComparison.OrdinalIgnoreCase))
                {
                    string baseString = node.Attributes["EstId"].Value[..^1]; // Source string without the last character
                    char sourceSuffix = node.Attributes["EstId"].Value[^1]; // Last character of source string

                    if (sourceSuffix != targetSuffix)
                    {
#if DEBUG_DEFAULT || DEBUG_NORESTRICTIONS
                        _logger.WriteLine($"Replacing {node.Attributes["ObjId"].Value} node's EstId {node.Attributes["EstId"].Value} with {baseString}{targetSuffix}");
#endif

                        node.Attributes["EstId"].Value = $"{baseString}{targetSuffix}";

                        continue;
                    }
                }
            }

            using var outputXmlStream = new MemoryStream();
            XmlBin.Write(outputXmlStream, xmlDoc);

            if (!_workingFiles.TryGetValue(effectFile, out _)) // Backs up the edited file in memory, so future passes can preserve edits
            {
                _workingFiles.Add(effectFile, outputXmlStream.ToArray());
            }
            else
            {
                _workingFiles[effectFile] = outputXmlStream.ToArray();
            }

            manager.AddOrUpdateExternalFile(effectFile, outputXmlStream.ToArray());
        }
        catch (Exception ex)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] Failed to apply {sourceName} effect patch - {ex.Message}");
        }
    }

    //public void ProcessFiles(List<string> sourcePaths, List<string> targetPaths)
    //{
    //    if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
    //        return;

    //    for (int i = 0; i < targetPaths.Count; i++)
    //    {
    //        if (manager.FileExists(targetPaths[i], includeExternal: false))
    //        {
    //            byte[] targetFile = manager.GetArchiveFile(targetPaths[i]);
    //            byte[] sourceBytes;

    //            // Store the source if it exists
    //            if (manager.FileExists(sourcePaths[i], includeExternal: false))
    //            {
    //                sourceBytes = manager.GetArchiveFile(sourcePaths[i]);
    //                _originalFiles.Add(sourcePaths[i], sourceBytes);
    //            }

    //            manager.AddOrUpdateExternalFile(sourcePaths[i], targetFile);
    //        }
    //        else if (_originalFiles.TryGetValue(targetPaths[i], out byte[] byteData))
    //        {
    //            manager.AddOrUpdateExternalFile(sourcePaths[i], byteData);
    //        }
    //        else
    //        {
    //            _logger.WriteLine($"{targetPaths[i]} not found");
    //            return;
    //        }
    //    }
    //}

    public Info NewInfo(uint objId)
    {
        uint hexAlt = objId & 0xFFFFFF00;

        Info newInfo = new()
        {
            SearchObjidKey = objId,
            UnkObjid2 = hexAlt,
            ModelObjid = objId,
            EffectsObjid = objId,
            UnkObjid6 = hexAlt,
            PhysicsObjid = objId,
            UnkObjid8 = objId       // Unsure what this one does
        };

        _objRead.Entries.Add(newInfo);

        return newInfo;
    }

    static bool HasEffect(uint objId)
    {
        return WeaponEffects.AllGlowWeapons().Contains(ObjIdToModelId(objId));
    }

    static string ObjIdToModelId(uint objId)
    {
        uint category = objId >> 16;
        uint modelId = objId & 0xFFFF;

        return category switch
        {
            0x01 => $"pl{modelId:X4}",
            0x02 => $"em{modelId:X4}",
            0x03 => $"wp{modelId:X4}",
            0x04 => $"et{modelId:X4}",
            0x05 => $"ef{modelId:X4}",
            0x07 => $"it{modelId:X4}",
            0x09 => $"sc{modelId:X4}",
            0x0C => $"bg{modelId:X4}",
            0x0E => $"bh{modelId:X4}",
            0x0F => $"ba{modelId:X4}",
            0x100 => $"fp{modelId:X4}",
            0x101 => $"fe{modelId:X4}",
            0x102 => $"fn{modelId:X4}",
            0x103 => $"we{modelId:X4}",
            0x104 => $"wn{modelId:X4}",
            0x10A => $"np{modelId:X4}",
            0x10B => $"tr{modelId:X4}",
            0x10C => $"bt{modelId:X4}",
            _ => throw new ArgumentException($"Invalid object id category {category}", nameof(objId))
        };
    }

    static string ObjIdToSheathId(uint objId) // Skips Katalina, Gran+Djeeta rebelwear, Gran default, Rosetta, and Yodarha because hiding sheaths is hardcoded into the executable
    {
        /// Weapons that Disable Sheaths
        /// 
        /// Character       | Weapons
        /// ~~~~~~~~~~~~~~~~|~~~~~~~~~~~
        /// Captain Default | Albacore Blade
        /// Captain Rebel   | Albacore Blade
        /// Katalina        | Flame Rapier, Murgleis, Luminiera Sword Omega, Ephermeron, Blutgang
        /// Rosetta         | Love Eternal
        /// Yodarha         | Asura, Fudo-Kuniyuki, Xeno Phantom Demon Blade, Swordfish
        ///

        /// Weapons that Share Sheaths
        /// 
        /// Character               | Weapons
        /// ~~~~~~~~~~~~~~~~~~~~~~~~|~~~~~~~~~~~
        /// Captain Default Thin    | Partenza 
        /// Captain Default Thick   | Traveller's Sword, Durandal, Sword of Eos, Ultima Sword, Seven-Star Sword
        /// Captain Rebel           | Traveller's Sword, Durandal, Sword of Eos, Ultima Sword, Seven-Star Sword, Partenza
        /// Rosetta                 | Egoism, Swordbreaker, Rose Crystal Knife, Cortana, Dagger of Bahamut Coda
        /// Yodarha                 | Kiku-Ichimonji, Higurashi
        /// 

        string characterId = ObjIdToCharacterId(objId);
        char sheathPrefix;
        string sheathId;

        if (characterId == "0000") // Djeeta, only messing with the default outfit but not rebelwear or any of Gran since they have a single large sheath each
        {
            sheathPrefix = 'b';

            if (objId == (uint)CaptainWeaponObjId.Partenza)
            {
                sheathId = $"{sheathPrefix}00_sheath";
            }
            else
            {
                sheathId = $"{sheathPrefix}10_sheath";
            }
        }
        else if (characterId == "1400") // Narmaya
        {
            sheathPrefix = 'a';
            char modelId = $"{(objId & 0xFFFF):X4}"[^1]; // Grabs last number

            sheathId = $"{sheathPrefix}{modelId}0_sheath";
        }
        else
        {
            throw new ArgumentException($"Character {characterId} does not have a swappable sheath, this method should not have been called");
        }

        return sheathId;
    }

    static string ObjIdToCharacterId(uint objId)
    {
        string characterId;
        if (objId == (uint)CaptainWeaponObjId.Partenza) // Converts Partenza to 0000 so it can be grouped with other Captain weapons
            characterId = $"{(objId & 0x0000):X4}";
        else
            characterId = $"{(objId & 0xFF00):X4}";

        return characterId;
    }

    //static List<string> ObjIdToModelPaths(string modelId)
    //{
    //    string category = modelId[..2];

    //    List<string> paths = new();

    //    List<string> filePathFormats = new()
    //    {
    //        "model/{0}/{1}/{1}.minfo",
    //        "model/{0}/{1}/{1}.skeleton",
    //        "model/{0}/{1}/vars/0.mmat",
    //        "model_streaming/lod0/{1}.mmesh",
    //        "model_streaming/lod1/{1}.mmesh",
    //        "model_streaming/lod2/{1}.mmesh",
    //        "model_streaming/lod3/{1}.mmesh",
    //        "model_streaming/shadow_lod0/{0}.mmesh", //Not used by weapons
    //        "model_streaming/shadow_lod1/{0}.mmesh", //Not used by weapons
    //        "model_streaming/shadow_lod2/{0}.mmesh", //Not used by weapons
    //    };

    //    foreach (var format in filePathFormats)
    //    {
    //        paths.Add(string.Format(format, category, modelId));
    //    }

    //    return paths;
    //}

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        _configuration = configuration;
        _logger.WriteLine($"[{_modConfig.ModId}] {nameof(Config)} Updated: Applying");
    }

    #region Character Specific ConfigurationUpdated
    //public override void ConfigurationUpdated(CaptainConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _captain = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(CaptainConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(KatalinaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _katalina = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(KatalinaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(RackamConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _rackam = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(RackamConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(IoConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _io = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(IoConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(EugenConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _eugen = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(EugenConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(RosettaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _rosetta = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(RosettaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(FerryConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _ferry = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(FerryConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(LancelotConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _lancelot = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(LancelotConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(VaneConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _vane = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(VaneConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(PercivalConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _percival = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(PercivalConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(SiegfriedConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _siegfried = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(SiegfriedConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(CharlottaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _charlotta = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(CharlottaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(YodarhaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _yodarha = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(YodarhaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(NarmayaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _narmaya = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(NarmayaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(GhandagozaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _ghandagoza = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(GhandagozaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(ZetaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _zeta = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(ZetaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(VaseragaConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _vaseraga = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(VaseragaConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(CagliostroConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _cagliostro = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(CagliostroConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(IdConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _id = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(IdConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(SandalphonConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _sandalphon = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(SandalphonConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(SeofonConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _seofon = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(SeofonConfig)} Updated: Applying");
    //}

    //public override void ConfigurationUpdated(TweyenConfig configuration)
    //{
    //    // Apply settings from configuration.
    //    // ... your code here.
    //    _tweyen = configuration;
    //    _logger.WriteLine($"[{_modConfig.ModId}] {nameof(TweyenConfig)} Updated: Applying");
    //}
    #endregion
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion


}