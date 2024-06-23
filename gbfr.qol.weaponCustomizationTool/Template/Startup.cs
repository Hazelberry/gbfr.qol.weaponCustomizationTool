/*
 * This file and other files in the `Template` folder are intended to be left unedited (if possible),
 * to make it easier to upgrade to newer versions of the template.
*/

using gbfr.qol.weaponCustomizationTool.Configuration;
using gbfr.qol.weaponCustomizationTool.Template.Configuration;

using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace gbfr.qol.weaponCustomizationTool.Template
{
    public class Startup : IMod
    {
        /// <summary>
        /// Used for writing text to the Reloaded log.
        /// </summary>
        private ILogger _logger = null!;

        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private IModLoader _modLoader = null!;

        /// <summary>
        /// Stores the contents of your mod's configuration. Automatically updated by template.
        /// </summary>
        private Config _configuration = null!;
        private CaptainConfig _captain = null!;
        private KatalinaConfig _katalina = null!;
        private RackamConfig _rackam = null!;
        private IoConfig _io = null!;
        private EugenConfig _eugen = null!;
        private RosettaConfig _rosetta = null!;
        private FerryConfig _ferry = null!;
        private LancelotConfig _lancelot = null!;
        private VaneConfig _vane = null!;
        private PercivalConfig _percival = null!;
        private SiegfriedConfig _siegfried = null!;
        private CharlottaConfig _charlotta = null!;
        private YodarhaConfig _yodarha = null!;
        private NarmayaConfig _narmaya = null!;
        private GhandagozaConfig _ghandagoza = null!;
        private ZetaConfig _zeta = null!;
        private VaseragaConfig _vaseraga = null!;
        private CagliostroConfig _cagliostro = null!;
        private IdConfig _id = null!;
        private SandalphonConfig _sandalphon = null!;
        private SeofonConfig _seofon = null!;
        private TweyenConfig _tweyen = null!;

        /// <summary>
        /// Configuration of the current mod.
        /// </summary>
        private IModConfig _modConfig = null!;

        /// <summary>
        /// Encapsulates your mod logic.
        /// </summary>
        private ModBase _mod = new Mod();

        /// <summary>
        /// Entry point for your mod.
        /// </summary>
        public void StartEx(IModLoaderV1 loaderApi, IModConfigV1 modConfig)
        {
            _modLoader = (IModLoader)loaderApi;
            _modConfig = (IModConfig)modConfig;
            _logger = (ILogger)_modLoader.GetLogger();

            // Your config file is in Config.json.
            // Need a different name, format or more configurations? Modify the `Configurator`.
            // If you do not want a config, remove Configuration folder and Config class.
            var configurator = new Configurator(_modLoader.GetModConfigDirectory(_modConfig.ModId));
            int i = 0;
            _configuration = configurator.GetConfiguration<Config>(i);
            _captain = configurator.GetConfiguration<CaptainConfig>(++i);
            _katalina = configurator.GetConfiguration<KatalinaConfig>(++i);
            _rackam = configurator.GetConfiguration<RackamConfig>(++i);
            _io = configurator.GetConfiguration<IoConfig>(++i);
            _eugen = configurator.GetConfiguration<EugenConfig>(++i);
            _rosetta = configurator.GetConfiguration<RosettaConfig>(++i);
            _ferry = configurator.GetConfiguration<FerryConfig>(++i);
            _lancelot = configurator.GetConfiguration<LancelotConfig>(++i);
            _vane = configurator.GetConfiguration<VaneConfig>(++i);
            _percival = configurator.GetConfiguration<PercivalConfig>(++i);
            _siegfried = configurator.GetConfiguration<SiegfriedConfig>(++i);
            _charlotta = configurator.GetConfiguration<CharlottaConfig>(++i);
            _yodarha = configurator.GetConfiguration<YodarhaConfig>(++i);
            _narmaya = configurator.GetConfiguration<NarmayaConfig>(++i);
            _ghandagoza = configurator.GetConfiguration<GhandagozaConfig>(++i);
            _zeta = configurator.GetConfiguration<ZetaConfig>(++i);
            _vaseraga = configurator.GetConfiguration<VaseragaConfig>(++i);
            _cagliostro = configurator.GetConfiguration<CagliostroConfig>(++i);
            _id = configurator.GetConfiguration<IdConfig>(++i);
            _sandalphon = configurator.GetConfiguration<SandalphonConfig>(++i);
            _seofon = configurator.GetConfiguration<SeofonConfig>(++i);
            _tweyen = configurator.GetConfiguration<TweyenConfig>(++i);
            _configuration.ConfigurationUpdated += OnConfigurationUpdated;
            #region Character Specific ConfigurationUpdated
            //_captain.ConfigurationUpdated += CaptainOnConfigurationUpdated;
            //_katalina.ConfigurationUpdated += KatalinaOnConfigurationUpdated;
            //_rackam.ConfigurationUpdated += RackamOnConfigurationUpdated;
            //_io.ConfigurationUpdated += IoOnConfigurationUpdated;
            //_eugen.ConfigurationUpdated += EugenOnConfigurationUpdated;
            //_rosetta.ConfigurationUpdated += RosettaOnConfigurationUpdated;
            //_ferry.ConfigurationUpdated += FerryOnConfigurationUpdated;
            //_lancelot.ConfigurationUpdated += LancelotOnConfigurationUpdated;
            //_vane.ConfigurationUpdated += VaneOnConfigurationUpdated;
            //_percival.ConfigurationUpdated += PercivalOnConfigurationUpdated;
            //_siegfried.ConfigurationUpdated += SiegfriedOnConfigurationUpdated;
            //_charlotta.ConfigurationUpdated += CharlottaOnConfigurationUpdated;
            //_yodarha.ConfigurationUpdated += YodarhaOnConfigurationUpdated;
            //_narmaya.ConfigurationUpdated += NarmayaOnConfigurationUpdated;
            //_ghandagoza.ConfigurationUpdated += GhandagozaOnConfigurationUpdated;
            //_zeta.ConfigurationUpdated += ZetaOnConfigurationUpdated;
            //_vaseraga.ConfigurationUpdated += VaseragaOnConfigurationUpdated;
            //_cagliostro.ConfigurationUpdated += CagliostroOnConfigurationUpdated;
            //_id.ConfigurationUpdated += IdOnConfigurationUpdated;
            //_sandalphon.ConfigurationUpdated += SandalphonOnConfigurationUpdated;
            //_seofon.ConfigurationUpdated += SeofonOnConfigurationUpdated;
            //_tweyen.ConfigurationUpdated += TweyenOnConfigurationUpdated;
            #endregion

            // Please put your mod code in the class below,
            // use this class for only interfacing with mod loader.
            _mod = new Mod(new CustomContext()
            {
                Logger = _logger,
                ModLoader = _modLoader,
                ModConfig = _modConfig,
                Owner = this,
                Configuration = _configuration,
                CaptainModConfig = _captain,
                KatalinaModConfig = _katalina,
                RackamModConfig = _rackam,
                IoModConfig = _io,
                EugenModConfig = _eugen,
                RosettaModConfig = _rosetta,
                FerryModConfig = _ferry,
                LancelotModConfig = _lancelot,
                VaneModConfig = _vane,
                PercivalModConfig = _percival,
                SiegfriedModConfig = _siegfried,
                CharlottaModConfig = _charlotta,
                YodarhaModConfig = _yodarha,
                NarmayaModConfig = _narmaya,
                GhandagozaModConfig = _ghandagoza,
                ZetaModConfig = _zeta,
                VaseragaModConfig = _vaseraga,
                CagliostroModConfig = _cagliostro,
                IdModConfig = _id,
                SandalphonModConfig = _sandalphon,
                SeofonModConfig = _seofon,
                TweyenModConfig = _tweyen,
            });
        }

        private void OnConfigurationUpdated(IConfigurable obj)
        {
            /*
                This is executed when the configuration file gets 
                updated by the user at runtime.
            */

            // Replace configuration with new.
            _configuration = (Config)obj;
            _mod.ConfigurationUpdated(_configuration);
        }
        #region Character specific OnCofigurationUpdated
        //private void CaptainOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _captain = (CaptainConfig)obj;
        //    _mod.ConfigurationUpdated(_captain);
        //}

        //private void KatalinaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _katalina = (KatalinaConfig)obj;
        //    _mod.ConfigurationUpdated(_katalina);
        //}

        //private void RackamOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _rackam = (RackamConfig)obj;
        //    _mod.ConfigurationUpdated(_rackam);
        //}

        //private void IoOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _io = (IoConfig)obj;
        //    _mod.ConfigurationUpdated(_io);
        //}

        //private void EugenOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _eugen = (EugenConfig)obj;
        //    _mod.ConfigurationUpdated(_eugen);
        //}

        //private void RosettaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _rosetta = (RosettaConfig)obj;
        //    _mod.ConfigurationUpdated(_rosetta);
        //}

        //private void FerryOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _ferry = (FerryConfig)obj;
        //    _mod.ConfigurationUpdated(_ferry);
        //}

        //private void LancelotOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _lancelot = (LancelotConfig)obj;
        //    _mod.ConfigurationUpdated(_lancelot);
        //}

        //private void VaneOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _vane = (VaneConfig)obj;
        //    _mod.ConfigurationUpdated(_vane);
        //}

        //private void PercivalOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _percival = (PercivalConfig)obj;
        //    _mod.ConfigurationUpdated(_percival);
        //}

        //private void SiegfriedOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _siegfried = (SiegfriedConfig)obj;
        //    _mod.ConfigurationUpdated(_siegfried);
        //}

        //private void CharlottaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _charlotta = (CharlottaConfig)obj;
        //    _mod.ConfigurationUpdated(_charlotta);
        //}

        //private void YodarhaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _yodarha = (YodarhaConfig)obj;
        //    _mod.ConfigurationUpdated(_yodarha);
        //}

        //private void NarmayaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _narmaya = (NarmayaConfig)obj;
        //    _mod.ConfigurationUpdated(_narmaya);
        //}

        //private void GhandagozaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _ghandagoza = (GhandagozaConfig)obj;
        //    _mod.ConfigurationUpdated(_ghandagoza);
        //}

        //private void ZetaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _zeta = (ZetaConfig)obj;
        //    _mod.ConfigurationUpdated(_zeta);
        //}

        //private void VaseragaOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _vaseraga = (VaseragaConfig)obj;
        //    _mod.ConfigurationUpdated(_vaseraga);
        //}

        //private void CagliostroOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _cagliostro = (CagliostroConfig)obj;
        //    _mod.ConfigurationUpdated(_cagliostro);
        //}

        //private void IdOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _id = (IdConfig)obj;
        //    _mod.ConfigurationUpdated(_id);
        //}

        //private void SandalphonOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _sandalphon = (SandalphonConfig)obj;
        //    _mod.ConfigurationUpdated(_sandalphon);
        //}

        //private void SeofonOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _seofon = (SeofonConfig)obj;
        //    _mod.ConfigurationUpdated(_seofon);
        //}

        //private void TweyenOnConfigurationUpdated(IConfigurable obj)
        //{
        //    _tweyen = (TweyenConfig)obj;
        //    _mod.ConfigurationUpdated(_tweyen);
        //}
        #endregion

        /* Mod loader actions. */
        public void Suspend() => _mod.Suspend();
        public void Resume() => _mod.Resume();
        public void Unload() => _mod.Unload();

        /*  If CanSuspend == false, suspend and resume button are disabled in Launcher and Suspend()/Resume() will never be called.
            If CanUnload == false, unload button is disabled in Launcher and Unload() will never be called.
        */
        public bool CanUnload() => _mod.CanUnload();
        public bool CanSuspend() => _mod.CanSuspend();

        /* Automatically called by the mod loader when the mod is about to be unloaded. */
        public Action Disposing => () => _mod.Disposing();
    }
}