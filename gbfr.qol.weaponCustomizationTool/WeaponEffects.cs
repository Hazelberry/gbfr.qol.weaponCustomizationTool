
using System.Net.Http.Headers;

namespace gbfr.qol.weaponCustomizationTool;

/// <summary>
/// Contains various lists and dictionaries for referencing weapons that have effects
/// </summary>
public class WeaponEffects
{
    /// <summary>
    /// Only used for formatting Est filenames in GlowEffectEstPathMap
    /// </summary>
    private static readonly List<string> EffectSavedataEstPathFormats =
    [
            "effect/savedata/{0}/2000.est", // 0
            "effect/savedata/{0}/2005.est", // 1
            "effect/savedata/{0}/2010.est", // 2
            "effect/savedata/{0}/2020.est", // 3
            "effect/savedata/{0}/2110.est", // 4
            "effect/savedata/{0}/2120.est", // 5
            "effect/savedata/{0}/2001.est", // 6, only used by Narmaya's Terminus
            "effect/savedata/{0}/2002.est", // 7, only used by Narmaya's Terminus
    ];

    /// <summary>
    /// Key = Character ObjId<br />
    /// Value = Ascension Weapon ObjId
    /// </summary>    
    public static Dictionary<eObjId, eObjId> AscensionWeapons { get; } = new()
    {
        { eObjId.PL_Gran_Rebel,         eObjId.WP_Captain_Sword_of_Eos              },
        { eObjId.PL_Gran_Original,      eObjId.WP_Captain_Sword_of_Eos              },
        { eObjId.PL_Djeeta_Rebel,       eObjId.WP_Captain_Sword_of_Eos              },
        { eObjId.PL_Djeeta_Original,    eObjId.WP_Captain_Sword_of_Eos              },
        { eObjId.PL_Katalina,           eObjId.WP_Katalina_Murgleis                 },
        { eObjId.PL_Rackam,             eObjId.WP_Rackam_Benedia                    },
        { eObjId.PL_Io,                 eObjId.WP_Io_Gambanteinn                    },
        { eObjId.PL_Eugen,              eObjId.WP_Eugen_AK4A                        },
        { eObjId.PL_Rosetta,            eObjId.WP_Rosetta_Love_Eternal              },
        { eObjId.PL_Ferry,              eObjId.WP_Ferry_Erinnerung                  },
        { eObjId.PL_Lancelot,           eObjId.WP_Lancelot_Knight_of_Ice            },
        { eObjId.PL_Vane,               eObjId.WP_Vane_Treuer_Krieger               },
        { eObjId.PL_Percival,           eObjId.WP_Percival_Lord_of_Flames           },
        { eObjId.PL_Siegfried,          eObjId.WP_Siegfried_Ascalon                 },
        { eObjId.PL_Charlotta,          eObjId.WP_Charlotta_Claidheamh_Soluis       },
        { eObjId.PL_Yodarha,            eObjId.WP_Yodarha_Fudo_Kuniyuki             },
        { eObjId.PL_Narmaya,            eObjId.WP_Narmaya_Venustas                  },
        { eObjId.PL_Ghandagoza,         eObjId.WP_Ghandagoza_Golden_Fists_of_Ura    },
        { eObjId.PL_Zeta,               eObjId.WP_Zeta_Brionac                      },
        { eObjId.PL_Vaseraga,           eObjId.WP_Vaseraga_Wurtzite_Scythe          },
        { eObjId.PL_Cagliostro,         eObjId.WP_Cagliostro_Transmigration_Tome    },
        { eObjId.PL_Id,                 eObjId.WP_Id_Susanoo                        },
    };

    /// <summary>
    /// Key = Character ObjId<br />
    /// Value = Terminus Weapon ObjId
    /// </summary>
    public static Dictionary<eObjId, eObjId> TerminusWeapons { get; } = new()
    {
        {eObjId.PL_Gran_Rebel,      eObjId.WP_Captain_Seven_Star_Sword          },
        {eObjId.PL_Gran_Original,   eObjId.WP_Captain_Seven_Star_Sword          },
        {eObjId.PL_Djeeta_Rebel,    eObjId.WP_Captain_Seven_Star_Sword          },
        {eObjId.PL_Djeeta_Original, eObjId.WP_Captain_Seven_Star_Sword          },
        {eObjId.PL_Katalina,        eObjId.WP_Katalina_Blutgang                 },
        {eObjId.PL_Rackam,          eObjId.WP_Rackam_Freikugel                  },
        {eObjId.PL_Io,              eObjId.WP_Io_Caduceus                       },
        {eObjId.PL_Eugen,           eObjId.WP_Eugen_Draconic_Fire               },
        {eObjId.PL_Rosetta,         eObjId.WP_Rosetta_Dagger_of_Bahamut_Coda    },
        {eObjId.PL_Ferry,           eObjId.WP_Ferry_Ethereal_Lasher             },
        {eObjId.PL_Lancelot,        eObjId.WP_Lancelot_Damascus_Knife           },
        {eObjId.PL_Vane,            eObjId.WP_Vane_Mjolnir                      },
        {eObjId.PL_Percival,        eObjId.WP_Percival_Gottfried                },
        {eObjId.PL_Siegfried,       eObjId.WP_Siegfried_Balmung                 },
        {eObjId.PL_Charlotta,       eObjId.WP_Charlotta_Galatine                },
        {eObjId.PL_Yodarha,         eObjId.WP_Yodarha_Swordfish                 },
        {eObjId.PL_Narmaya,         eObjId.WP_Narmaya_Ameno_Habakiri            },
        {eObjId.PL_Ghandagoza,      eObjId.WP_Ghandagoza_Sky_Piercer            },
        {eObjId.PL_Zeta,            eObjId.WP_Zeta_Gae_Bulg                     },
        {eObjId.PL_Vaseraga,        eObjId.WP_Vaseraga_Ereshkigal               },
        {eObjId.PL_Cagliostro,      eObjId.WP_Cagliostro_Zosimos                },
        {eObjId.PL_Id,              eObjId.WP_Id_Sword_of_Bahamut               },
        {eObjId.PL_Sandalphon,      eObjId.WP_Sandalphon_World_Ender            },
        {eObjId.PL_Seofon,          eObjId.WP_Seofon_Gateway_Star_Sword         },
        {eObjId.PL_Tweyen,          eObjId.WP_Tweyen_Desolation_Crown_Bow       },
    };

    /// <summary>
    /// <para>Weapons with glow effects that aren't Ascension or Terminus weapons.</para>
    /// First Key = Character ObjId<br />
    /// Second Key = Identifier string: "Ghostly", "Flame", or "Electric"<br />
    /// Value = Weapon ObjId
    /// </summary>
    public static Dictionary<eObjId, Dictionary<string, eObjId>> ExtraGlowEffects { get; } = new()
    {
        {
            eObjId.PL_Ferry, new()
            {
                { "Ghostly", eObjId.WP_Ferry_Geisterpeitche },
                { "Flame", eObjId.WP_Ferry_Flame_Lit_Curl },
                { "Electric", eObjId.WP_Ferry_Live_Wire },
            }
        },
        {
            eObjId.PL_Rosetta, new()
            {
                { "Flame", eObjId.WP_Rosetta_Cortana },
            }
        },
    };

    /// <summary>
    /// <para>List of all weapon model IDs that use glow effects.</para>
    /// Some weapons aren't included which only use CallSelector.bxm effects.<br />
    /// Those are stored and controlled separately from standard glow effects.
    /// </summary>
    public static List<eObjId> AllGlowWeapons { get; } =
    [
        AscensionWeapons[eObjId.PL_Gran_Rebel],
        TerminusWeapons[eObjId.PL_Gran_Rebel],
        AscensionWeapons[eObjId.PL_Katalina],
        TerminusWeapons[eObjId.PL_Katalina],
        AscensionWeapons[eObjId.PL_Rackam],
        TerminusWeapons[eObjId.PL_Rackam],
        AscensionWeapons[eObjId.PL_Io],
        TerminusWeapons[eObjId.PL_Io],
        AscensionWeapons[eObjId.PL_Eugen],
        TerminusWeapons[eObjId.PL_Eugen],
        AscensionWeapons[eObjId.PL_Rosetta],
        ExtraGlowEffects[eObjId.PL_Rosetta]["Flame"],
        TerminusWeapons[eObjId.PL_Rosetta],
        ExtraGlowEffects[eObjId.PL_Ferry]["Ghostly"],
        AscensionWeapons[eObjId.PL_Ferry],
        ExtraGlowEffects[eObjId.PL_Ferry]["Flame"],
        ExtraGlowEffects[eObjId.PL_Ferry]["Electric"],
        TerminusWeapons[eObjId.PL_Ferry],
        AscensionWeapons[eObjId.PL_Lancelot],
        TerminusWeapons[eObjId.PL_Lancelot],
        AscensionWeapons[eObjId.PL_Vane],
        TerminusWeapons[eObjId.PL_Vane],
        AscensionWeapons[eObjId.PL_Percival],
        TerminusWeapons[eObjId.PL_Percival],
        AscensionWeapons[eObjId.PL_Siegfried],
        TerminusWeapons[eObjId.PL_Siegfried],
        AscensionWeapons[eObjId.PL_Charlotta],
        TerminusWeapons[eObjId.PL_Charlotta],
        AscensionWeapons[eObjId.PL_Yodarha],
        TerminusWeapons[eObjId.PL_Yodarha],
        AscensionWeapons[eObjId.PL_Narmaya],
        TerminusWeapons[eObjId.PL_Narmaya],
        AscensionWeapons[eObjId.PL_Ghandagoza],
        TerminusWeapons[eObjId.PL_Ghandagoza],
        AscensionWeapons[eObjId.PL_Zeta],
        TerminusWeapons[eObjId.PL_Zeta],
        AscensionWeapons[eObjId.PL_Vaseraga],
        TerminusWeapons[eObjId.PL_Vaseraga],
        AscensionWeapons[eObjId.PL_Cagliostro],
        TerminusWeapons[eObjId.PL_Cagliostro],
        AscensionWeapons[eObjId.PL_Id],
        TerminusWeapons[eObjId.PL_Id],
        TerminusWeapons[eObjId.PL_Sandalphon],
        TerminusWeapons[eObjId.PL_Seofon],
        TerminusWeapons[eObjId.PL_Tweyen],
    ];

    /// <summary>
    /// Suffixes for the EstId values in CallSelector.bxm
    /// </summary>
    /// <returns></returns>
    public static Dictionary<eObjId, char> FerryCallSelector { get; } = new()
    {
        { ExtraGlowEffects[eObjId.PL_Ferry]["Ghostly"],     '0' }, // wp0700
        { eObjId.WP_Ferry_Leather_Belt,                 '0' }, // Leather belt, doesn't have normal effects only a callselector/attack effect
        { TerminusWeapons[eObjId.PL_Ferry],             '4' }, // wp0702, only character to have a weird terminus number
        { ExtraGlowEffects[eObjId.PL_Ferry]["Flame"],       '2' }, // wp0703
        { ExtraGlowEffects[eObjId.PL_Ferry]["Electric"],    '3' }, // wp0704
        { AscensionWeapons[eObjId.PL_Ferry],            '1' }, // wp0705
    };

    /// <summary>
    /// First Key = Weapon ObjId, either 0x32200u or 0x32206u<br />
    /// Second Key = First character in the EstId value<br />
    /// Value =<br />
    /// ⠀⠀Third character in EstId if Second Key = 1<br />
    /// ⠀⠀Last character in EstId if Second Key = 7
    /// </summary> // Using whitespace character '⠀' above for indents
    public static Dictionary<eObjId, Dictionary<char, char>> SeofonCallSelector { get; } = new()
    {
        {
            // Defender
            eObjId.WP_Seofon_Sette_di_Spade, new Dictionary<char, char>()
            {
                { '1', '5' },
                { '7', '0' },
                //"1050",
                //"1055",
                //"1056",
                //"7510",
                //"7610",
            }
        },
        {
            // Ascension
            eObjId.WP_Seofon_Gateway_Star_Sword, new Dictionary<char, char>()
            {
                { '1', '6' },
                { '7', '1' },
                //"1060",
                //"1065",
                //"1066",
                //"7511",
                //"7611",
            }
        }
    };

    /// <summary>
    /// <para>Dictionary of Est filepaths for all weapons that have glow effects.</para>
    /// Key = Weapon ObjId<br />
    /// Value = List of Est Paths
    /// </summary>
    public static Dictionary<eObjId, List<string>> GlowEffectEstPathMap { get; } = new()
    {
        {
            AscensionWeapons[eObjId.PL_Gran_Rebel],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
                EffectSavedataEstPathFormats[3],
                EffectSavedataEstPathFormats[4],
                EffectSavedataEstPathFormats[5],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Gran_Rebel],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
                EffectSavedataEstPathFormats[4],
                EffectSavedataEstPathFormats[5],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Katalina],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Katalina],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Rackam],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Rackam],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Io],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Io],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Eugen],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Eugen],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Rosetta],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            ExtraGlowEffects[eObjId.PL_Rosetta]["Flame"],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Rosetta],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            ExtraGlowEffects[eObjId.PL_Ferry]["Ghostly"],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Ferry],
            new List<string>()
            {
                EffectSavedataEstPathFormats[1],
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            ExtraGlowEffects[eObjId.PL_Ferry]["Flame"],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
            }
        },
        {
            ExtraGlowEffects[eObjId.PL_Ferry]["Electric"],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
                EffectSavedataEstPathFormats[1],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Ferry],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
                EffectSavedataEstPathFormats[1],
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Lancelot],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Lancelot],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Vane],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Vane],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Percival],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Percival],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Siegfried],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Siegfried],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Charlotta],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Charlotta],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Yodarha],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Yodarha],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Narmaya],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Narmaya],
            new List<string>()
            {
                EffectSavedataEstPathFormats[0],
                EffectSavedataEstPathFormats[6],
                EffectSavedataEstPathFormats[7],
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Ghandagoza],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Ghandagoza],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Zeta],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Zeta],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Vaseraga],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Vaseraga],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Cagliostro],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Cagliostro],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            AscensionWeapons[eObjId.PL_Id],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Id],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Sandalphon],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Seofon],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        },
        {
            TerminusWeapons[eObjId.PL_Tweyen],
            new List<string>()
            {
                EffectSavedataEstPathFormats[2],
                EffectSavedataEstPathFormats[3],
            }
        }
    };
}
