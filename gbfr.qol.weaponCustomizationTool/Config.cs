using gbfr.qol.weaponCustomizationTool.Template;
using gbfr.qol.weaponCustomizationTool.Template.Configuration;
using Reloaded.Mod.Interfaces;

using Reloaded.Mod.Interfaces.Structs;

using System.ComponentModel;

namespace gbfr.qol.weaponCustomizationTool.Configuration
{
    public class Config : Configurable<Config>
    {
        [DisplayName("Toggle Effect Preservation")]
        [Category("Main Settings")]
        [Description("""

            Keep this enabled if you want to keep effects while using weapons without effects as skins.
            Only one effect can override a single non-effect weapon at a time.

            For example if you use a single non-effect weapon as a skin for both of a character's
            Ascension and Terminus weapons only the second one loaded (typically Terminus)
            will show up in game for both weapons.

            This works by overriding the non-effect weapon's effect attribute to point at the original
            weapon's effect. It still will not cause non-effect weapons to use effects.
            The effect will only show when the non-effect weapon is being used as
            a skin over a weapon that does have effects.

            Loads after effect swapping and preserves those settings.

            If you want to keep the original effect when using another weapon with an effect as a skin
            use the Effect Swap options instead and set the skin weapon's effect to your
            desired effect.

            """)]
        [DefaultValue(true)]
        public bool ToggleEffectPreservation { get; set; } = true;

        //[DisplayName("Disable character restrictions")]
        //[Category("Main Settings")]
        //[Description("Enable to allow using weapons from other characters as skins")]
        //[DefaultValue(false)]
        //public bool ToggleSwapRestrictions { get; set; } = false;
    }

    public class CaptainConfig : Configurable<CaptainConfig> // 0000-0100
    {
        #region Sheath Swap
        [DisplayName("Enable Djeeta Sheath Swapping")]
        [Category("Main Settings")]
        [DefaultValue(false)]
        [Description("\nEnables swapping Djeeta's sheaths on her default outfit.\n" +
            "If replacing Partenza it will apply the thick sheath and only affect that weapon.\n" +
            "However, replacing any other weapon WITH Partenza will replace the thick sheath for all of her weapons\n" +
            "and those will have noticeable clipping if they were not also swapped to Partenza.\n\n" +
            "Does not affect Gran's default outfit or either Captain's rebelwear outfits, they only have a single sheath size.\n\n" +
            "Will not work if you have a modified Djeeta default outfit player model.\n")]
        public bool SheathSwapToggle { get; set; } = false;
        #endregion

        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Traveller's Sword")]
        [Category("Model Swap")]
        [Description("\nGran's Defender Weapon\n")]
        [DefaultValue(CaptainWeaponObjId.Travellers_Sword)]
        public CaptainWeaponObjId Swap_TravellersSword { get; set; } = CaptainWeaponObjId.Travellers_Sword;

        [DisplayName("Partenza")]
        [Category("Model Swap")]
        [Description("\nDjeeta's Defender Weapon\n")]
        [DefaultValue(CaptainWeaponObjId.Partenza)]
        public CaptainWeaponObjId Swap_Partenza { get; set; } = CaptainWeaponObjId.Partenza;

        [DisplayName("Durandal")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(CaptainWeaponObjId.Durandal)]
        public CaptainWeaponObjId Swap_Durandal { get; set; } = CaptainWeaponObjId.Durandal;

        [DisplayName("Sword of Eos")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(CaptainWeaponObjId.Sword_of_Eos)]
        public CaptainWeaponObjId Swap_SwordofEos { get; set; } = CaptainWeaponObjId.Sword_of_Eos;

        [DisplayName("Albacore Blade")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(CaptainWeaponObjId.Albacore_Blade)]
        public CaptainWeaponObjId Swap_AlbacoreBlade { get; set; } = CaptainWeaponObjId.Albacore_Blade;

        [DisplayName("Ultima Sword")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(CaptainWeaponObjId.Ultima_Sword)]
        public CaptainWeaponObjId Swap_UltimaSword { get; set; } = CaptainWeaponObjId.Ultima_Sword;

        [DisplayName("Seven-Star Sword")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(CaptainWeaponObjId.Seven_Star_Sword)]
        public CaptainWeaponObjId Swap_SevenStarSword { get; set; } = CaptainWeaponObjId.Seven_Star_Sword;
#else
        [DisplayName("Traveller's Sword")]
        [Category("Model Swap")]
        [DefaultValue(AllWeaponObjId.Captain_Travellers_Sword)]
        [Description("\nGran's Defender Weapon\n")]
        public AllWeaponObjId Swap_TravellersSword { get; set; } = AllWeaponObjId.Captain_Travellers_Sword;

        [DisplayName("Partenza")]
        [Category("Model Swap")]
        [DefaultValue(AllWeaponObjId.Captain_Partenza)]
        [Description("\nDjeeta's Defender Weapon\n")]
        public AllWeaponObjId Swap_Partenza { get; set; } = AllWeaponObjId.Captain_Partenza;

        [DisplayName("Durandal")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Captain_Durandal)]
        public AllWeaponObjId Swap_Durandal { get; set; } = AllWeaponObjId.Captain_Durandal;

        [DisplayName("Sword of Eos")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Captain_Sword_of_Eos)]
        public AllWeaponObjId Swap_SwordofEos { get; set; } = AllWeaponObjId.Captain_Sword_of_Eos;

        [DisplayName("Albacore Blade")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Captain_Albacore_Blade)]
        public AllWeaponObjId Swap_AlbacoreBlade { get; set; } = AllWeaponObjId.Captain_Albacore_Blade;

        [DisplayName("Ultima Sword")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Captain_Ultima_Sword)]
        public AllWeaponObjId Swap_UltimaSword { get; set; } = AllWeaponObjId.Captain_Ultima_Sword;

        [DisplayName("Seven-Star Sword")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Captain_Seven_Star_Sword)]
        public AllWeaponObjId Swap_SevenStarSword { get; set; } = AllWeaponObjId.Captain_Seven_Star_Sword;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Sword of Eos, the Star Key")]
        [Category("Effect Swap")]
        [DefaultValue(CaptainEffectWeaponObjId.Ascension)]
        public CaptainEffectWeaponObjId EffectSwap_SwordOfEos { get; set; } = CaptainEffectWeaponObjId.Ascension;

        [DisplayName("Seven-Star Sword, Celestial")]
        [Category("Effect Swap")]
        [DefaultValue(CaptainEffectWeaponObjId.Terminus)]
        public CaptainEffectWeaponObjId EffectSwap_SevenStarSword { get; set; } = CaptainEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Sword of Eos, the Star Key")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_SwordOfEos { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Seven-Star Sword, Celestial")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_SevenStarSword { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class KatalinaConfig : Configurable<KatalinaConfig> // 0200
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Rukalsa")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(KatalinaWeaponObjId.Rukalsa)]
        public KatalinaWeaponObjId Swap_Rukalsa { get; set; } = KatalinaWeaponObjId.Rukalsa;

        [DisplayName("Flame Rapier")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(KatalinaWeaponObjId.Flame_Rapier)]
        public KatalinaWeaponObjId Swap_FlameRapier { get; set; } = KatalinaWeaponObjId.Flame_Rapier;

        [DisplayName("Murgleis")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(KatalinaWeaponObjId.Murgleis)]
        public KatalinaWeaponObjId Swap_Murgleis { get; set; } = KatalinaWeaponObjId.Murgleis;

        [DisplayName("Luminiera Sword Omega")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(KatalinaWeaponObjId.Luminiera_Sword_Omega)]
        public KatalinaWeaponObjId Swap_LuminieraSwordOmega { get; set; } = KatalinaWeaponObjId.Luminiera_Sword_Omega;

        [DisplayName("Ephemeron")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(KatalinaWeaponObjId.Ephemeron)]
        public KatalinaWeaponObjId Swap_Ephemeron { get; set; } = KatalinaWeaponObjId.Ephemeron;

        [DisplayName("Blutgang")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(KatalinaWeaponObjId.Blutgang)]
        public KatalinaWeaponObjId Swap_Blutgang { get; set; } = KatalinaWeaponObjId.Blutgang;
#else
        [DisplayName("Rukalsa")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Katalina_Rukalsa)]
        public AllWeaponObjId Swap_Rukalsa { get; set; } = AllWeaponObjId.Katalina_Rukalsa;

        [DisplayName("Flame Rapier")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Katalina_Flame_Rapier)]
        public AllWeaponObjId Swap_FlameRapier { get; set; } = AllWeaponObjId.Katalina_Flame_Rapier;

        [DisplayName("Murgleis")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Katalina_Murgleis)]
        public AllWeaponObjId Swap_Murgleis { get; set; } = AllWeaponObjId.Katalina_Murgleis;

        [DisplayName("Luminiera Sword Omega")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Katalina_Luminiera_Sword_Omega)]
        public AllWeaponObjId Swap_LuminieraSwordOmega { get; set; } = AllWeaponObjId.Katalina_Luminiera_Sword_Omega;

        [DisplayName("Ephemeron")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Katalina_Ephemeron)]
        public AllWeaponObjId Swap_Ephemeron { get; set; } = AllWeaponObjId.Katalina_Ephemeron;

        [DisplayName("Blutgang")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Katalina_Blutgang)]
        public AllWeaponObjId Swap_Blutgang { get; set; } = AllWeaponObjId.Katalina_Blutgang;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Murgleis, the Azure Oath")]
        [Category("Effect Swap")]
        [DefaultValue(KatalinaEffectWeaponObjId.Ascension)]
        public KatalinaEffectWeaponObjId EffectSwap_Murgleis { get; set; } = KatalinaEffectWeaponObjId.Ascension;

        [DisplayName("Blutgang, Blade of Refuge")]
        [Category("Effect Swap")]
        [DefaultValue(KatalinaEffectWeaponObjId.Terminus)]
        public KatalinaEffectWeaponObjId EffectSwap_Blutgang { get; set; } = KatalinaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Murgleis, the Azure Oath")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Murgleis { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Blutgang, Blade of Refuge")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Blutgang { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class RackamConfig : Configurable<RackamConfig> // 0300
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Flintspike")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(RackamWeaponObjId.Flintspike)]
        public RackamWeaponObjId Swap_Flintspike { get; set; } = RackamWeaponObjId.Flintspike;

        [DisplayName("Wheellock Axe")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(RackamWeaponObjId.Wheellock_Axe)]
        public RackamWeaponObjId Swap_WheellockAxe { get; set; } = RackamWeaponObjId.Wheellock_Axe;

        [DisplayName("Benedia")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(RackamWeaponObjId.Benedia)]
        public RackamWeaponObjId Swap_Benedia { get; set; } = RackamWeaponObjId.Benedia;

        [DisplayName("Tiamat Bolt Omega")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(RackamWeaponObjId.Tiamat_Bolt_Omega)]
        public RackamWeaponObjId Swap_TiamatBoltOmega { get; set; } = RackamWeaponObjId.Tiamat_Bolt_Omega;

        [DisplayName("Stormcloud")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(RackamWeaponObjId.Stormcloud)]
        public RackamWeaponObjId Swap_Stormcloud { get; set; } = RackamWeaponObjId.Stormcloud;

        [DisplayName("Freikugel")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(RackamWeaponObjId.Freikugel)]
        public RackamWeaponObjId Swap_Freikugel { get; set; } = RackamWeaponObjId.Freikugel;
#else
        [DisplayName("Flintspike")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Rackam_Flintspike)]
        public AllWeaponObjId Swap_Flintspike { get; set; } = AllWeaponObjId.Rackam_Flintspike;

        [DisplayName("Wheellock Axe")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Rackam_Wheellock_Axe)]
        public AllWeaponObjId Swap_WheellockAxe { get; set; } = AllWeaponObjId.Rackam_Wheellock_Axe;

        [DisplayName("Benedia")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Rackam_Benedia)]
        public AllWeaponObjId Swap_Benedia { get; set; } = AllWeaponObjId.Rackam_Benedia;

        [DisplayName("Tiamat Bolt Omega")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Rackam_Tiamat_Bolt_Omega)]
        public AllWeaponObjId Swap_TiamatBoltOmega { get; set; } = AllWeaponObjId.Rackam_Tiamat_Bolt_Omega;

        [DisplayName("Stormcloud")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Rackam_Stormcloud)]
        public AllWeaponObjId Swap_Stormcloud { get; set; } = AllWeaponObjId.Rackam_Stormcloud;

        [DisplayName("Freikugel")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Rackam_Freikugel)]
        public AllWeaponObjId Swap_Freikugel { get; set; } = AllWeaponObjId.Rackam_Freikugel;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Benedia, Azure Ammunition")]
        [Category("Effect Swap")]
        [DefaultValue(RackamEffectWeaponObjId.Ascension)]
        public RackamEffectWeaponObjId EffectSwap_Benedia { get; set; } = RackamEffectWeaponObjId.Ascension;

        [DisplayName("Freikugel, the Purifier")]
        [Category("Effect Swap")]
        [DefaultValue(RackamEffectWeaponObjId.Terminus)]
        public RackamEffectWeaponObjId EffectSwap_Freikugel { get; set; } = RackamEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Benedia, Azure Ammunition")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Benedia { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Freikugel, the Purifier")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Freikugel { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class IoConfig : Configurable<IoConfig> // 0400
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Little Witch Scepter")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(IoWeaponObjId.Little_Witch_Scepter)]
        public IoWeaponObjId Swap_LittleWitchScepter { get; set; } = IoWeaponObjId.Little_Witch_Scepter;

        [DisplayName("Zhezl")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(IoWeaponObjId.Zhezl)]
        public IoWeaponObjId Swap_Zhezl { get; set; } = IoWeaponObjId.Zhezl;

        [DisplayName("Gambanteinn")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(IoWeaponObjId.Gambanteinn)]
        public IoWeaponObjId Swap_Gambanteinn { get; set; } = IoWeaponObjId.Gambanteinn;

        [DisplayName("Colossus Cane Omega")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(IoWeaponObjId.Colossus_Cane_Omega)]
        public IoWeaponObjId Swap_ColossusCaneOmega { get; set; } = IoWeaponObjId.Colossus_Cane_Omega;

        [DisplayName("Tupsmati")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(IoWeaponObjId.Tupsimati)]
        public IoWeaponObjId Swap_Tupsimati { get; set; } = IoWeaponObjId.Tupsimati;

        [DisplayName("Caduceus")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(IoWeaponObjId.Caduceus)]
        public IoWeaponObjId Swap_Caduceus { get; set; } = IoWeaponObjId.Caduceus;
#else
        [DisplayName("Little Witch Scepter")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Io_Little_Witch_Scepter)]
        public AllWeaponObjId Swap_LittleWitchScepter { get; set; } = AllWeaponObjId.Io_Little_Witch_Scepter;

        [DisplayName("Zhezl")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Io_Zhezl)]
        public AllWeaponObjId Swap_Zhezl { get; set; } = AllWeaponObjId.Io_Zhezl;

        [DisplayName("Gambanteinn")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Io_Gambanteinn)]
        public AllWeaponObjId Swap_Gambanteinn { get; set; } = AllWeaponObjId.Io_Gambanteinn;

        [DisplayName("Colossus Cane Omega")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Io_Colossus_Cane_Omega)]
        public AllWeaponObjId Swap_ColossusCaneOmega { get; set; } = AllWeaponObjId.Io_Colossus_Cane_Omega;

        [DisplayName("Tupsmati")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Io_Tupsimati)]
        public AllWeaponObjId Swap_Tupsimati { get; set; } = AllWeaponObjId.Io_Tupsimati;

        [DisplayName("Caduceus")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Io_Caduceus)]
        public AllWeaponObjId Swap_Caduceus { get; set; } = AllWeaponObjId.Io_Caduceus;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Gambanteinn, Staff of Hope")]
        [Category("Effect Swap")]
        [DefaultValue(IoEffectWeaponObjId.Ascension)]
        public IoEffectWeaponObjId EffectSwap_Gambanteinn { get; set; } = IoEffectWeaponObjId.Ascension;

        [DisplayName("Caduceus, Immortal Coil")]
        [Category("Effect Swap")]
        [DefaultValue(IoEffectWeaponObjId.Terminus)]
        public IoEffectWeaponObjId EffectSwap_Caduceus { get; set; } = IoEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Gambanteinn, Staff of Hope")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Gambanteinn { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Caduceus, Immortal Coil")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Caduceus { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class EugenConfig : Configurable<EugenConfig> // 0500
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Dreyse")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(EugenWeaponObjId.Dreyse)]
        public EugenWeaponObjId Swap_Dreyse { get; set; } = EugenWeaponObjId.Dreyse;

        [DisplayName("Matchlock")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(EugenWeaponObjId.Matchlock)]
        public EugenWeaponObjId Swap_Matchlock { get; set; } = EugenWeaponObjId.Matchlock;

        [DisplayName("AK-4A")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(EugenWeaponObjId.AK4A)]
        public EugenWeaponObjId Swap_AK4A { get; set; } = EugenWeaponObjId.AK4A;

        [DisplayName("Leviathan Muzzle")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(EugenWeaponObjId.Leviathan_Muzzle)]
        public EugenWeaponObjId Swap_LeviathanMuzzle { get; set; } = EugenWeaponObjId.Leviathan_Muzzle;

        [DisplayName("Clarion")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(EugenWeaponObjId.Clarion)]
        public EugenWeaponObjId Swap_Clarion { get; set; } = EugenWeaponObjId.Clarion;

        [DisplayName("Draconic Fire")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(EugenWeaponObjId.Draconic_Fire)]
        public EugenWeaponObjId Swap_DraconicFire { get; set; } = EugenWeaponObjId.Draconic_Fire;
#else
        [DisplayName("Dreyse")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Eugen_Dreyse)]
        public AllWeaponObjId Swap_Dreyse { get; set; } = AllWeaponObjId.Eugen_Dreyse;

        [DisplayName("Matchlock")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Eugen_Matchlock)]
        public AllWeaponObjId Swap_Matchlock { get; set; } = AllWeaponObjId.Eugen_Matchlock;

        [DisplayName("AK-4A")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Eugen_AK4A)]
        public AllWeaponObjId Swap_AK4A { get; set; } = AllWeaponObjId.Eugen_AK4A;

        [DisplayName("Leviathan Muzzle")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Eugen_Leviathan_Muzzle)]
        public AllWeaponObjId Swap_LeviathanMuzzle { get; set; } = AllWeaponObjId.Eugen_Leviathan_Muzzle;

        [DisplayName("Clarion")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Eugen_Clarion)]
        public AllWeaponObjId Swap_Clarion { get; set; } = AllWeaponObjId.Eugen_Clarion;

        [DisplayName("Draconic Fire")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Eugen_Draconic_Fire)]
        public AllWeaponObjId Swap_DraconicFire { get; set; } = AllWeaponObjId.Eugen_Draconic_Fire;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("AK-4A, the Suppressor")]
        [Category("Effect Swap")]
        [DefaultValue(EugenEffectWeaponObjId.Ascension)]
        public EugenEffectWeaponObjId EffectSwap_AK4A { get; set; } = EugenEffectWeaponObjId.Ascension;

        [DisplayName("Draconic Fire, Charring Breath")]
        [Category("Effect Swap")]
        [DefaultValue(EugenEffectWeaponObjId.Terminus)]
        public EugenEffectWeaponObjId EffectSwap_DraconicFire { get; set; } = EugenEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("AK-4A, the Suppressor")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_AK4A { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Draconic Fire, Charring Breath")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_DraconicFire { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class RosettaConfig : Configurable<RosettaConfig> // 0600
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Egoism")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(RosettaWeaponObjId.Egoism)]
        public RosettaWeaponObjId Swap_Egoism { get; set; } = RosettaWeaponObjId.Egoism;

        [DisplayName("Swordbreaker")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(RosettaWeaponObjId.Swordbreaker)]
        public RosettaWeaponObjId Swap_Swordbreaker { get; set; } = RosettaWeaponObjId.Swordbreaker;

        [DisplayName("Love Eternal")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(RosettaWeaponObjId.Love_Eternal)]
        public RosettaWeaponObjId Swap_LoveEternal { get; set; } = RosettaWeaponObjId.Love_Eternal;

        [DisplayName("Rose Crystal Knife")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(RosettaWeaponObjId.Rose_Crystal_Knife)]
        public RosettaWeaponObjId Swap_RoseCrystalKnife { get; set; } = RosettaWeaponObjId.Rose_Crystal_Knife;

        [DisplayName("Cortana")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(RosettaWeaponObjId.Cortana)]
        public RosettaWeaponObjId Swap_Cortana { get; set; } = RosettaWeaponObjId.Cortana;

        [DisplayName("Dragger of Bahamut Coda")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(RosettaWeaponObjId.Dagger_of_Bahamut_Coda)]
        public RosettaWeaponObjId Swap_DaggerofBahamutCoda { get; set; } = RosettaWeaponObjId.Dagger_of_Bahamut_Coda;
#else
        [DisplayName("Egoism")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Rosetta_Egoism)]
        public AllWeaponObjId Swap_Egoism { get; set; } = AllWeaponObjId.Rosetta_Egoism;

        [DisplayName("Swordbreaker")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Rosetta_Swordbreaker)]
        public AllWeaponObjId Swap_Swordbreaker { get; set; } = AllWeaponObjId.Rosetta_Swordbreaker;

        [DisplayName("Love Eternal")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Rosetta_Love_Eternal)]
        public AllWeaponObjId Swap_LoveEternal { get; set; } = AllWeaponObjId.Rosetta_Love_Eternal;

        [DisplayName("Rose Crystal Knife")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Rosetta_Rose_Crystal_Knife)]
        public AllWeaponObjId Swap_RoseCrystalKnife { get; set; } = AllWeaponObjId.Rosetta_Rose_Crystal_Knife;

        [DisplayName("Cortana")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Rosetta_Cortana)]
        public AllWeaponObjId Swap_Cortana { get; set; } = AllWeaponObjId.Rosetta_Cortana;

        [DisplayName("Dragger of Bahamut Coda")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Rosetta_Dagger_of_Bahamut_Coda)]
        public AllWeaponObjId Swap_DaggerofBahamutCoda { get; set; } = AllWeaponObjId.Rosetta_Dagger_of_Bahamut_Coda;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Love Eternal, Forevermore")]
        [Category("Effect Swap")]
        [DefaultValue(RosettaEffectWeaponObjId.Ascension)]
        public RosettaEffectWeaponObjId EffectSwap_LoveEternal { get; set; } = RosettaEffectWeaponObjId.Ascension;

        [DisplayName("Cortana")]
        [Category("Effect Swap")]
        [DefaultValue(RosettaEffectWeaponObjId.Flame)]
        public RosettaEffectWeaponObjId EffectSwap_Cortana { get; set; } = RosettaEffectWeaponObjId.Flame;

        [DisplayName("Primal Dagger of Bahamut Coda")]
        [Category("Effect Swap")]
        [DefaultValue(RosettaEffectWeaponObjId.Terminus)]
        public RosettaEffectWeaponObjId EffectSwap_DaggerOfBahamutCoda { get; set; } = RosettaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Love Eternal, Forevermore")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_LoveEternal { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Cortana")]
        [Category("Effect Control")]
        [Description("Can only be toggled on or off")]
        [DefaultValue(WeaponEffectToggle.Enabled)]
        public WeaponEffectToggle EffectControl_Cortana { get; set; } = WeaponEffectToggle.Enabled;

        [DisplayName("Primal Dagger of Bahamut Coda")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_DaggerOfBahamutCoda { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class FerryConfig : Configurable<FerryConfig> // 0700
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Geisterpeitche")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(FerryWeaponObjId.Geisterpeitche)]
        public FerryWeaponObjId Swap_Geisterpeitche { get; set; } = FerryWeaponObjId.Geisterpeitche;

        [DisplayName("Leather Belt")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(FerryWeaponObjId.Leather_Belt)]
        public FerryWeaponObjId Swap_LeatherBelt { get; set; } = FerryWeaponObjId.Leather_Belt;

        [DisplayName("Ethereal Lasher")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(FerryWeaponObjId.Ethereal_Lasher)]
        public FerryWeaponObjId Swap_EtherealLasher { get; set; } = FerryWeaponObjId.Ethereal_Lasher;

        [DisplayName("Flame Lit Curl")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(FerryWeaponObjId.Flame_Lit_Curl)]
        public FerryWeaponObjId Swap_FlameLitCurl { get; set; } = FerryWeaponObjId.Flame_Lit_Curl;

        [DisplayName("Live Wire")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(FerryWeaponObjId.Live_Wire)]
        public FerryWeaponObjId Swap_LiveWire { get; set; } = FerryWeaponObjId.Live_Wire;

        [DisplayName("Erinnerung")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(FerryWeaponObjId.Erinnerung)]
        public FerryWeaponObjId Swap_Erinnerung { get; set; } = FerryWeaponObjId.Erinnerung;
#else
        [DisplayName("Geisterpeitche")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Ferry_Geisterpeitche)]
        public AllWeaponObjId Swap_Geisterpeitche { get; set; } = AllWeaponObjId.Ferry_Geisterpeitche;

        [DisplayName("Leather Belt")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Ferry_Leather_Belt)]
        public AllWeaponObjId Swap_LeatherBelt { get; set; } = AllWeaponObjId.Ferry_Leather_Belt;

        [DisplayName("Ethereal Lasher")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Ferry_Ethereal_Lasher)]
        public AllWeaponObjId Swap_EtherealLasher { get; set; } = AllWeaponObjId.Ferry_Ethereal_Lasher;

        [DisplayName("Flame Lit Curl")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Ferry_Flame_Lit_Curl)]
        public AllWeaponObjId Swap_FlameLitCurl { get; set; } = AllWeaponObjId.Ferry_Flame_Lit_Curl;

        [DisplayName("Live Wire")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Ferry_Live_Wire)]
        public AllWeaponObjId Swap_LiveWire { get; set; } = AllWeaponObjId.Ferry_Live_Wire;

        [DisplayName("Erinnerung")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Ferry_Erinnerung)]
        public AllWeaponObjId Swap_Erinnerung { get; set; } = AllWeaponObjId.Ferry_Erinnerung;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Geisterpeitche")]
        [Category("Effect Swap")]
        [DefaultValue(FerryEffectWeaponObjId.Ghostly)]
        public FerryEffectWeaponObjId EffectSwap_Geisterpeitche { get; set; } = FerryEffectWeaponObjId.Ghostly;

        [DisplayName("Ethereal Lasher, Fleeting End")]
        [Category("Effect Swap")]
        [DefaultValue(FerryEffectWeaponObjId.Ascension)]
        public FerryEffectWeaponObjId EffectSwap_EtherealLasher { get; set; } = FerryEffectWeaponObjId.Ascension;

        [DisplayName("Flame Lit Curl")]
        [Category("Effect Swap")]
        [DefaultValue(FerryEffectWeaponObjId.Flame)]
        public FerryEffectWeaponObjId EffectSwap_FlameLitCurl { get; set; } = FerryEffectWeaponObjId.Flame;

        [DisplayName("Live Wire")]
        [Category("Effect Swap")]
        [DefaultValue(FerryEffectWeaponObjId.Electric)]
        public FerryEffectWeaponObjId EffectSwap_LiveWire { get; set; } = FerryEffectWeaponObjId.Electric;

        [DisplayName("Erinnerung, From Beyond")]
        [Category("Effect Swap")]
        [DefaultValue(FerryEffectWeaponObjId.Terminus)]
        public FerryEffectWeaponObjId EffectSwap_Erinnerung { get; set; } = FerryEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Geisterpeitche")]
        [Category("Effect Control")]
        [Description("Can only be toggled on or off")]
        [DefaultValue(WeaponEffectToggle.Enabled)]
        public WeaponEffectToggle EffectControl_Geisterpeitche { get; set; } = WeaponEffectToggle.Enabled;

        [DisplayName("Ethereal Lasher, Fleeting End")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_EtherealLasher { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Flame Lit Curl")]
        [Category("Effect Control")]
        [Description("Can only be toggled on or off")]
        [DefaultValue(WeaponEffectToggle.Enabled)]
        public WeaponEffectToggle EffectControl_FlameLitCurl { get; set; } = WeaponEffectToggle.Enabled;

        [DisplayName("Live Wire")]
        [Category("Effect Control")]
        [Description("Can only be toggled on or off")]
        [DefaultValue(WeaponEffectToggle.Enabled)]
        public WeaponEffectToggle EffectControl_LiveWire { get; set; } = WeaponEffectToggle.Enabled;

        [DisplayName("Erinnerung, From Beyond")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Erinnerung { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class LancelotConfig : Configurable<LancelotConfig> // 0800
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Altachiara")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(LancelotWeaponObjId.Altachiara)]
        public LancelotWeaponObjId Swap_Altachiara { get; set; } = LancelotWeaponObjId.Altachiara;

        [DisplayName("Hoarfrost Blade Persius")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(LancelotWeaponObjId.Hoarfrost_Blade_Persius)]
        public LancelotWeaponObjId Swap_HoarfrostBladePersius { get; set; } = LancelotWeaponObjId.Hoarfrost_Blade_Persius;

        [DisplayName("Blanc Comme Neige")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(LancelotWeaponObjId.Blanc_Comme_Neige)]
        public LancelotWeaponObjId Swap_BlancCommeNeige { get; set; } = LancelotWeaponObjId.Blanc_Comme_Neige;

        [DisplayName("Vegalta")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(LancelotWeaponObjId.Vegalta)]
        public LancelotWeaponObjId Swap_Vegalta { get; set; } = LancelotWeaponObjId.Vegalta;

        [DisplayName("Knight of Ice")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(LancelotWeaponObjId.Knight_of_Ice)]
        public LancelotWeaponObjId Swap_KnightOfIce { get; set; } = LancelotWeaponObjId.Knight_of_Ice;

        [DisplayName("Damascus Knife")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(LancelotWeaponObjId.Damascus_Knife)]
        public LancelotWeaponObjId Swap_DamascusKnife { get; set; } = LancelotWeaponObjId.Damascus_Knife;
#else
        [DisplayName("Altachiara")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Lancelot_Altachiara)]
        public AllWeaponObjId Swap_Altachiara { get; set; } = AllWeaponObjId.Lancelot_Altachiara;

        [DisplayName("Hoarfrost Blade Persius")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Lancelot_Hoarfrost_Blade_Persius)]
        public AllWeaponObjId Swap_HoarfrostBladePersius { get; set; } = AllWeaponObjId.Lancelot_Hoarfrost_Blade_Persius;

        [DisplayName("Blanc Comme Neige")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Lancelot_Blanc_Comme_Neige)]
        public AllWeaponObjId Swap_BlancCommeNeige { get; set; } = AllWeaponObjId.Lancelot_Blanc_Comme_Neige;

        [DisplayName("Vegalta")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Lancelot_Vegalta)]
        public AllWeaponObjId Swap_Vegalta { get; set; } = AllWeaponObjId.Lancelot_Vegalta;

        [DisplayName("Knight of Ice")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Lancelot_Knight_of_Ice)]
        public AllWeaponObjId Swap_KnightOfIce { get; set; } = AllWeaponObjId.Lancelot_Knight_of_Ice;

        [DisplayName("Damascus Knife")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Lancelot_Damascus_Knife)]
        public AllWeaponObjId Swap_DamascusKnife { get; set; } = AllWeaponObjId.Lancelot_Damascus_Knife;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Knight of Ice, the Silver Blur")]
        [Category("Effect Swap")]
        [DefaultValue(LancelotEffectWeaponObjId.Ascension)]
        public LancelotEffectWeaponObjId EffectSwap_KnightOfIce { get; set; } = LancelotEffectWeaponObjId.Ascension;

        [DisplayName("Damascus Knife, the Unseen")]
        [Category("Effect Swap")]
        [DefaultValue(LancelotEffectWeaponObjId.Terminus)]
        public LancelotEffectWeaponObjId EffectSwap_DamascusKnife { get; set; } = LancelotEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Knight of Ice, the Silver Blur")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_KnightOfIce { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Damascus Knife, the Unseen")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_DamascusKnife { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class VaneConfig : Configurable<VaneConfig> // 0900
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Alabarda")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(VaneWeaponObjId.Alabarda)]
        public VaneWeaponObjId Swap_Alabarda { get; set; } = VaneWeaponObjId.Alabarda;

        [DisplayName("Swan")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(VaneWeaponObjId.Swan)]
        public VaneWeaponObjId Swap_Swan { get; set; } = VaneWeaponObjId.Swan;

        [DisplayName("Treuer Krieger")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(VaneWeaponObjId.Treuer_Krieger)]
        public VaneWeaponObjId Swap_TreuerKrieger { get; set; } = VaneWeaponObjId.Treuer_Krieger;

        [DisplayName("Ukonvasara")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(VaneWeaponObjId.Ukonvasara)]
        public VaneWeaponObjId Swap_Ukonvasara { get; set; } = VaneWeaponObjId.Ukonvasara;

        [DisplayName("Blossom Axe")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(VaneWeaponObjId.Blossom_Axe)]
        public VaneWeaponObjId Swap_BlossomAxe { get; set; } = VaneWeaponObjId.Blossom_Axe;

        [DisplayName("Mjolnir")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(VaneWeaponObjId.Mjolnir)]
        public VaneWeaponObjId Swap_Mjolnir { get; set; } = VaneWeaponObjId.Mjolnir;
#else
        [DisplayName("Alabarda")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Vane_Alabarda)]
        public AllWeaponObjId Swap_Alabarda { get; set; } = AllWeaponObjId.Vane_Alabarda;

        [DisplayName("Swan")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Vane_Swan)]
        public AllWeaponObjId Swap_Swan { get; set; } = AllWeaponObjId.Vane_Swan;

        [DisplayName("Treuer Krieger")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Vane_Treuer_Krieger)]
        public AllWeaponObjId Swap_TreuerKrieger { get; set; } = AllWeaponObjId.Vane_Treuer_Krieger;

        [DisplayName("Ukonvasara")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Vane_Ukonvasara)]
        public AllWeaponObjId Swap_Ukonvasara { get; set; } = AllWeaponObjId.Vane_Ukonvasara;

        [DisplayName("Blossom Axe")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Vane_Blossom_Axe)]
        public AllWeaponObjId Swap_BlossomAxe { get; set; } = AllWeaponObjId.Vane_Blossom_Axe;

        [DisplayName("Mjolnir")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Vane_Mjolnir)]
        public AllWeaponObjId Swap_Mjolnir { get; set; } = AllWeaponObjId.Vane_Mjolnir;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Treuer Krieger, the Dauntless")]
        [Category("Effect Swap")]
        [DefaultValue(VaneEffectWeaponObjId.Ascension)]
        public VaneEffectWeaponObjId EffectSwap_TreuerKrieger { get; set; } = VaneEffectWeaponObjId.Ascension;

        [DisplayName("Mjolnir, Thunderous Crusher")]
        [Category("Effect Swap")]
        [DefaultValue(VaneEffectWeaponObjId.Terminus)]
        public VaneEffectWeaponObjId EffectSwap_Mjolnir { get; set; } = VaneEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Treuer Krieger, the Dauntless")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_TreuerKrieger { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Mjolnir, Thunderous Crusher")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Mjolnir { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class PercivalConfig : Configurable<PercivalConfig> // 1000
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Flamberge")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(PercivalWeaponObjId.Flamberge)]
        public PercivalWeaponObjId Swap_Flamberge { get; set; } = PercivalWeaponObjId.Flamberge;

        [DisplayName("Lohengrin")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(PercivalWeaponObjId.Lohengrin)]
        public PercivalWeaponObjId Swap_Lohengrin { get; set; } = PercivalWeaponObjId.Lohengrin;

        [DisplayName("Antwerp")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(PercivalWeaponObjId.Antwerp)]
        public PercivalWeaponObjId Swap_Antwerp { get; set; } = PercivalWeaponObjId.Antwerp;

        [DisplayName("Joyeuse")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(PercivalWeaponObjId.Joyeuse)]
        public PercivalWeaponObjId Swap_Joyeuse { get; set; } = PercivalWeaponObjId.Joyeuse;

        [DisplayName("Lord of Flames")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(PercivalWeaponObjId.Lord_of_Flames)]
        public PercivalWeaponObjId Swap_LordOfFlames { get; set; } = PercivalWeaponObjId.Lord_of_Flames;

        [DisplayName("Gottfried")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(PercivalWeaponObjId.Gottfried)]
        public PercivalWeaponObjId Swap_Gottfried { get; set; } = PercivalWeaponObjId.Gottfried;
#else
        [DisplayName("Flamberge")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Percival_Flamberge)]
        public AllWeaponObjId Swap_Flamberge { get; set; } = AllWeaponObjId.Percival_Flamberge;

        [DisplayName("Lohengrin")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Percival_Lohengrin)]
        public AllWeaponObjId Swap_Lohengrin { get; set; } = AllWeaponObjId.Percival_Lohengrin;

        [DisplayName("Antwerp")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Percival_Antwerp)]
        public AllWeaponObjId Swap_Antwerp { get; set; } = AllWeaponObjId.Percival_Antwerp;

        [DisplayName("Joyeuse")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Percival_Joyeuse)]
        public AllWeaponObjId Swap_Joyeuse { get; set; } = AllWeaponObjId.Percival_Joyeuse;

        [DisplayName("Lord of Flames")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Percival_Lord_of_Flames)]
        public AllWeaponObjId Swap_LordOfFlames { get; set; } = AllWeaponObjId.Percival_Lord_of_Flames;

        [DisplayName("Gottfried")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Percival_Gottfried)]
        public AllWeaponObjId Swap_Gottfried { get; set; } = AllWeaponObjId.Percival_Gottfried;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Lord of Flames, Exalted Reign")]
        [Category("Effect Swap")]
        [DefaultValue(PercivalEffectWeaponObjId.Ascension)]
        public PercivalEffectWeaponObjId EffectSwap_LordOfFlames { get; set; } = PercivalEffectWeaponObjId.Ascension;

        [DisplayName("Gottfried, the White Fang")]
        [Category("Effect Swap")]
        [DefaultValue(PercivalEffectWeaponObjId.Terminus)]
        public PercivalEffectWeaponObjId EffectSwap_Gottfried { get; set; } = PercivalEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Lord of Flames, Exalted Reign")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_LordOfFlames { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Gottfried, the White Fang")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Gottfried { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class SiegfriedConfig : Configurable<SiegfriedConfig> // 1100
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Integrity")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(SiegfriedWeaponObjId.Integrity)]
        public SiegfriedWeaponObjId Swap_Integrity { get; set; } = SiegfriedWeaponObjId.Integrity;

        [DisplayName("Broadsword of Earth")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(SiegfriedWeaponObjId.Broadsword_of_Earth)]
        public SiegfriedWeaponObjId Swap_BroadswordofEarth { get; set; } = SiegfriedWeaponObjId.Broadsword_of_Earth;

        [DisplayName("Ascalon")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(SiegfriedWeaponObjId.Ascalon)]
        public SiegfriedWeaponObjId Swap_Ascalon { get; set; } = SiegfriedWeaponObjId.Ascalon;

        [DisplayName("Hrunting")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(SiegfriedWeaponObjId.Hrunting)]
        public SiegfriedWeaponObjId Swap_Hrunting { get; set; } = SiegfriedWeaponObjId.Hrunting;

        [DisplayName("Windhose")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(SiegfriedWeaponObjId.Windhose)]
        public SiegfriedWeaponObjId Swap_Windhose { get; set; } = SiegfriedWeaponObjId.Windhose;

        [DisplayName("Balmung")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(SiegfriedWeaponObjId.Balmung)]
        public SiegfriedWeaponObjId Swap_Balmung { get; set; } = SiegfriedWeaponObjId.Balmung;
#else
        [DisplayName("Integrity")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Siegfried_Integrity)]
        public AllWeaponObjId Swap_Integrity { get; set; } = AllWeaponObjId.Siegfried_Integrity;

        [DisplayName("Broadsword of Earth")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Siegfried_Broadsword_of_Earth)]
        public AllWeaponObjId Swap_BroadswordofEarth { get; set; } = AllWeaponObjId.Siegfried_Broadsword_of_Earth;

        [DisplayName("Ascalon")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Siegfried_Ascalon)]
        public AllWeaponObjId Swap_Ascalon { get; set; } = AllWeaponObjId.Siegfried_Ascalon;

        [DisplayName("Hrunting")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Siegfried_Hrunting)]
        public AllWeaponObjId Swap_Hrunting { get; set; } = AllWeaponObjId.Siegfried_Hrunting;

        [DisplayName("Windhose")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Siegfried_Windhose)]
        public AllWeaponObjId Swap_Windhose { get; set; } = AllWeaponObjId.Siegfried_Windhose;

        [DisplayName("Balmung")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Siegfried_Balmung)]
        public AllWeaponObjId Swap_Balmung { get; set; } = AllWeaponObjId.Siegfried_Balmung;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Ascalon, Dragon's Bane")]
        [Category("Effect Swap")]
        [DefaultValue(SiegfriedEffectWeaponObjId.Ascension)]
        public SiegfriedEffectWeaponObjId EffectSwap_Ascalon { get; set; } = SiegfriedEffectWeaponObjId.Ascension;

        [DisplayName("Balmung, the Blue Blaze")]
        [Category("Effect Swap")]
        [DefaultValue(SiegfriedEffectWeaponObjId.Terminus)]
        public SiegfriedEffectWeaponObjId EffectSwap_Balmung { get; set; } = SiegfriedEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Ascalon, Dragon's Bane")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Ascalon { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Balmung, the Blue Blaze")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Balmung { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class CharlottaConfig : Configurable<CharlottaConfig> // 1200
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Claiomh Solais")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(CharlottaWeaponObjId.Claiomh_Solais)]
        public CharlottaWeaponObjId Swap_ClaiomhSolais { get; set; } = CharlottaWeaponObjId.Claiomh_Solais;

        [DisplayName("Arondight")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(CharlottaWeaponObjId.Arondight)]
        public CharlottaWeaponObjId Swap_Arondight { get; set; } = CharlottaWeaponObjId.Arondight;

        [DisplayName("Claidheamh Soluis")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(CharlottaWeaponObjId.Claidheamh_Soluis)]
        public CharlottaWeaponObjId Swap_ClaidheamhSoluis { get; set; } = CharlottaWeaponObjId.Claidheamh_Soluis;

        [DisplayName("Ushumgal")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(CharlottaWeaponObjId.Ushumgal)]
        public CharlottaWeaponObjId Swap_Ushumgal { get; set; } = CharlottaWeaponObjId.Ushumgal;

        [DisplayName("Sahrivar")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(CharlottaWeaponObjId.Sahrivar)]
        public CharlottaWeaponObjId Swap_Sahrivar { get; set; } = CharlottaWeaponObjId.Sahrivar;

        [DisplayName("Galatine")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(CharlottaWeaponObjId.Galatine)]
        public CharlottaWeaponObjId Swap_Galatine { get; set; } = CharlottaWeaponObjId.Galatine;
#else
        [DisplayName("Claiomh Solais")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Charlotta_Claiomh_Solais)]
        public AllWeaponObjId Swap_ClaiomhSolais { get; set; } = AllWeaponObjId.Charlotta_Claiomh_Solais;

        [DisplayName("Arondight")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Charlotta_Arondight)]
        public AllWeaponObjId Swap_Arondight { get; set; } = AllWeaponObjId.Charlotta_Arondight;

        [DisplayName("Claidheamh Soluis")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Charlotta_Claidheamh_Soluis)]
        public AllWeaponObjId Swap_ClaidheamhSoluis { get; set; } = AllWeaponObjId.Charlotta_Claidheamh_Soluis;

        [DisplayName("Ushumgal")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Charlotta_Ushumgal)]
        public AllWeaponObjId Swap_Ushumgal { get; set; } = AllWeaponObjId.Charlotta_Ushumgal;

        [DisplayName("Sahrivar")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Charlotta_Sahrivar)]
        public AllWeaponObjId Swap_Sahrivar { get; set; } = AllWeaponObjId.Charlotta_Sahrivar;

        [DisplayName("Galatine")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Charlotta_Galatine)]
        public AllWeaponObjId Swap_Galatine { get; set; } = AllWeaponObjId.Charlotta_Galatine;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Claidheamh Soluis, the Radiant")]
        [Category("Effect Swap")]
        [DefaultValue(CharlottaEffectWeaponObjId.Ascension)]
        public CharlottaEffectWeaponObjId EffectSwap_Claidheamh { get; set; } = CharlottaEffectWeaponObjId.Ascension;

        [DisplayName("Galatine, Trinity's Wrath")]
        [Category("Effect Swap")]
        [DefaultValue(CharlottaEffectWeaponObjId.Terminus)]
        public CharlottaEffectWeaponObjId EffectSwap_Galatine { get; set; } = CharlottaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Claidheamh Soluis, the Radiant")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Claidheamh { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Galatine, Trinity's Wrath")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Galatine { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class YodarhaConfig : Configurable<YodarhaConfig> // 1300
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Kiku-Ichimonji")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(YodarhaWeaponObjId.Kiku_Ichimonji)]
        public YodarhaWeaponObjId Swap_KikuIchimonji { get; set; } = YodarhaWeaponObjId.Kiku_Ichimonji;

        [DisplayName("Asura")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(YodarhaWeaponObjId.Asura)]
        public YodarhaWeaponObjId Swap_Asura { get; set; } = YodarhaWeaponObjId.Asura;

        [DisplayName("Fudo-Kuniyuki")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(YodarhaWeaponObjId.Fudo_Kuniyuki)]
        public YodarhaWeaponObjId Swap_FudoKuniyuki { get; set; } = YodarhaWeaponObjId.Fudo_Kuniyuki;

        [DisplayName("Higurashi")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(YodarhaWeaponObjId.Higurashi)]
        public YodarhaWeaponObjId Swap_Higurashi { get; set; } = YodarhaWeaponObjId.Higurashi;

        [DisplayName("Xeno Phantom Demon Blade")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(YodarhaWeaponObjId.Xeno_Phantom_Demon_Blade)]
        public YodarhaWeaponObjId Swap_XenoPhantomDemonBlade { get; set; } = YodarhaWeaponObjId.Xeno_Phantom_Demon_Blade;

        [DisplayName("Swordfish")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(YodarhaWeaponObjId.Swordfish)]
        public YodarhaWeaponObjId Swap_Swordfish { get; set; } = YodarhaWeaponObjId.Swordfish;
#else
        [DisplayName("Kiku-Ichimonji")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Yodarha_Kiku_Ichimonji)]
        public AllWeaponObjId Swap_KikuIchimonji { get; set; } = AllWeaponObjId.Yodarha_Kiku_Ichimonji;

        [DisplayName("Asura")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Yodarha_Asura)]
        public AllWeaponObjId Swap_Asura { get; set; } = AllWeaponObjId.Yodarha_Asura;

        [DisplayName("Fudo-Kuniyuki")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Yodarha_Fudo_Kuniyuki)]
        public AllWeaponObjId Swap_FudoKuniyuki { get; set; } = AllWeaponObjId.Yodarha_Fudo_Kuniyuki;

        [DisplayName("Higurashi")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Yodarha_Higurashi)]
        public AllWeaponObjId Swap_Higurashi { get; set; } = AllWeaponObjId.Yodarha_Higurashi;

        [DisplayName("Xeno Phantom Demon Blade")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Yodarha_Xeno_Phantom_Demon_Blade)]
        public AllWeaponObjId Swap_XenoPhantomDemonBlade { get; set; } = AllWeaponObjId.Yodarha_Xeno_Phantom_Demon_Blade;

        [DisplayName("Swordfish")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Yodarha_Swordfish)]
        public AllWeaponObjId Swap_Swordfish { get; set; } = AllWeaponObjId.Yodarha_Swordfish;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Fudo-Kuniyuki, Scarlet Glory")]
        [Category("Effect Swap")]
        [DefaultValue(YodarhaEffectWeaponObjId.Ascension)]
        public YodarhaEffectWeaponObjId EffectSwap_FudoKuniyuki { get; set; } = YodarhaEffectWeaponObjId.Ascension;

        [DisplayName("Swordfish, Tipper of Scales")]
        [Category("Effect Swap")]
        [DefaultValue(YodarhaEffectWeaponObjId.Terminus)]
        public YodarhaEffectWeaponObjId EffectSwap_Swordfish { get; set; } = YodarhaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Fudo-Kuniyuki, Scarlet Glory")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_FudoKuniyuki { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Swordfish, Tipper of Scales")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Swordfish { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class NarmayaConfig : Configurable<NarmayaConfig> // 1400
    {
        #region Sheath Swap
        [DisplayName("Enable Sheath Swapping")]
        [Category("Sheath Swap")]
        [DefaultValue(false)]
        [Description("\nONLY USE IF SWAPPING A SINGLE WEAPON FOR NARMAYA.\n\n" +
            "Will literally swap 2 sheaths. The one being used as a skin will be changed to the one you are replacing.\n" +
            "If you try using this while swapping more than 1 Narmaya weapon results will vary.\n\n" +
            "Will not work if you have a modded Narmaya player model.\n")]
        public bool SheathSwapToggle { get; set; } = false;
        #endregion

        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Nakamaki Nodachi")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(NarmayaWeaponObjId.Nakamaki_Nodachi)]
        public NarmayaWeaponObjId Swap_NakamakiNodachi { get; set; } = NarmayaWeaponObjId.Nakamaki_Nodachi;

        [DisplayName("Kotetsu")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(NarmayaWeaponObjId.Kotetsu)]
        public NarmayaWeaponObjId Swap_Kotetsu { get; set; } = NarmayaWeaponObjId.Kotetsu;

        [DisplayName("Venustas")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(NarmayaWeaponObjId.Venustas)]
        public NarmayaWeaponObjId Swap_Venustas { get; set; } = NarmayaWeaponObjId.Venustas;

        [DisplayName("Flourithium Blade")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(NarmayaWeaponObjId.Flourithium_Blade)]
        public NarmayaWeaponObjId Swap_Flourithium_Blade { get; set; } = NarmayaWeaponObjId.Flourithium_Blade;

        [DisplayName("Blade of Purification")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(NarmayaWeaponObjId.Blade_of_Purification)]
        public NarmayaWeaponObjId Swap_BladeofPurification { get; set; } = NarmayaWeaponObjId.Blade_of_Purification;

        [DisplayName("Ameno Habakiri")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(NarmayaWeaponObjId.Ameno_Habakiri)]
        public NarmayaWeaponObjId Swap_AmenoHabakiri { get; set; } = NarmayaWeaponObjId.Ameno_Habakiri;
#else
        [DisplayName("Nakamaki Nodachi")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Narmaya_Nakamaki_Nodachi)]
        public AllWeaponObjId Swap_NakamakiNodachi { get; set; } = AllWeaponObjId.Narmaya_Nakamaki_Nodachi;

        [DisplayName("Kotetsu")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Narmaya_Kotetsu)]
        public AllWeaponObjId Swap_Kotetsu { get; set; } = AllWeaponObjId.Narmaya_Kotetsu;

        [DisplayName("Venustas")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Narmaya_Venustas)]
        public AllWeaponObjId Swap_Venustas { get; set; } = AllWeaponObjId.Narmaya_Venustas;

        [DisplayName("Flourithium Blade")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Narmaya_Flourithium_Blade)]
        public AllWeaponObjId Swap_Flourithium_Blade { get; set; } = AllWeaponObjId.Narmaya_Flourithium_Blade;

        [DisplayName("Blade of Purification")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Narmaya_Blade_of_Purification)]
        public AllWeaponObjId Swap_BladeofPurification { get; set; } = AllWeaponObjId.Narmaya_Blade_of_Purification;

        [DisplayName("Ameno Habakiri")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Narmaya_Ameno_Habakiri)]
        public AllWeaponObjId Swap_AmenoHabakiri { get; set; } = AllWeaponObjId.Narmaya_Ameno_Habakiri;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Venustas, the Sacred Gift")]
        [Category("Effect Swap")]
        [DefaultValue(NarmayaEffectWeaponObjId.Ascension)]
        public NarmayaEffectWeaponObjId EffectSwap_Venustas { get; set; } = NarmayaEffectWeaponObjId.Ascension;

        [DisplayName("Ameno Habakiri, the Beheader")]
        [Category("Effect Swap")]
        [DefaultValue(NarmayaEffectWeaponObjId.Terminus)]
        public NarmayaEffectWeaponObjId EffectSwap_AmenoHabakiri { get; set; } = NarmayaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Venustas, the Sacred Gift")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Venustas { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Ameno Habakiri, the Beheader")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_AmenoHabakiri { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class GhandagozaConfig : Configurable<GhandagozaConfig> // 1500
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Brahma Gauntlet")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(GhandagozaWeaponObjId.Brahma_Gauntlet)]
        public GhandagozaWeaponObjId Swap_BrahmaGauntlet { get; set; } = GhandagozaWeaponObjId.Brahma_Gauntlet;

        [DisplayName("Rope Knuckles")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(GhandagozaWeaponObjId.Rope_Knuckles)]
        public GhandagozaWeaponObjId Swap_RopeKnuckles { get; set; } = GhandagozaWeaponObjId.Rope_Knuckles;

        [DisplayName("Crimson Finger")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(GhandagozaWeaponObjId.Crimson_Finger)]
        public GhandagozaWeaponObjId Swap_CrimsonFinger { get; set; } = GhandagozaWeaponObjId.Crimson_Finger;

        [DisplayName("Golden Fists of Ura")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(GhandagozaWeaponObjId.Golden_Fists_of_Ura)]
        public GhandagozaWeaponObjId Swap_GoldenFistsOfUra { get; set; } = GhandagozaWeaponObjId.Golden_Fists_of_Ura;

        [DisplayName("Arkab")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(GhandagozaWeaponObjId.Arkab)]
        public GhandagozaWeaponObjId Swap_Arkab { get; set; } = GhandagozaWeaponObjId.Arkab;

        [DisplayName("Sky Piercer")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(GhandagozaWeaponObjId.Sky_Piercer)]
        public GhandagozaWeaponObjId Swap_SkyPiercer { get; set; } = GhandagozaWeaponObjId.Sky_Piercer;
#else
        [DisplayName("Brahma Gauntlet")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Ghandagoza_Brahma_Gauntlet)]
        public AllWeaponObjId Swap_BrahmaGauntlet { get; set; } = AllWeaponObjId.Ghandagoza_Brahma_Gauntlet;

        [DisplayName("Rope Knuckles")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Ghandagoza_Rope_Knuckles)]
        public AllWeaponObjId Swap_RopeKnuckles { get; set; } = AllWeaponObjId.Ghandagoza_Rope_Knuckles;

        [DisplayName("Crimson Finger")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Ghandagoza_Crimson_Finger)]
        public AllWeaponObjId Swap_CrimsonFinger { get; set; } = AllWeaponObjId.Ghandagoza_Crimson_Finger;

        [DisplayName("Golden Fists of Ura")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Ghandagoza_Golden_Fists_of_Ura)]
        public AllWeaponObjId Swap_GoldenFistsOfUra { get; set; } = AllWeaponObjId.Ghandagoza_Golden_Fists_of_Ura;

        [DisplayName("Arkab")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Ghandagoza_Arkab)]
        public AllWeaponObjId Swap_Arkab { get; set; } = AllWeaponObjId.Ghandagoza_Arkab;

        [DisplayName("Sky Piercer")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Ghandagoza_Sky_Piercer)]
        public AllWeaponObjId Swap_SkyPiercer { get; set; } = AllWeaponObjId.Ghandagoza_Sky_Piercer;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Golden Fists of Ura, No Mercy")]
        [Category("Effect Swap")]
        [DefaultValue(GhandagozaEffectWeaponObjId.Ascension)]
        public GhandagozaEffectWeaponObjId EffectSwap_GoldenFistsOfUra { get; set; } = GhandagozaEffectWeaponObjId.Ascension;

        [DisplayName("Sky Piercer, the Apex Fist")]
        [Category("Effect Swap")]
        [DefaultValue(GhandagozaEffectWeaponObjId.Terminus)]
        public GhandagozaEffectWeaponObjId EffectSwap_SkyPiercer { get; set; } = GhandagozaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Golden Fists of Ura, No Mercy")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_GoldenFistsOfUra { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Sky Piercer, the Apex Fist")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_SkyPiercer { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class ZetaConfig : Configurable<ZetaConfig> // 1600
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Spear of Arvess")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(ZetaWeaponObjId.Spear_of_Arvess)]
        public ZetaWeaponObjId Swap_SpearofArvess { get; set; } = ZetaWeaponObjId.Spear_of_Arvess;

        [DisplayName("Sunspot Spear")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(ZetaWeaponObjId.Sunspot_Spear)]
        public ZetaWeaponObjId Swap_Sunspot_Spear { get; set; } = ZetaWeaponObjId.Sunspot_Spear;

        [DisplayName("Brionac")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(ZetaWeaponObjId.Brionac)]
        public ZetaWeaponObjId Swap_Brionac { get; set; } = ZetaWeaponObjId.Brionac;

        [DisplayName("Gisla")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(ZetaWeaponObjId.Gisla)]
        public ZetaWeaponObjId Swap_Gisla { get; set; } = ZetaWeaponObjId.Gisla;

        [DisplayName("Huanglong Spear")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(ZetaWeaponObjId.Huanglong_Spear)]
        public ZetaWeaponObjId Swap_HuanglongSpear { get; set; } = ZetaWeaponObjId.Huanglong_Spear;

        [DisplayName("Gae Bulg")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(ZetaWeaponObjId.Gae_Bulg)]
        public ZetaWeaponObjId Swap_GaeBulg { get; set; } = ZetaWeaponObjId.Gae_Bulg;
#else
        [DisplayName("Spear of Arvess")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Zeta_Spear_of_Arvess)]
        public AllWeaponObjId Swap_SpearofArvess { get; set; } = AllWeaponObjId.Zeta_Spear_of_Arvess;

        [DisplayName("Sunspot Spear")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Zeta_Sunspot_Spear)]
        public AllWeaponObjId Swap_Sunspot_Spear { get; set; } = AllWeaponObjId.Zeta_Sunspot_Spear;

        [DisplayName("Brionac")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Zeta_Brionac)]
        public AllWeaponObjId Swap_Brionac { get; set; } = AllWeaponObjId.Zeta_Brionac;

        [DisplayName("Gisla")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Zeta_Gisla)]
        public AllWeaponObjId Swap_Gisla { get; set; } = AllWeaponObjId.Zeta_Gisla;

        [DisplayName("Huanglong Spear")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Zeta_Huanglong_Spear)]
        public AllWeaponObjId Swap_HuanglongSpear { get; set; } = AllWeaponObjId.Zeta_Huanglong_Spear;

        [DisplayName("Gae Bulg")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Zeta_Gae_Bulg)]
        public AllWeaponObjId Swap_GaeBulg { get; set; } = AllWeaponObjId.Zeta_Gae_Bulg;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Brionac, the Dominant")]
        [Category("Effect Swap")]
        [DefaultValue(ZetaEffectWeaponObjId.Ascension)]
        public ZetaEffectWeaponObjId EffectSwap_Brionac { get; set; } = ZetaEffectWeaponObjId.Ascension;

        [DisplayName("Gae Bulg, Impaler of Ruin")]
        [Category("Effect Swap")]
        [DefaultValue(ZetaEffectWeaponObjId.Terminus)]
        public ZetaEffectWeaponObjId EffectSwap_GaeBulg { get; set; } = ZetaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Brionac, the Dominant")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Brionac { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Gae Bulg, Impaler of Ruin")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_GaeBulg { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class VaseragaConfig : Configurable<VaseragaConfig> // 1700
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Great Scythe Grynoth")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(VaseragaWeaponObjId.Great_Scythe_Grynoth)]
        public VaseragaWeaponObjId Swap_GreatScytheGrynoth { get; set; } = VaseragaWeaponObjId.Great_Scythe_Grynoth;

        [DisplayName("Alsarav")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(VaseragaWeaponObjId.Alsarav)]
        public VaseragaWeaponObjId Swap_Alsarav { get; set; } = VaseragaWeaponObjId.Alsarav;

        [DisplayName("Wurtzite Scythe")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(VaseragaWeaponObjId.Wurtzite_Scythe)]
        public VaseragaWeaponObjId Swap_WurtziteScythe { get; set; } = VaseragaWeaponObjId.Wurtzite_Scythe;

        [DisplayName("Soul Eater")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(VaseragaWeaponObjId.Soul_Eater)]
        public VaseragaWeaponObjId Swap_SoulEater { get; set; } = VaseragaWeaponObjId.Soul_Eater;

        [DisplayName("Cosmic Scythe")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(VaseragaWeaponObjId.Cosmic_Scythe)]
        public VaseragaWeaponObjId Swap_CosmicScythe { get; set; } = VaseragaWeaponObjId.Cosmic_Scythe;

        [DisplayName("Ereshkigal")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(VaseragaWeaponObjId.Ereshkigal)]
        public VaseragaWeaponObjId Swap_Ereshkigal { get; set; } = VaseragaWeaponObjId.Ereshkigal;
#else
        [DisplayName("Great Scythe Grynoth")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Vaseraga_Great_Scythe_Grynoth)]
        public AllWeaponObjId Swap_GreatScytheGrynoth { get; set; } = AllWeaponObjId.Vaseraga_Great_Scythe_Grynoth;

        [DisplayName("Alsarav")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Vaseraga_Alsarav)]
        public AllWeaponObjId Swap_Alsarav { get; set; } = AllWeaponObjId.Vaseraga_Alsarav;

        [DisplayName("Wurtzite Scythe")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Vaseraga_Wurtzite_Scythe)]
        public AllWeaponObjId Swap_WurtziteScythe { get; set; } = AllWeaponObjId.Vaseraga_Wurtzite_Scythe;

        [DisplayName("Soul Eater")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Vaseraga_Soul_Eater)]
        public AllWeaponObjId Swap_SoulEater { get; set; } = AllWeaponObjId.Vaseraga_Soul_Eater;

        [DisplayName("Cosmic Scythe")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Vaseraga_Cosmic_Scythe)]
        public AllWeaponObjId Swap_CosmicScythe { get; set; } = AllWeaponObjId.Vaseraga_Cosmic_Scythe;

        [DisplayName("Ereshkigal")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Vaseraga_Ereshkigal)]
        public AllWeaponObjId Swap_Ereshkigal { get; set; } = AllWeaponObjId.Vaseraga_Ereshkigal;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Wurtzite Scythe, Reaper's Hand")]
        [Category("Effect Swap")]
        [DefaultValue(VaseragaEffectWeaponObjId.Ascension)]
        public VaseragaEffectWeaponObjId EffectSwap_WurtziteScythe { get; set; } = VaseragaEffectWeaponObjId.Ascension;

        [DisplayName("Ereshkigal, Impending Doom")]
        [Category("Effect Swap")]
        [DefaultValue(VaseragaEffectWeaponObjId.Terminus)]
        public VaseragaEffectWeaponObjId EffectSwap_Ereshkigal { get; set; } = VaseragaEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Wurtzite Scythe, Reaper's Hand")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_WurtziteScythe { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Ereshkigal, Impending Doom")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Ereshkigal { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class CagliostroConfig : Configurable<CagliostroConfig> // 1800
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Magnum Opus")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(CagliostroWeaponObjId.Magnum_Opus)]
        public CagliostroWeaponObjId Swap_MagnumOpus { get; set; } = CagliostroWeaponObjId.Magnum_Opus;

        [DisplayName("Dream Atlas")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(CagliostroWeaponObjId.Dream_Atlas)]
        public CagliostroWeaponObjId Swap_DreamAtlas { get; set; } = CagliostroWeaponObjId.Dream_Atlas;

        [DisplayName("Transmigration Tome")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(CagliostroWeaponObjId.Transmigration_Tome)]
        public CagliostroWeaponObjId Swap_TransmigrationTome { get; set; } = CagliostroWeaponObjId.Transmigration_Tome;

        [DisplayName("Sacred Codex")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(CagliostroWeaponObjId.Sacred_Codex)]
        public CagliostroWeaponObjId Swap_SacredCodex { get; set; } = CagliostroWeaponObjId.Sacred_Codex;

        [DisplayName("Arshivelle")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(CagliostroWeaponObjId.Arshivelle)]
        public CagliostroWeaponObjId Swap_Arshivelle { get; set; } = CagliostroWeaponObjId.Arshivelle;

        [DisplayName("Zosimos")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(CagliostroWeaponObjId.Zosimos)]
        public CagliostroWeaponObjId Swap_Zosimos { get; set; } = CagliostroWeaponObjId.Zosimos;
#else
        [DisplayName("Magnum Opus")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Cagliostro_Magnum_Opus)]
        public AllWeaponObjId Swap_MagnumOpus { get; set; } = AllWeaponObjId.Cagliostro_Magnum_Opus;

        [DisplayName("Dream Atlas")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Cagliostro_Dream_Atlas)]
        public AllWeaponObjId Swap_DreamAtlas { get; set; } = AllWeaponObjId.Cagliostro_Dream_Atlas;

        [DisplayName("Transmigration Tome")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Cagliostro_Transmigration_Tome)]
        public AllWeaponObjId Swap_TransmigrationTome { get; set; } = AllWeaponObjId.Cagliostro_Transmigration_Tome;

        [DisplayName("Sacred Codex")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Cagliostro_Sacred_Codex)]
        public AllWeaponObjId Swap_SacredCodex { get; set; } = AllWeaponObjId.Cagliostro_Sacred_Codex;

        [DisplayName("Arshivelle")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Cagliostro_Arshivelle)]
        public AllWeaponObjId Swap_Arshivelle { get; set; } = AllWeaponObjId.Cagliostro_Arshivelle;

        [DisplayName("Zosimos")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Cagliostro_Zosimos)]
        public AllWeaponObjId Swap_Zosimos { get; set; } = AllWeaponObjId.Cagliostro_Zosimos;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Transmigration Tome, Infinity")]
        [Category("Effect Swap")]
        [DefaultValue(CagliostroEffectWeaponObjId.Ascension)]
        public CagliostroEffectWeaponObjId EffectSwap_TransmigrationTome { get; set; } = CagliostroEffectWeaponObjId.Ascension;

        [DisplayName("Zosimos, the Unabridged Truth")]
        [Category("Effect Swap")]
        [DefaultValue(CagliostroEffectWeaponObjId.Terminus)]
        public CagliostroEffectWeaponObjId EffectSwap_Zosimos { get; set; } = CagliostroEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Transmigration Tome, Infinity")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_TransmigrationTome { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Zosimos, the Unabridged Truth")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Zosimos { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class IdConfig : Configurable<IdConfig> // 1900
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Ragnarok")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(IdWeaponObjId.Ragnarok)]
        public IdWeaponObjId Swap_Ragnarok { get; set; } = IdWeaponObjId.Ragnarok;

        [DisplayName("Aviaeth Faussart")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(IdWeaponObjId.Aviaeth_Faussart)]
        public IdWeaponObjId Swap_AviaethFaussart { get; set; } = IdWeaponObjId.Aviaeth_Faussart;

        [DisplayName("Susanoo")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(IdWeaponObjId.Susanoo)]
        public IdWeaponObjId Swap_Susanoo { get; set; } = IdWeaponObjId.Susanoo;

        [DisplayName("Premium Sword")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(IdWeaponObjId.Premium_Sword)]
        public IdWeaponObjId Swap_PremiumSword { get; set; } = IdWeaponObjId.Premium_Sword;

        [DisplayName("Ecke Sachs")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(IdWeaponObjId.Ecke_Sachs)]
        public IdWeaponObjId Swap_EckeSachs { get; set; } = IdWeaponObjId.Ecke_Sachs;

        [DisplayName("Sword of Bahamut")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(IdWeaponObjId.Sword_of_Bahamut)]
        public IdWeaponObjId Swap_SwordofBahamut { get; set; } = IdWeaponObjId.Sword_of_Bahamut;
#else
        [DisplayName("Ragnarok")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Id_Ragnarok)]
        public AllWeaponObjId Swap_Ragnarok { get; set; } = AllWeaponObjId.Id_Ragnarok;

        [DisplayName("Aviaeth Faussart")]
        [Category("Model Swap")]
        [Description("\nStunner\n")]
        [DefaultValue(AllWeaponObjId.Id_Aviaeth_Faussart)]
        public AllWeaponObjId Swap_AviaethFaussart { get; set; } = AllWeaponObjId.Id_Aviaeth_Faussart;

        [DisplayName("Susanoo")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Id_Susanoo)]
        public AllWeaponObjId Swap_Susanoo { get; set; } = AllWeaponObjId.Id_Susanoo;

        [DisplayName("Premium Sword")]
        [Category("Model Swap")]
        [Description("\nStinger\n")]
        [DefaultValue(AllWeaponObjId.Id_Premium_Sword)]
        public AllWeaponObjId Swap_PremiumSword { get; set; } = AllWeaponObjId.Id_Premium_Sword;

        [DisplayName("Ecke Sachs")]
        [Category("Model Swap")]
        [Description("\nExecutioner\n")]
        [DefaultValue(AllWeaponObjId.Id_Ecke_Sachs)]
        public AllWeaponObjId Swap_EckeSachs { get; set; } = AllWeaponObjId.Id_Ecke_Sachs;

        [DisplayName("Sword of Bahamut")]
        [Category("Model Swap")]
        [Description("\nTerminus\n")]
        [DefaultValue(AllWeaponObjId.Id_Sword_of_Bahamut)]
        public AllWeaponObjId Swap_SwordofBahamut { get; set; } = AllWeaponObjId.Id_Sword_of_Bahamut;
#endif
        #endregion

        #region Effect Swap
        [DisplayName("Susanoo, the Condemner")]
        [Category("Effect Swap")]
        [DefaultValue(IdEffectWeaponObjId.Ascension)]
        public IdEffectWeaponObjId EffectSwap_Susanoo { get; set; } = IdEffectWeaponObjId.Ascension;

        [DisplayName("Primal Sword of Bahamut")]
        [Category("IEffect Swapd")]
        [DefaultValue(IdEffectWeaponObjId.Terminus)]
        public IdEffectWeaponObjId EffectSwap_PrimalSwordOfBahamut { get; set; } = IdEffectWeaponObjId.Terminus;
        #endregion

        #region Effect Control
        [DisplayName("Susanoo, the Condemner")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_Susanoo { get; set; } = WeaponEffectControlType.Enabled;

        [DisplayName("Primal Sword of Bahamut")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_PrimalSwordOfBahamut { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class SandalphonConfig : Configurable<SandalphonConfig> // 2100
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Apprentice")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(SandalphonWeaponObjId.Apprentice)]
        public SandalphonWeaponObjId Swap_Apprentice { get; set; } = SandalphonWeaponObjId.Apprentice;

        [DisplayName("Sandalphon Placeholder2")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(SandalphonWeaponObjId.World_Ender)]
        public SandalphonWeaponObjId Swap_WorldEnder { get; set; } = SandalphonWeaponObjId.World_Ender;
#else
        [DisplayName("Apprentice")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Sandalphon_Apprentice)]
        public AllWeaponObjId Swap_Apprentice { get; set; } = AllWeaponObjId.Sandalphon_Apprentice;

        [DisplayName("Sandalphon Placeholder2")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Sandalphon_World_Ender)]
        public AllWeaponObjId Swap_WorldEnder { get; set; } = AllWeaponObjId.Sandalphon_World_Ender;
#endif
        #endregion

        #region Effect Control
        [DisplayName("World Ender, the Fated Edge")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_WorldEnder { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class SeofonConfig : Configurable<SeofonConfig> // 2200
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Sette di Spade")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(SeofonWeaponObjId.Sette_di_Spade)]
        public SeofonWeaponObjId Swap_SettediSpade { get; set; } = SeofonWeaponObjId.Sette_di_Spade;

        [DisplayName("Gateway-Star Sword")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(SeofonWeaponObjId.Gateway_Star_Sword)]
        public SeofonWeaponObjId Swap_GatewayStarSword { get; set; } = SeofonWeaponObjId.Gateway_Star_Sword;
#else
        [DisplayName("Sette di Spade")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Seofon_Sette_di_Spade)]
        public AllWeaponObjId Swap_SettediSpade { get; set; } = AllWeaponObjId.Seofon_Sette_di_Spade;

        [DisplayName("Gateway-Star Sword")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Seofon_Gateway_Star_Sword)]
        public AllWeaponObjId Swap_GatewayStarSword { get; set; } = AllWeaponObjId.Seofon_Gateway_Star_Sword;
#endif
        #endregion

        #region Effect Control
        [DisplayName("Gateway-Star Sword, Seven Winks")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_GatewayStarSword { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    public class TweyenConfig : Configurable<TweyenConfig> // 2300
    {
        #region Model Swap
#if DEFAULT || DEBUG_DEFAULT
        [DisplayName("Bow of Dismissal")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(TweyenWeaponObjId.Bow_of_Dismissal)]
        public TweyenWeaponObjId Swap_BowofDismissal { get; set; } = TweyenWeaponObjId.Bow_of_Dismissal;

        [DisplayName("Desolation-Crown Bow")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(TweyenWeaponObjId.Desolation_Crown_Bow)]
        public TweyenWeaponObjId Swap_DesolationCrownBow { get; set; } = TweyenWeaponObjId.Desolation_Crown_Bow;
#else
        [DisplayName("Bow of Dismissal")]
        [Category("Model Swap")]
        [Description("\nDefender\n")]
        [DefaultValue(AllWeaponObjId.Tweyen_Bow_of_Dismissal)]
        public AllWeaponObjId Swap_BowofDismissal { get; set; } = AllWeaponObjId.Tweyen_Bow_of_Dismissal;

        [DisplayName("Desolation-Crown Bow")]
        [Category("Model Swap")]
        [Description("\nAscension\n")]
        [DefaultValue(AllWeaponObjId.Tweyen_Desolation_Crown_Bow)]
        public AllWeaponObjId Swap_DesolationCrownBow { get; set; } = AllWeaponObjId.Tweyen_Desolation_Crown_Bow;
#endif
        #endregion

        #region Effect Control
        [DisplayName("Desolation-Crown Bow, Two Feuds")]
        [Category("Effect Control")]
        [DefaultValue(WeaponEffectControlType.Enabled)]
        public WeaponEffectControlType EffectControl_DesolationCrownBow { get; set; } = WeaponEffectControlType.Enabled;
        #endregion
    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        public override IUpdatableConfigurable[] MakeConfigurations(string configFolder)
        {
            // You can add any Configurable here.
            return
            [
                Configurable<Config>.FromFile(Path.Combine(configFolder, "Config.json"), "Main Settings - Click here for more settings"),
                Configurable<CaptainConfig>.FromFile(Path.Combine(configFolder, $"{nameof(CaptainConfig)}.json"), "Captain"),
                Configurable<KatalinaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(KatalinaConfig)}.json"), "Katalina"),
                Configurable<RackamConfig>.FromFile(Path.Combine(configFolder, $"{nameof(RackamConfig)}.json"), "Rackam"),
                Configurable<IoConfig>.FromFile(Path.Combine(configFolder, $"{nameof(IoConfig)}.json"), "Io"),
                Configurable<EugenConfig>.FromFile(Path.Combine(configFolder, $"{nameof(EugenConfig)}.json"), "Eugen"),
                Configurable<RosettaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(RosettaConfig)}.json"), "Rosetta"),
                Configurable<FerryConfig>.FromFile(Path.Combine(configFolder, $"{nameof(FerryConfig)}.json"), "Ferry"),
                Configurable<LancelotConfig>.FromFile(Path.Combine(configFolder, $"{nameof(LancelotConfig)}.json"), "Lancelot"),
                Configurable<VaneConfig>.FromFile(Path.Combine(configFolder, $"{nameof(VaneConfig)}.json"), "Vane"),
                Configurable<PercivalConfig>.FromFile(Path.Combine(configFolder, $"{nameof(PercivalConfig)}.json"), "Percival"),
                Configurable<SiegfriedConfig>.FromFile(Path.Combine(configFolder, $"{nameof(SiegfriedConfig)}.json"), "Siegfried"),
                Configurable<CharlottaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(CharlottaConfig)}.json"), "Charlotta"),
                Configurable<YodarhaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(YodarhaConfig)}.json"), "Yodarha"),
                Configurable<NarmayaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(NarmayaConfig)}.json"), "Narmaya"),
                Configurable<GhandagozaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(GhandagozaConfig)}.json"), "Ghandagoza"),
                Configurable<ZetaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(ZetaConfig)}.json"), "Zeta"),
                Configurable<VaseragaConfig>.FromFile(Path.Combine(configFolder, $"{nameof(VaseragaConfig)}.json"), "Vaseraga"),
                Configurable<CagliostroConfig>.FromFile(Path.Combine(configFolder, $"{nameof(CagliostroConfig)}.json"), "Cagliostro"),
                Configurable<IdConfig>.FromFile(Path.Combine(configFolder, $"{nameof(IdConfig)}.json"), "Id"),
                Configurable<SandalphonConfig>.FromFile(Path.Combine(configFolder, $"{nameof(SandalphonConfig)}.json"), "Sandalphon"),
                Configurable<SeofonConfig>.FromFile(Path.Combine(configFolder, $"{nameof(SeofonConfig)}.json"), "Seofon"),
                Configurable<TweyenConfig>.FromFile(Path.Combine(configFolder, $"{nameof(TweyenConfig)}.json"), "Tweyen"),
            ];
        }
    }

    public class CustomContext : ModContext
    {
        /// <summary>
        /// Provides access to this mod's configuration for the Captain.
        /// </summary>
        public CaptainConfig CaptainModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public KatalinaConfig KatalinaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public RackamConfig RackamModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public IoConfig IoModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public EugenConfig EugenModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public RosettaConfig RosettaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public FerryConfig FerryModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public LancelotConfig LancelotModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public VaneConfig VaneModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public PercivalConfig PercivalModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public SiegfriedConfig SiegfriedModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public CharlottaConfig CharlottaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public YodarhaConfig YodarhaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public NarmayaConfig NarmayaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public GhandagozaConfig GhandagozaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public ZetaConfig ZetaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public VaseragaConfig VaseragaModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public CagliostroConfig CagliostroModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public IdConfig IdModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public SandalphonConfig SandalphonModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public SeofonConfig SeofonModConfig { get; set; } = null!;

        /// <summary>
        /// Provides access to this mod's configuration for Katalina.
        /// </summary>
        public TweyenConfig TweyenModConfig { get; set; } = null!;
    }

    //public class CustomModBase : ModBase
    //{
    //    public virtual void ConfigurationUpdated(CaptainConfig configuration) { }
    //    public virtual void ConfigurationUpdated(KatalinaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(RackamConfig configuration) { }
    //    public virtual void ConfigurationUpdated(IoConfig configuration) { }
    //    public virtual void ConfigurationUpdated(EugenConfig configuration) { }
    //    public virtual void ConfigurationUpdated(RosettaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(FerryConfig configuration) { }
    //    public virtual void ConfigurationUpdated(LancelotConfig configuration) { }
    //    public virtual void ConfigurationUpdated(VaneConfig configuration) { }
    //    public virtual void ConfigurationUpdated(PercivalConfig configuration) { }
    //    public virtual void ConfigurationUpdated(SiegfriedConfig configuration) { }
    //    public virtual void ConfigurationUpdated(CharlottaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(YodarhaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(NarmayaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(GhandagozaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(ZetaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(VaseragaConfig configuration) { }
    //    public virtual void ConfigurationUpdated(CagliostroConfig configuration) { }
    //    public virtual void ConfigurationUpdated(IdConfig configuration) { }
    //    public virtual void ConfigurationUpdated(SandalphonConfig configuration) { }
    //    public virtual void ConfigurationUpdated(SeofonConfig configuration) { }
    //    public virtual void ConfigurationUpdated(TweyenConfig configuration) { }
    //}
}
