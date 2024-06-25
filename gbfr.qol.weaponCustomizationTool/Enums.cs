
using System.ComponentModel;

namespace gbfr.qol.weaponCustomizationTool;

public enum WeaponEffectControlType
{
    [Description("Enabled")]
    Enabled,

    [Description("Combat Only")]
    CombatOnly,

    [Description("Idle Only")]
    IdleOnly,

    [Description("Disabled")]
    Disabled,
}

public enum WeaponEffectToggle
{
    [Description("Enabled")]
    Enabled = WeaponEffectControlType.Enabled,

    [Description("Disabled")]
    Disabled = WeaponEffectControlType.Disabled,
}

#region Character specific Weapon ObjIds
public enum CaptainWeaponObjId : uint
{
    Travellers_Sword = AllWeaponObjId.Captain_Travellers_Sword,
    Durandal = AllWeaponObjId.Captain_Durandal,
    Sword_of_Eos = AllWeaponObjId.Captain_Sword_of_Eos,
    Albacore_Blade = AllWeaponObjId.Captain_Albacore_Blade,
    Ultima_Sword = AllWeaponObjId.Captain_Ultima_Sword,
    Seven_Star_Sword = AllWeaponObjId.Captain_Seven_Star_Sword,

    Partenza = AllWeaponObjId.Captain_Partenza,
}

public enum KatalinaWeaponObjId : uint
{
    Rukalsa = AllWeaponObjId.Katalina_Rukalsa,
    Flame_Rapier = AllWeaponObjId.Katalina_Flame_Rapier,
    Murgleis = AllWeaponObjId.Katalina_Murgleis,
    Luminiera_Sword_Omega = AllWeaponObjId.Katalina_Luminiera_Sword_Omega,
    Ephemeron = AllWeaponObjId.Katalina_Ephemeron,
    Blutgang = AllWeaponObjId.Katalina_Blutgang,
}

public enum RackamWeaponObjId : uint
{
    Flintspike = AllWeaponObjId.Rackam_Flintspike,
    Wheellock_Axe = AllWeaponObjId.Rackam_Wheellock_Axe,
    Benedia = AllWeaponObjId.Rackam_Benedia,
    Tiamat_Bolt_Omega = AllWeaponObjId.Rackam_Tiamat_Bolt_Omega,
    Stormcloud = AllWeaponObjId.Rackam_Stormcloud,
    Freikugel = AllWeaponObjId.Rackam_Freikugel,
}

public enum IoWeaponObjId : uint
{
    Little_Witch_Scepter = AllWeaponObjId.Io_Little_Witch_Scepter,
    Zhezl = AllWeaponObjId.Io_Zhezl,
    Gambanteinn = AllWeaponObjId.Io_Gambanteinn,
    Colossus_Cane_Omega = AllWeaponObjId.Io_Colossus_Cane_Omega,
    Tupsimati = AllWeaponObjId.Io_Tupsimati,
    Caduceus = AllWeaponObjId.Io_Caduceus,
}

public enum EugenWeaponObjId : uint
{
    Dreyse = AllWeaponObjId.Eugen_Dreyse,
    Matchlock = AllWeaponObjId.Eugen_Matchlock,
    AK4A = AllWeaponObjId.Eugen_AK4A,
    Leviathan_Muzzle = AllWeaponObjId.Eugen_Leviathan_Muzzle,
    Clarion = AllWeaponObjId.Eugen_Clarion,
    Draconic_Fire = AllWeaponObjId.Eugen_Draconic_Fire,
}

public enum RosettaWeaponObjId : uint
{
    Egoism = AllWeaponObjId.Rosetta_Egoism,
    Swordbreaker = AllWeaponObjId.Rosetta_Swordbreaker,
    Love_Eternal = AllWeaponObjId.Rosetta_Love_Eternal,
    Rose_Crystal_Knife = AllWeaponObjId.Rosetta_Rose_Crystal_Knife,
    Cortana = AllWeaponObjId.Rosetta_Cortana,
    Dagger_of_Bahamut_Coda = AllWeaponObjId.Rosetta_Dagger_of_Bahamut_Coda,
}

public enum FerryWeaponObjId : uint
{
    Geisterpeitche = AllWeaponObjId.Ferry_Geisterpeitche,
    Leather_Belt = AllWeaponObjId.Ferry_Leather_Belt,
    Ethereal_Lasher = AllWeaponObjId.Ferry_Ethereal_Lasher,
    Flame_Lit_Curl = AllWeaponObjId.Ferry_Flame_Lit_Curl,
    Live_Wire = AllWeaponObjId.Ferry_Live_Wire,
    Erinnerung = AllWeaponObjId.Ferry_Erinnerung,
}

public enum LancelotWeaponObjId : uint
{
    Altachiara = AllWeaponObjId.Lancelot_Altachiara,
    Hoarfrost_Blade_Persius = AllWeaponObjId.Lancelot_Hoarfrost_Blade_Persius,
    Blanc_Comme_Neige = AllWeaponObjId.Lancelot_Blanc_Comme_Neige,
    Vegalta = AllWeaponObjId.Lancelot_Vegalta,
    Knight_of_Ice = AllWeaponObjId.Lancelot_Knight_of_Ice,
    Damascus_Knife = AllWeaponObjId.Lancelot_Damascus_Knife,
}

public enum VaneWeaponObjId : uint
{
    Alabarda = AllWeaponObjId.Vane_Alabarda,
    Swan = AllWeaponObjId.Vane_Swan,
    Treuer_Krieger = AllWeaponObjId.Vane_Treuer_Krieger,
    Ukonvasara = AllWeaponObjId.Vane_Ukonvasara,
    Blossom_Axe = AllWeaponObjId.Vane_Blossom_Axe,
    Mjolnir = AllWeaponObjId.Vane_Mjolnir,
}

public enum PercivalWeaponObjId : uint
{
    Flamberge = AllWeaponObjId.Percival_Flamberge,
    Lohengrin = AllWeaponObjId.Percival_Lohengrin,
    Antwerp = AllWeaponObjId.Percival_Antwerp,
    Joyeuse = AllWeaponObjId.Percival_Joyeuse,
    Lord_of_Flames = AllWeaponObjId.Percival_Lord_of_Flames,
    Gottfried = AllWeaponObjId.Percival_Gottfried,
}

public enum SiegfriedWeaponObjId : uint
{
    Integrity = AllWeaponObjId.Siegfried_Integrity,
    Broadsword_of_Earth = AllWeaponObjId.Siegfried_Broadsword_of_Earth,
    Ascalon = AllWeaponObjId.Siegfried_Ascalon,
    Hrunting = AllWeaponObjId.Siegfried_Hrunting,
    Windhose = AllWeaponObjId.Siegfried_Windhose,
    Balmung = AllWeaponObjId.Siegfried_Balmung,
}

public enum CharlottaWeaponObjId : uint
{
    Claiomh_Solais = AllWeaponObjId.Charlotta_Claiomh_Solais,
    Arondight = AllWeaponObjId.Charlotta_Arondight,
    Claidheamh_Soluis = AllWeaponObjId.Charlotta_Claidheamh_Soluis,
    Ushumgal = AllWeaponObjId.Charlotta_Ushumgal,
    Sahrivar = AllWeaponObjId.Charlotta_Sahrivar,
    Galatine = AllWeaponObjId.Charlotta_Galatine,
}

public enum YodarhaWeaponObjId : uint
{
    Kiku_Ichimonji = AllWeaponObjId.Yodarha_Kiku_Ichimonji,
    Asura = AllWeaponObjId.Yodarha_Asura,
    Fudo_Kuniyuki = AllWeaponObjId.Yodarha_Fudo_Kuniyuki,
    Higurashi = AllWeaponObjId.Yodarha_Higurashi,
    Xeno_Phantom_Demon_Blade = AllWeaponObjId.Yodarha_Xeno_Phantom_Demon_Blade,
    Swordfish = AllWeaponObjId.Yodarha_Swordfish,
}

public enum NarmayaWeaponObjId : uint
{
    Nakamaki_Nodachi = AllWeaponObjId.Narmaya_Nakamaki_Nodachi,
    Kotetsu = AllWeaponObjId.Narmaya_Kotetsu,
    Venustas = AllWeaponObjId.Narmaya_Venustas,
    Flourithium_Blade = AllWeaponObjId.Narmaya_Flourithium_Blade,
    Blade_of_Purification = AllWeaponObjId.Narmaya_Blade_of_Purification,
    Ameno_Habakiri = AllWeaponObjId.Narmaya_Ameno_Habakiri,
}

public enum GhandagozaWeaponObjId : uint
{
    Brahma_Gauntlet = AllWeaponObjId.Ghandagoza_Brahma_Gauntlet,
    Rope_Knuckles = AllWeaponObjId.Ghandagoza_Rope_Knuckles,
    Crimson_Finger = AllWeaponObjId.Ghandagoza_Crimson_Finger,
    Golden_Fists_of_Ura = AllWeaponObjId.Ghandagoza_Golden_Fists_of_Ura,
    Arkab = AllWeaponObjId.Ghandagoza_Arkab,
    Sky_Piercer = AllWeaponObjId.Ghandagoza_Sky_Piercer,
}

public enum ZetaWeaponObjId : uint
{
    Spear_of_Arvess = AllWeaponObjId.Zeta_Spear_of_Arvess,
    Sunspot_Spear = AllWeaponObjId.Zeta_Sunspot_Spear,
    Brionac = AllWeaponObjId.Zeta_Brionac,
    Gisla = AllWeaponObjId.Zeta_Gisla,
    Huanglong_Spear = AllWeaponObjId.Zeta_Huanglong_Spear,
    Gae_Bulg = AllWeaponObjId.Zeta_Gae_Bulg,
}

public enum VaseragaWeaponObjId : uint
{
    Great_Scythe_Grynoth = AllWeaponObjId.Vaseraga_Great_Scythe_Grynoth,
    Alsarav = AllWeaponObjId.Vaseraga_Alsarav,
    Wurtzite_Scythe = AllWeaponObjId.Vaseraga_Wurtzite_Scythe,
    Soul_Eater = AllWeaponObjId.Vaseraga_Soul_Eater,
    Cosmic_Scythe = AllWeaponObjId.Vaseraga_Cosmic_Scythe,
    Ereshkigal = AllWeaponObjId.Vaseraga_Ereshkigal,
}

public enum CagliostroWeaponObjId : uint
{
    Magnum_Opus = AllWeaponObjId.Cagliostro_Magnum_Opus,
    Dream_Atlas = AllWeaponObjId.Cagliostro_Dream_Atlas,
    Transmigration_Tome = AllWeaponObjId.Cagliostro_Transmigration_Tome,
    Sacred_Codex = AllWeaponObjId.Cagliostro_Sacred_Codex,
    Arshivelle = AllWeaponObjId.Cagliostro_Arshivelle,
    Zosimos = AllWeaponObjId.Cagliostro_Zosimos,
}

public enum IdWeaponObjId : uint
{
    Ragnarok = AllWeaponObjId.Id_Ragnarok,
    Aviaeth_Faussart = AllWeaponObjId.Id_Aviaeth_Faussart,
    Susanoo = AllWeaponObjId.Id_Susanoo,
    Premium_Sword = AllWeaponObjId.Id_Premium_Sword,
    Ecke_Sachs = AllWeaponObjId.Id_Ecke_Sachs,
    Sword_of_Bahamut = AllWeaponObjId.Id_Sword_of_Bahamut,
}

public enum SeofonWeaponObjId : uint
{
    Sette_di_Spade = AllWeaponObjId.Seofon_Sette_di_Spade,
    Gateway_Star_Sword = AllWeaponObjId.Seofon_Gateway_Star_Sword,
}

public enum TweyenWeaponObjId : uint
{
    Bow_of_Dismissal = AllWeaponObjId.Tweyen_Bow_of_Dismissal,
    Desolation_Crown_Bow = AllWeaponObjId.Tweyen_Desolation_Crown_Bow,
}

public enum SandalphonWeaponObjId : uint
{
    Apprentice = AllWeaponObjId.Sandalphon_Apprentice,
    World_Ender = AllWeaponObjId.Sandalphon_World_Ender,
}
#endregion

public enum AllWeaponObjId : uint
{
    Captain_Travellers_Sword = eObjId.WP_Captain_Travellers_Sword,
    Captain_Durandal = eObjId.WP_Captain_Durandal,
    Captain_Sword_of_Eos = eObjId.WP_Captain_Sword_of_Eos,
    Captain_Albacore_Blade = eObjId.WP_Captain_Albacore_Blade,
    Captain_Ultima_Sword = eObjId.WP_Captain_Ultima_Sword,
    Captain_Seven_Star_Sword = eObjId.WP_Captain_Seven_Star_Sword,
    Captain_Partenza = eObjId.WP_Captain_Partenza,

    Katalina_Rukalsa = eObjId.WP_Katalina_Rukalsa,
    Katalina_Flame_Rapier = eObjId.WP_Katalina_Flame_Rapier,
    Katalina_Murgleis = eObjId.WP_Katalina_Murgleis,
    Katalina_Luminiera_Sword_Omega = eObjId.WP_Katalina_Luminiera_Sword_Omega,
    Katalina_Ephemeron = eObjId.WP_Katalina_Ephemeron,
    Katalina_Blutgang = eObjId.WP_Katalina_Blutgang,

    Rackam_Flintspike = eObjId.WP_Rackam_Flintspike,
    Rackam_Wheellock_Axe = eObjId.WP_Rackam_Wheellock_Axe,
    Rackam_Benedia = eObjId.WP_Rackam_Benedia,
    Rackam_Tiamat_Bolt_Omega = eObjId.WP_Rackam_Tiamat_Bolt_Omega,
    Rackam_Stormcloud = eObjId.WP_Rackam_Stormcloud,
    Rackam_Freikugel = eObjId.WP_Rackam_Freikugel,

    Io_Little_Witch_Scepter = eObjId.WP_Io_Little_Witch_Scepter,
    Io_Zhezl = eObjId.WP_Io_Zhezl,
    Io_Gambanteinn = eObjId.WP_Io_Gambanteinn,
    Io_Colossus_Cane_Omega = eObjId.WP_Io_Colossus_Cane_Omega,
    Io_Tupsimati = eObjId.WP_Io_Tupsimati,
    Io_Caduceus = eObjId.WP_Io_Caduceus,

    Eugen_Dreyse = eObjId.WP_Eugen_Dreyse,
    Eugen_Matchlock = eObjId.WP_Eugen_Matchlock,
    Eugen_AK4A = eObjId.WP_Eugen_AK4A,
    Eugen_Leviathan_Muzzle = eObjId.WP_Eugen_Leviathan_Muzzle,
    Eugen_Clarion = eObjId.WP_Eugen_Clarion,
    Eugen_Draconic_Fire = eObjId.WP_Eugen_Draconic_Fire,

    Rosetta_Egoism = eObjId.WP_Rosetta_Egoism,
    Rosetta_Swordbreaker = eObjId.WP_Rosetta_Swordbreaker,
    Rosetta_Love_Eternal = eObjId.WP_Rosetta_Love_Eternal,
    Rosetta_Rose_Crystal_Knife = eObjId.WP_Rosetta_Rose_Crystal_Knife,
    Rosetta_Cortana = eObjId.WP_Rosetta_Cortana,
    Rosetta_Dagger_of_Bahamut_Coda = eObjId.WP_Rosetta_Dagger_of_Bahamut_Coda,

    Ferry_Geisterpeitche = eObjId.WP_Ferry_Geisterpeitche,
    Ferry_Leather_Belt = eObjId.WP_Ferry_Leather_Belt,
    Ferry_Ethereal_Lasher = eObjId.WP_Ferry_Ethereal_Lasher,
    Ferry_Flame_Lit_Curl = eObjId.WP_Ferry_Flame_Lit_Curl,
    Ferry_Live_Wire = eObjId.WP_Ferry_Live_Wire,
    Ferry_Erinnerung = eObjId.WP_Ferry_Erinnerung,

    Lancelot_Altachiara = eObjId.WP_Lancelot_Altachiara,
    Lancelot_Hoarfrost_Blade_Persius = eObjId.WP_Lancelot_Hoarfrost_Blade_Persius,
    Lancelot_Blanc_Comme_Neige = eObjId.WP_Lancelot_Blanc_Comme_Neige,
    Lancelot_Vegalta = eObjId.WP_Lancelot_Vegalta,
    Lancelot_Knight_of_Ice = eObjId.WP_Lancelot_Knight_of_Ice,
    Lancelot_Damascus_Knife = eObjId.WP_Lancelot_Damascus_Knife,

    Vane_Alabarda = eObjId.WP_Vane_Alabarda,
    Vane_Swan = eObjId.WP_Vane_Swan,
    Vane_Treuer_Krieger = eObjId.WP_Vane_Treuer_Krieger,
    Vane_Ukonvasara = eObjId.WP_Vane_Ukonvasara,
    Vane_Blossom_Axe = eObjId.WP_Vane_Blossom_Axe,
    Vane_Mjolnir = eObjId.WP_Vane_Mjolnir,

    Percival_Flamberge = eObjId.WP_Percival_Flamberge,
    Percival_Lohengrin = eObjId.WP_Percival_Lohengrin,
    Percival_Antwerp = eObjId.WP_Percival_Antwerp,
    Percival_Joyeuse = eObjId.WP_Percival_Joyeuse,
    Percival_Lord_of_Flames = eObjId.WP_Percival_Lord_of_Flames,
    Percival_Gottfried = eObjId.WP_Percival_Gottfried,

    Siegfried_Integrity = eObjId.WP_Siegfried_Integrity,
    Siegfried_Broadsword_of_Earth = eObjId.WP_Siegfried_Broadsword_of_Earth,
    Siegfried_Ascalon = eObjId.WP_Siegfried_Ascalon,
    Siegfried_Hrunting = eObjId.WP_Siegfried_Hrunting,
    Siegfried_Windhose = eObjId.WP_Siegfried_Windhose,
    Siegfried_Balmung = eObjId.WP_Siegfried_Balmung,

    Charlotta_Claiomh_Solais = eObjId.WP_Charlotta_Claiomh_Solais,
    Charlotta_Arondight = eObjId.WP_Charlotta_Arondight,
    Charlotta_Claidheamh_Soluis = eObjId.WP_Charlotta_Claidheamh_Soluis,
    Charlotta_Ushumgal = eObjId.WP_Charlotta_Ushumgal,
    Charlotta_Sahrivar = eObjId.WP_Charlotta_Sahrivar,
    Charlotta_Galatine = eObjId.WP_Charlotta_Galatine,

    Yodarha_Kiku_Ichimonji = eObjId.WP_Yodarha_Kiku_Ichimonji,
    Yodarha_Asura = eObjId.WP_Yodarha_Asura,
    Yodarha_Fudo_Kuniyuki = eObjId.WP_Yodarha_Fudo_Kuniyuki,
    Yodarha_Higurashi = eObjId.WP_Yodarha_Higurashi,
    Yodarha_Xeno_Phantom_Demon_Blade = eObjId.WP_Yodarha_Xeno_Phantom_Demon_Blade,
    Yodarha_Swordfish = eObjId.WP_Yodarha_Swordfish,

    Narmaya_Nakamaki_Nodachi = eObjId.WP_Narmaya_Nakamaki_Nodachi,
    Narmaya_Kotetsu = eObjId.WP_Narmaya_Kotetsu,
    Narmaya_Venustas = eObjId.WP_Narmaya_Venustas,
    Narmaya_Flourithium_Blade = eObjId.WP_Narmaya_Flourithium_Blade,
    Narmaya_Blade_of_Purification = eObjId.WP_Narmaya_Blade_of_Purification,
    Narmaya_Ameno_Habakiri = eObjId.WP_Narmaya_Ameno_Habakiri,

    Ghandagoza_Brahma_Gauntlet = eObjId.WP_Ghandagoza_Brahma_Gauntlet,
    Ghandagoza_Rope_Knuckles = eObjId.WP_Ghandagoza_Rope_Knuckles,
    Ghandagoza_Crimson_Finger = eObjId.WP_Ghandagoza_Crimson_Finger,
    Ghandagoza_Golden_Fists_of_Ura = eObjId.WP_Ghandagoza_Golden_Fists_of_Ura,
    Ghandagoza_Arkab = eObjId.WP_Ghandagoza_Arkab,
    Ghandagoza_Sky_Piercer = eObjId.WP_Ghandagoza_Sky_Piercer,

    Zeta_Spear_of_Arvess = eObjId.WP_Zeta_Spear_of_Arvess,
    Zeta_Sunspot_Spear = eObjId.WP_Zeta_Sunspot_Spear,
    Zeta_Brionac = eObjId.WP_Zeta_Brionac,
    Zeta_Gisla = eObjId.WP_Zeta_Gisla,
    Zeta_Huanglong_Spear = eObjId.WP_Zeta_Huanglong_Spear,
    Zeta_Gae_Bulg = eObjId.WP_Zeta_Gae_Bulg,

    Vaseraga_Great_Scythe_Grynoth = eObjId.WP_Vaseraga_Great_Scythe_Grynoth,
    Vaseraga_Alsarav = eObjId.WP_Vaseraga_Alsarav,
    Vaseraga_Wurtzite_Scythe = eObjId.WP_Vaseraga_Wurtzite_Scythe,
    Vaseraga_Soul_Eater = eObjId.WP_Vaseraga_Soul_Eater,
    Vaseraga_Cosmic_Scythe = eObjId.WP_Vaseraga_Cosmic_Scythe,
    Vaseraga_Ereshkigal = eObjId.WP_Vaseraga_Ereshkigal,

    Cagliostro_Magnum_Opus = eObjId.WP_Cagliostro_Magnum_Opus,
    Cagliostro_Dream_Atlas = eObjId.WP_Cagliostro_Dream_Atlas,
    Cagliostro_Transmigration_Tome = eObjId.WP_Cagliostro_Transmigration_Tome,
    Cagliostro_Sacred_Codex = eObjId.WP_Cagliostro_Sacred_Codex,
    Cagliostro_Arshivelle = eObjId.WP_Cagliostro_Arshivelle,
    Cagliostro_Zosimos = eObjId.WP_Cagliostro_Zosimos,

    Id_Ragnarok = eObjId.WP_Id_Ragnarok,
    Id_Aviaeth_Faussart = eObjId.WP_Id_Aviaeth_Faussart,
    Id_Susanoo = eObjId.WP_Id_Susanoo,
    Id_Premium_Sword = eObjId.WP_Id_Premium_Sword,
    Id_Ecke_Sachs = eObjId.WP_Id_Ecke_Sachs,
    Id_Sword_of_Bahamut = eObjId.WP_Id_Sword_of_Bahamut,

    Seofon_Sette_di_Spade = eObjId.WP_Seofon_Sette_di_Spade,
    Seofon_Gateway_Star_Sword = eObjId.WP_Seofon_Gateway_Star_Sword,

    Tweyen_Bow_of_Dismissal = eObjId.WP_Tweyen_Bow_of_Dismissal,
    Tweyen_Desolation_Crown_Bow = eObjId.WP_Tweyen_Desolation_Crown_Bow,

    Sandalphon_Apprentice = eObjId.WP_Sandalphon_Apprentice,
    Sandalphon_World_Ender = eObjId.WP_Sandalphon_World_Ender,
}

#region Weapons With Effects
public enum CaptainEffectWeaponObjId : uint
{
    Ascension = CaptainWeaponObjId.Sword_of_Eos,
    Terminus = CaptainWeaponObjId.Seven_Star_Sword,
}

public enum KatalinaEffectWeaponObjId : uint
{
    Ascension = KatalinaWeaponObjId.Murgleis,
    Terminus = KatalinaWeaponObjId.Blutgang,
}

public enum RackamEffectWeaponObjId : uint
{
    Ascension = RackamWeaponObjId.Benedia,
    Terminus = RackamWeaponObjId.Freikugel,
}

public enum IoEffectWeaponObjId : uint
{
    Ascension = IoWeaponObjId.Gambanteinn,
    Terminus = IoWeaponObjId.Caduceus,
}

public enum EugenEffectWeaponObjId : uint
{
    Ascension = EugenWeaponObjId.AK4A,
    Terminus = EugenWeaponObjId.Draconic_Fire,
}

public enum RosettaEffectWeaponObjId : uint
{
    Ascension = RosettaWeaponObjId.Love_Eternal,
    Flame = RosettaWeaponObjId.Cortana,
    Terminus = RosettaWeaponObjId.Dagger_of_Bahamut_Coda,
}

public enum FerryEffectWeaponObjId : uint
{
    Ghostly = FerryWeaponObjId.Geisterpeitche,
    Ascension = FerryWeaponObjId.Erinnerung, // Yep, wp0705 is ascension not terminus.
    Flame = FerryWeaponObjId.Flame_Lit_Curl,
    Electric = FerryWeaponObjId.Live_Wire,
    Terminus = FerryWeaponObjId.Ethereal_Lasher, // And yep, wp0702 is terminus. Very weird.
}

public enum LancelotEffectWeaponObjId : uint
{
    Ascension = LancelotWeaponObjId.Knight_of_Ice,
    Terminus = LancelotWeaponObjId.Damascus_Knife,
}

public enum VaneEffectWeaponObjId : uint
{
    Ascension = VaneWeaponObjId.Treuer_Krieger,
    Terminus = VaneWeaponObjId.Mjolnir,
}

public enum PercivalEffectWeaponObjId : uint
{
    Ascension = PercivalWeaponObjId.Lord_of_Flames,
    Terminus = PercivalWeaponObjId.Gottfried,
}

public enum SiegfriedEffectWeaponObjId : uint
{
    Ascension = SiegfriedWeaponObjId.Ascalon,
    Terminus = SiegfriedWeaponObjId.Balmung,
}

public enum CharlottaEffectWeaponObjId : uint
{
    Ascension = CharlottaWeaponObjId.Claidheamh_Soluis,
    Terminus = CharlottaWeaponObjId.Galatine,
}

public enum YodarhaEffectWeaponObjId : uint
{
    Ascension = YodarhaWeaponObjId.Fudo_Kuniyuki,
    Terminus = YodarhaWeaponObjId.Swordfish,
}

public enum NarmayaEffectWeaponObjId : uint
{
    Ascension = NarmayaWeaponObjId.Venustas,
    Terminus = NarmayaWeaponObjId.Ameno_Habakiri,
}

public enum GhandagozaEffectWeaponObjId : uint
{
    Ascension = GhandagozaWeaponObjId.Golden_Fists_of_Ura,
    Terminus = GhandagozaWeaponObjId.Sky_Piercer,
}

public enum ZetaEffectWeaponObjId : uint
{
    Ascension = ZetaWeaponObjId.Brionac,
    Terminus = ZetaWeaponObjId.Gae_Bulg,
}

public enum VaseragaEffectWeaponObjId : uint
{
    Ascension = VaseragaWeaponObjId.Wurtzite_Scythe,
    Terminus = VaseragaWeaponObjId.Ereshkigal,
}

public enum CagliostroEffectWeaponObjId : uint
{
    Ascension = CagliostroWeaponObjId.Transmigration_Tome,
    Terminus = CagliostroWeaponObjId.Zosimos,
}

public enum IdEffectWeaponObjId : uint
{
    Ascension = IdWeaponObjId.Susanoo,
    Terminus = IdWeaponObjId.Sword_of_Bahamut,
}

public enum SandalphonEffectWeaponObjId : uint
{
    Terminus = SandalphonWeaponObjId.World_Ender,
}

public enum SeofonEffectWeaponObjId : uint
{
    Terminus = SeofonWeaponObjId.Gateway_Star_Sword,
}

public enum TweyenEffectWeaponObjId : uint
{
    Terminus = TweyenWeaponObjId.Desolation_Crown_Bow,
}
#endregion
