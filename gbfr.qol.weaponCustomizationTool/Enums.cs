
using System.ComponentModel;

namespace gbfr.qol.weaponCustomizationTool
{
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

    public enum CaptainWeaponObjId : uint
    {
        Travellers_Sword = 0x30000u,
        Durandal = 0x30001u,
        Sword_of_Eos = 0x30002u,
        Albacore_Blade = 0x30003u,
        Ultima_Sword = 0x30004u,
        Seven_Star_Sword = 0x30005u,

        Partenza = 0x30100u,
    }

    public enum KatalinaWeaponObjId : uint
    {
        Rukalsa = 0x30200u,
        Flame_Rapier = 0x30201u,
        Murgleis = 0x30202u,
        Luminiera_Sword_Omega = 0x30203u,
        Ephemeron = 0x30204u,
        Blutgang = 0x30205u,
    }

    public enum RackamWeaponObjId : uint
    {
        Flintspike = 0x30300u,
        Wheellock_Axe = 0x30301u,
        Benedia = 0x30302u,
        Tiamat_Bolt_Omega = 0x30303u,
        Stormcloud = 0x30304u,
        Freikugel = 0x30305u,
    }

    public enum IoWeaponObjId : uint
    {
        Little_Witch_Scepter = 0x30400u,
        Zhezl = 0x30401u,
        Gambanteinn = 0x30402u,
        Colossus_Cane_Omega = 0x30403u,
        Tupsimati = 0x30404u,
        Caduceus = 0x30405u,
    }

    public enum EugenWeaponObjId : uint
    {
        Dreyse = 0x30500u,
        Matchlock = 0x30501u,
        AK4A = 0x30502u,
        Leviathan_Muzzle = 0x30503u,
        Clarion = 0x30504u,
        Draconic_Fire = 0x30505u,
    }

    public enum RosettaWeaponObjId : uint
    {
        Egoism = 0x30600u,
        Swordbreaker = 0x30601u,
        Love_Eternal = 0x30602u,
        Rose_Crystal_Knife = 0x30603u,
        Cortana = 0x30604u,
        Dagger_of_Bahamut_Coda = 0x30605u,
    }

    public enum FerryWeaponObjId : uint
    {
        Geisterpeitche = 0x30700u,
        Leather_Belt = 0x30701u,
        Ethereal_Lasher = 0x30702u,
        Flame_Lit_Curl = 0x30703u,
        Live_Wire = 0x30704u,
        Erinnerung = 0x30705u,
    }

    public enum LancelotWeaponObjId : uint
    {
        Altachiara = 0x30800u,
        Hoarfrost_Blade_Persius = 0x30801u,
        Blanc_Comme_Neige = 0x30802u,
        Vegalta = 0x30803u,
        Knight_of_Ice = 0x30804u,
        Damascus_Knife = 0x30805u,
    }

    public enum VaneWeaponObjId : uint
    {
        Alabarda = 0x30900u,
        Swan = 0x30901u,
        Treuer_Krieger = 0x30902u,
        Ukonvasara = 0x30903u,
        Blossom_Axe = 0x30904u,
        Mjolnir = 0x30905u,
    }

    public enum PercivalWeaponObjId : uint
    {
        Flamberge = 0x31000u,
        Lohengrin = 0x31001u,
        Antwerp = 0x31002u,
        Joyeuse = 0x31003u,
        Lord_of_Flames = 0x31004u,
        Gottfried = 0x31005u,
    }

    public enum SiegfriedWeaponObjId : uint
    {
        Integrity = 0x31100u,
        Broadsword_of_Earth = 0x31101u,
        Ascalon = 0x31102u,
        Hrunting = 0x31103u,
        Windhose = 0x31104u,
        Balmung = 0x31105u,
    }

    public enum CharlottaWeaponObjId : uint
    {
        Claiomh_Solais = 0x31200u,
        Arondight = 0x31201u,
        Claidheamh_Soluis = 0x31202u,
        Ushumgal = 0x31203u,
        Sahrivar = 0x31204u,
        Galatine = 0x31205u,
    }

    public enum YodarhaWeaponObjId : uint
    {
        Kiku_Ichimonji = 0x31300u,
        Asura = 0x31301u,
        Fudo_Kuniyuki = 0x31302u,
        Higurashi = 0x31303u,
        Xeno_Phantom_Demon_Blade = 0x31304u,
        Swordfish = 0x31305u,
    }

    public enum NarmayaWeaponObjId : uint
    {
        Nakamaki_Nodachi = 0x31400u,
        Kotetsu = 0x31401u,
        Venustas = 0x31402u,
        Flourithium_Blade = 0x31403u,
        Blade_of_Purification = 0x31404u,
        Ameno_Habakiri = 0x31405u,
    }

    public enum GhandagozaWeaponObjId : uint
    {
        Brahma_Gauntlet = 0x31500u,
        Rope_Knuckles = 0x31501u,
        Crimson_Finger = 0x31502u,
        Golden_Fists_of_Ura = 0x31503u,
        Arkab = 0x31504u,
        Sky_Piercer = 0x31505u,
    }

    public enum ZetaWeaponObjId : uint
    {
        Spear_of_Arvess = 0x31600u,
        Sunspot_Spear = 0x31601u,
        Brionac = 0x31602u,
        Gisla = 0x31603u,
        Huanglong_Spear = 0x31604u,
        Gae_Bulg = 0x31605u,
    }

    public enum VaseragaWeaponObjId : uint
    {
        Great_Scythe_Grynoth = 0x31700u,
        Alsarav = 0x31701u,
        Wurtzite_Scythe = 0x31702u,
        Soul_Eater = 0x31703u,
        Cosmic_Scythe = 0x31704u,
        Ereshkigal = 0x31705u,
    }

    public enum CagliostroWeaponObjId : uint
    {
        Magnum_Opus = 0x31800u,
        Dream_Atlas = 0x31801u,
        Transmigration_Tome = 0x31802u,
        Sacred_Codex = 0x31803u,
        Arshivelle = 0x31804u,
        Zosimos = 0x31805u,
    }

    public enum IdWeaponObjId : uint
    {
        Ragnarok = 0x31900u,
        Aviaeth_Faussart = 0x31901u,
        Susanoo = 0x31902u,
        Premium_Sword = 0x31903u,
        Ecke_Sachs = 0x31904u,
        Sword_of_Bahamut = 0x31905u,
    }

    public enum SeofonWeaponObjId : uint
    {
        Sette_di_Spade = 0x32200u,
        Gateway_Star_Sword = 0x32206u,
    }

    public enum TweyenWeaponObjId : uint
    {
        Bow_of_Dismissal = 0x32300u,
        Desolation_Crown_Bow = 0x32306u,
    }

    public enum SandalphonWeaponObjId : uint
    {
        Apprentice = 0x32100u,
        WorldEnder = 0x32106u,
    }

    public enum AllWeaponObjId : uint
    {
        Captain_Travellers_Sword = 0x30000u,
        Captain_Durandal = 0x30001u,
        Captain_Sword_of_Eos = 0x30002u,
        Captain_Albacore_Blade = 0x30003u,
        Captain_Ultima_Sword = 0x30004u,
        Captain_Seven_Star_Sword = 0x30005u,
        Captain_Partenza = 0x30100u,
    
        Katalina_Rukalsa = 0x30200u,
        Katalina_Flame_Rapier = 0x30201u,
        Katalina_Murgleis = 0x30202u,
        Katalina_Luminiera_Sword_Omega = 0x30203u,
        Katalina_Ephemeron = 0x30204u,
        Katalina_Blutgang = 0x30205u,
    
        Rackam_Flintspike = 0x30300u,
        Rackam_Wheellock_Axe = 0x30301u,
        Rackam_Benedia = 0x30302u,
        Rackam_Tiamat_Bolt_Omega = 0x30303u,
        Rackam_Stormcloud = 0x30304u,
        Rackam_Freikugel = 0x30305u,
    
        Io_Little_Witch_Scepter = 0x30400u,
        Io_Zhezl = 0x30401u,
        Io_Gambanteinn = 0x30402u,
        Io_Colossus_Cane_Omega = 0x30403u,
        Io_Tupsimati = 0x30404u,
        Io_Caduceus = 0x30405u,
    
        Eugen_Dreyse = 0x30500u,
        Eugen_Matchlock = 0x30501u,
        Eugen_AK4A = 0x30502u,
        Eugen_Leviathan_Muzzle = 0x30503u,
        Eugen_Clarion = 0x30504u,
        Eugen_Draconic_Fire = 0x30505u,
    
        Rosetta_Egoism = 0x30600u,
        Rosetta_Swordbreaker = 0x30601u,
        Rosetta_Love_Eternal = 0x30602u,
        Rosetta_Rose_Crystal_Knife = 0x30603u,
        Rosetta_Cortana = 0x30604u,
        Rosetta_Dagger_of_Bahamut_Coda = 0x30605u,
    
        Ferry_Geisterpeitche = 0x30700u,
        Ferry_Leather_Belt = 0x30701u,
        Ferry_Ethereal_Lasher = 0x30702u,
        Ferry_Flame_Lit_Curl = 0x30703u,
        Ferry_Live_Wire = 0x30704u,
        Ferry_Erinnerung = 0x30705u,
    
        Lancelot_Altachiara = 0x30800u,
        Lancelot_Hoarfrost_Blade_Persius = 0x30801u,
        Lancelot_Blanc_Comme_Neige = 0x30802u,
        Lancelot_Vegalta = 0x30803u,
        Lancelot_Knight_of_Ice = 0x30804u,
        Lancelot_Damascus_Knife = 0x30805u,
    
        Vane_Alabarda = 0x30900u,
        Vane_Swan = 0x30901u,
        Vane_Treuer_Krieger = 0x30902u,
        Vane_Ukonvasara = 0x30903u,
        Vane_Blossom_Axe = 0x30904u,
        Vane_Mjolnir = 0x30905u,
    
        Percival_Flamberge = 0x31000u,
        Percival_Lohengrin = 0x31001u,
        Percival_Antwerp = 0x31002u,
        Percival_Joyeuse = 0x31003u,
        Percival_Lord_of_Flames = 0x31004u,
        Percival_Gottfried = 0x31005u,
    
        Siegfried_Integrity = 0x31100u,
        Siegfried_Broadsword_of_Earth = 0x31101u,
        Siegfried_Ascalon = 0x31102u,
        Siegfried_Hrunting = 0x31103u,
        Siegfried_Windhose = 0x31104u,
        Siegfried_Balmung = 0x31105u,
    
        Charlotta_Claiomh_Solais = 0x31200u,
        Charlotta_Arondight = 0x31201u,
        Charlotta_Claidheamh_Soluis = 0x31202u,
        Charlotta_Ushumgal = 0x31203u,
        Charlotta_Sahrivar = 0x31204u,
        Charlotta_Galatine = 0x31205u,
    
        Yodarha_Kiku_Ichimonji = 0x31300u,
        Yodarha_Asura = 0x31301u,
        Yodarha_Fudo_Kuniyuki = 0x31302u,
        Yodarha_Higurashi = 0x31303u,
        Yodarha_Xeno_Phantom_Demon_Blade = 0x31304u,
        Yodarha_Swordfish = 0x31305u,
    
        Narmaya_Nakamaki_Nodachi = 0x31400u,
        Narmaya_Kotetsu = 0x31401u,
        Narmaya_Venustas = 0x31402u,
        Narmaya_Flourithium_Blade = 0x31403u,
        Narmaya_Blade_of_Purification = 0x31404u,
        Narmaya_Ameno_Habakiri = 0x31405u,
    
        Ghandagoza_Brahma_Gauntlet = 0x31500u,
        Ghandagoza_Rope_Knuckles = 0x31501u,
        Ghandagoza_Crimson_Finger = 0x31502u,
        Ghandagoza_Golden_Fists_of_Ura = 0x31503u,
        Ghandagoza_Arkab = 0x31504u,
        Ghandagoza_Sky_Piercer = 0x31505u,
    
        Zeta_Spear_of_Arvess = 0x31600u,
        Zeta_Sunspot_Spear = 0x31601u,
        Zeta_Brionac = 0x31602u,
        Zeta_Gisla = 0x31603u,
        Zeta_Huanglong_Spear = 0x31604u,
        Zeta_Gae_Bulg = 0x31605u,
    
        Vaseraga_Great_Scythe_Grynoth = 0x31700u,
        Vaseraga_Alsarav = 0x31701u,
        Vaseraga_Wurtzite_Scythe = 0x31702u,
        Vaseraga_Soul_Eater = 0x31703u,
        Vaseraga_Cosmic_Scythe = 0x31704u,
        Vaseraga_Ereshkigal = 0x31705u,
    
        Cagliostro_Magnum_Opus = 0x31800u,
        Cagliostro_Dream_Atlas = 0x31801u,
        Cagliostro_Transmigration_Tome = 0x31802u,
        Cagliostro_Sacred_Codex = 0x31803u,
        Cagliostro_Arshivelle = 0x31804u,
        Cagliostro_Zosimos = 0x31805u,
    
        Id_Ragnarok = 0x31900u,
        Id_Aviaeth_Faussart = 0x31901u,
        Id_Susanoo = 0x31902u,
        Id_Premium_Sword = 0x31903u,
        Id_Ecke_Sachs = 0x31904u,
        Id_Sword_of_Bahamut = 0x31905u,
    
        Seofon_Sette_di_Spade = 0x32200u,
        Seofon_Gateway_Star_Sword = 0x32206u,
    
        Tweyen_Bow_of_Dismissal = 0x32300u,
        Tweyen_Desolation_Crown_Bow = 0x32306u,
    
        Sandalphon_Apprentice = 0x32100u,
        Sandalphon_WorldEnder = 0x32106u,
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
        Ascension = FerryWeaponObjId.Erinnerung,
        Flame = FerryWeaponObjId.Flame_Lit_Curl,
        Electric = FerryWeaponObjId.Live_Wire,
        Terminus = FerryWeaponObjId.Ethereal_Lasher,
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
        Terminus = SandalphonWeaponObjId.WorldEnder,
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
}
