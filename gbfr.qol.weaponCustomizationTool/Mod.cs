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

    #region Character Configs
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
    #endregion

    /// <summary>
    /// The configuration of the currently executing mod.
    /// </summary>
    private readonly IModConfig _modConfig;

    private readonly WeakReference<IDataManager> _dataManagerRef;

    private ObjReadAppend _objRead;

    private ModelInfo _modelInfo;

    private readonly Dictionary<string, byte[]> _originalFiles = [];

    private readonly Dictionary<string, byte[]> _workingFiles = [];

    public Mod(CustomContext context)
    {
        _modLoader = context.ModLoader;
        _logger = context.Logger;
        _owner = context.Owner;
        _configuration = context.Configuration;
        _modConfig = context.ModConfig;
        #region Character config contexts
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
        #endregion

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

        var modelSwapMap = GetModelSwapMap();
        var effectSwapMap = GetEffectSwapMap();

        string infoFile = "system/objread/info.objread";
        if (!manager.FileExists(infoFile, includeExternal: false))
            return;

        byte[] fileBytes = manager.GetArchiveFile(infoFile);
        _objRead = ObjReadAppend.Serializer.Parse(fileBytes);

        foreach (var weapon in effectSwapMap)  // Must come before ProcessModels to ensure effect swapping works correctly
            ProcessEffectSwap(weapon.Key, weapon.Value);

        foreach (var weapon in modelSwapMap)
            ProcessModels(weapon.Key, weapon.Value);

        byte[] outputBuffer = new byte[ObjReadAppend.Serializer.GetMaxSize(_objRead)];
        int length = ObjReadAppend.Serializer.Write(outputBuffer, _objRead);

        manager.AddOrUpdateExternalFile(infoFile,
            outputBuffer.AsSpan(0, length).ToArray());

        ///----------------------------------------------------------------------------///

        var effectControlMap = GetEffectControlMap();

        foreach (var weapon in effectControlMap)
            ProcessEffectControl(weapon.Key, weapon.Value);

        ///----------------------------------------------------------------------------///

        Dictionary<eObjId, eObjId> captainIdList = new()
        {
            { (eObjId)AllWeaponObjId.Captain_Durandal, (eObjId)_captain.Swap_Durandal                              },
            { (eObjId)AllWeaponObjId.Captain_Sword_of_Eos, (eObjId)_captain.Swap_SwordofEos                        },
            { (eObjId)AllWeaponObjId.Captain_Albacore_Blade, (eObjId)_captain.Swap_AlbacoreBlade                   },
            { (eObjId)AllWeaponObjId.Captain_Ultima_Sword, (eObjId)_captain.Swap_UltimaSword                       },
            { (eObjId)AllWeaponObjId.Captain_Seven_Star_Sword, (eObjId)_captain.Swap_SevenStarSword                },
            { (eObjId)AllWeaponObjId.Captain_Partenza, (eObjId)_captain.Swap_Partenza                              },
        };

        Dictionary<eObjId, eObjId> narmayaIdList = new()
        {
            { (eObjId)AllWeaponObjId.Narmaya_Nakamaki_Nodachi, (eObjId)_narmaya.Swap_NakamakiNodachi               },
            { (eObjId)AllWeaponObjId.Narmaya_Kotetsu, (eObjId)_narmaya.Swap_Kotetsu                                },
            { (eObjId)AllWeaponObjId.Narmaya_Venustas, (eObjId)_narmaya.Swap_Venustas                              },
            { (eObjId)AllWeaponObjId.Narmaya_Flourithium_Blade, (eObjId)_narmaya.Swap_Flourithium_Blade            },
            { (eObjId)AllWeaponObjId.Narmaya_Blade_of_Purification, (eObjId)_narmaya.Swap_BladeofPurification      },
            { (eObjId)AllWeaponObjId.Narmaya_Ameno_Habakiri, (eObjId)_narmaya.Swap_AmenoHabakiri                   },
        };


        foreach (var elem in captainIdList)
        {
            // If values are different, SheathSwapToggle is enabled, and the target weapon is from the Captain. Or if values are different, weapon is Partenza, and target weapon is from the Captain.
            if (elem.Key != elem.Value && (_captain.SheathSwapToggle || elem.Key == eObjId.WP_Captain_Partenza) && Enum.IsDefined(typeof(CaptainWeaponObjId), elem.Value))
            {
                ProcessSheathSwap(captainIdList, eObjId.PL_Djeeta_Original); // Specifically Djeeta's original outfit because it's the only Captain model with multiple sheaths
                break;
            }
        }

        foreach (var elem in narmayaIdList)
        {
            // If values are different, SheathSwpToggle is enabled, and the target weapon is from Narmaya
            if (elem.Key != elem.Value && _narmaya.SheathSwapToggle && Enum.IsDefined(typeof(NarmayaWeaponObjId), elem.Value))
            {
                ProcessSheathSwap(narmayaIdList, eObjId.PL_Narmaya);
                break;
            }
        }
    }

    public void ProcessEffectSwap(eObjId sourceObjId, eObjId targetObjId)
    {
        if (targetObjId == sourceObjId) // If no change
            return;

        try
        {
            var sourceResult = _objRead.Entries.FirstOrDefault(e => e.SearchObjidKey == (uint)sourceObjId);

            if (sourceResult is null)
            {
                _logger.WriteLine($"Can't find {Utils.ObjIdToModelId(sourceObjId)} in info.objread to swap effects. Either doesn't have an effect or something broke.");
                return;
            }

            _logger.WriteLine($"Swapping {Utils.ObjIdToModelId(sourceObjId)} effect with {Utils.ObjIdToModelId(targetObjId)}");

            sourceResult.EffectsObjid = (uint)targetObjId;

            if (Enum.IsDefined(typeof(FerryWeaponObjId), sourceObjId)
                && Enum.IsDefined(typeof(FerryWeaponObjId), targetObjId)) // If both weapons are from Ferry
            {
                ProcessCallSelector(sourceObjId, targetObjId);
            }

        }
        catch (Exception ex)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] Failed to apply {Utils.ObjIdToModelId(sourceObjId)} effect swap to {Utils.ObjIdToModelId(targetObjId)} - {ex.Message}");
        }
    }

    public void ProcessModels(eObjId sourceUint, eObjId targetUint)
    {
        if (targetUint == sourceUint)
            return;

        try
        {
            var sourceResult = _objRead.Entries.FirstOrDefault(e => e.SearchObjidKey == (uint)sourceUint);

            if (sourceResult is null)
            {
                _logger.WriteLine($"Replacing {Utils.ObjIdToModelId(sourceUint)} with {Utils.ObjIdToModelId(targetUint)}. No entry found, making new entry.");

                sourceResult = NewInfo(sourceUint);

#if DEBUG_DEFAULT || DEBUG_NORESTRICTIONS
                _logger.WriteLine($"{sourceResult.SearchObjidKey}");
#endif
            }
            else
            {
                _logger.WriteLine($"Replacing {Utils.ObjIdToModelId(sourceUint)} with {Utils.ObjIdToModelId(targetUint)}");
            }

            if (Utils.HasEffect((eObjId)sourceUint) && !Utils.HasEffect((eObjId)targetUint) && _configuration.ToggleEffectPreservation == true) // Effect preservation
            {
                var targetResult = _objRead.Entries.FirstOrDefault(e => e.SearchObjidKey == (uint)targetUint);

                var sourceEffect = sourceResult.EffectsObjid;

                _logger.WriteLine($"Preserving {Utils.ObjIdToModelId(sourceUint)} effect, writing to {Utils.ObjIdToModelId(targetUint)}.");

                if (targetResult is null)
                {
                    targetResult = NewInfo(targetUint);
                    _logger.WriteLine($"No {Utils.ObjIdToModelId(targetUint)} entry found, making new entry.");
                }
                
                targetResult.EffectsObjid = sourceEffect; // Does it this way instead of sourceHex to preserve Effect Swap changes
            }

            if ((Enum.IsDefined(typeof(FerryWeaponObjId), sourceUint) && Enum.IsDefined(typeof(FerryWeaponObjId), targetUint))
                || (Enum.IsDefined(typeof(SeofonWeaponObjId), sourceUint) && Enum.IsDefined(typeof(SeofonWeaponObjId), targetUint))) // If both weapons are from Ferry, or both are from Seofon
            {
                ProcessCallSelector(sourceUint, targetUint);
            }

            sourceResult.ModelObjid = (uint)targetUint;
            sourceResult.PhysicsObjid = (uint)targetUint;
            sourceResult.UnkObjid8 = (uint)targetUint;
        }
        catch (Exception ex)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] Failed to apply {Utils.ObjIdToModelId(sourceUint)} model patch - {ex.Message}");
        }
    }

    public void ProcessEffectControl(eObjId sourceUint, WeaponEffectControlType controlType)
    {
        if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
            return;

        string sourceName = Utils.ObjIdToModelId(sourceUint);

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

    public void ProcessSheathSwap(Dictionary<eObjId, eObjId> objIdMap, eObjId characterObjId)
    {
        if (!_dataManagerRef.TryGetTarget(out IDataManager manager))
            return;

        int skipCount = 0;
        foreach (var elem in objIdMap)
        {
            if ((characterObjId == eObjId.PL_Narmaya && !Enum.IsDefined(typeof(NarmayaWeaponObjId), elem.Value)) || 
                (characterObjId == eObjId.PL_Djeeta_Original && !Enum.IsDefined(typeof(CaptainWeaponObjId), elem.Value)) || 
                elem.Key == elem.Value)
            {
                skipCount++;
            }
        }
        if (skipCount == objIdMap.Count) // Skips the whole method if all the values are unchanged and/or other characters' weapons
        {
            return;
        }

        _logger.WriteLine($"Swapping sheaths for {(characterObjId == eObjId.PL_Djeeta_Original ? "Djeeta" : "Narmaya")}");

        string characterMInfo;

        if (characterObjId == eObjId.PL_Narmaya || characterObjId == eObjId.PL_Djeeta_Original)
        {
            characterMInfo = $"model/pl/pl{characterObjId}/pl{characterObjId}.minfo";
        }
        else
        {
            _logger.WriteLine($"Character {characterObjId} does not have a swappable sheath, this method should not have been called.");
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

        foreach (var elem in objIdMap)
        {
            if ((characterObjId == eObjId.PL_Narmaya && !Enum.IsDefined(typeof(NarmayaWeaponObjId), elem.Value)) ||
                (characterObjId == eObjId.PL_Djeeta_Rebel && !Enum.IsDefined(typeof(CaptainWeaponObjId), elem.Value)) ||
                elem.Key == elem.Value) // Skip if config is set to another character's weapon or the same
            {
                continue;
            }

            string sourceSheath = Utils.ObjIdToSheathId(elem.Key);
            string targetSheath = Utils.ObjIdToSheathId(elem.Value);

            _logger.WriteLine($"Changing {sourceSheath} to {targetSheath}");

            if (characterObjId == eObjId.PL_Narmaya)
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

                List<int> sourceLodIndices = [];
                List<int> targetLodIndices = [];

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

            SubMeshInfo sourceData = _modelInfo.SubMeshes[sourceIndex];
            SubMeshInfo targetData = modelInfoBackup.SubMeshes[targetIndex];

            string sourceDataName;
            BoundaryBox sourceDataBbox;

            if (characterObjId == eObjId.PL_Djeeta_Rebel && (_captain.SheathSwapToggle || elem.Key == (eObjId)CaptainWeaponObjId.Partenza))
            {
                sourceData.Name = targetData.Name;
                sourceData.Bbox = targetData.Bbox;
            }
            else if (characterObjId == eObjId.PL_Narmaya)
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

    public void ProcessCallSelector(eObjId sourceUint, eObjId targetUint) // callselector.bxm also includes data for Sandalphon and Seofon, unsure what that data is for
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

        string sourceName = Utils.ObjIdToModelId(sourceUint);
        string targetName = Utils.ObjIdToModelId(targetUint);

        try
        {
            byte[] file = (manager.FileExists(effectFile, includeExternal: false)) ? manager.GetArchiveFile(effectFile) : _workingFiles[effectFile]; // If file exists in archive use it, else use backup

            using var ms = new MemoryStream(file);
            XmlDocument xmlDoc = XmlBin.Read(ms);

            var root = xmlDoc["root"];
            string baseString;

            if (WeaponEffects.FerryCallSelectorSuffixes.TryGetValue((eObjId)targetUint, out char targetSuffix))
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Attributes["ObjId"].Value.Equals(sourceName, StringComparison.OrdinalIgnoreCase))
                    {
                        baseString = node.Attributes["EstId"].Value[..^1]; // Source string without the last character
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
            }
            else if (WeaponEffects.SeofonCallSelector.TryGetValue((eObjId)targetUint, out Dictionary<char, char>? callSelectors))
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Attributes["ObjId"].Value.Equals(sourceName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (node.Attributes["EstId"].Value[0] == '1') // This separation is necessary because Seofon's CallSelector effects have 2 patterns they follow, one starts with 1 and the other with 7
                        {
                            baseString = node.Attributes["EstId"].Value[..2]; // Source string without the last two characters
                            targetSuffix = callSelectors['1']; // Not actually a suffix, second to last character

                            node.Attributes["EstId"].Value = $"{baseString}{targetSuffix}{node.Attributes["EstId"].Value[^1]}";
                        }
                        else if (node.Attributes["EstId"].Value[0] == '7')
                        {
                            baseString = node.Attributes["EstId"].Value[..^1]; // Source string without the last character
                            targetSuffix = callSelectors['7'];

                            node.Attributes["EstId"].Value = $"{baseString}{targetSuffix}";
                        }
                        continue;
                    }
                }
            }
            else // Add Sandalphon here eventually if necessary
            {
                _logger.WriteLine("Something went wrong with ProcessCallSelector, no matching key for target in dictionary");
                return;
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

    public Info NewInfo(eObjId objId)
    {
        uint hexAlt = (uint)objId & 0xFFFFFF00;

        Info newInfo = new()
        {
            SearchObjidKey = (uint)objId,
            UnkObjid2 = hexAlt,
            ModelObjid = (uint)objId,
            EffectsObjid = (uint)objId,
            UnkObjid6 = hexAlt,
            PhysicsObjid = (uint)objId,
            UnkObjid8 = (uint)objId       // Unsure what this one does
        };

        _objRead.Entries.Add(newInfo);

        return newInfo;
    }

    /// <summary>
    /// Contains the config settings for swapping models.
    /// </summary>
    /// <returns>Dictionary&lt;Source ObjId, Config ObjId&gt;</returns>
    public Dictionary<eObjId, eObjId> GetModelSwapMap()
    {
        return new()
        {
            { (eObjId)AllWeaponObjId.Captain_Travellers_Sword, (eObjId)_captain.Swap_TravellersSword                        },
            { (eObjId)AllWeaponObjId.Captain_Durandal, (eObjId)_captain.Swap_Durandal                                       },
            { (eObjId)AllWeaponObjId.Captain_Sword_of_Eos, (eObjId)_captain.Swap_SwordofEos                                 },
            { (eObjId)AllWeaponObjId.Captain_Albacore_Blade, (eObjId)_captain.Swap_AlbacoreBlade                            },
            { (eObjId)AllWeaponObjId.Captain_Ultima_Sword, (eObjId)_captain.Swap_UltimaSword                                },
            { (eObjId)AllWeaponObjId.Captain_Seven_Star_Sword, (eObjId)_captain.Swap_SevenStarSword                         },
            { (eObjId)AllWeaponObjId.Captain_Partenza, (eObjId)_captain.Swap_Partenza                                       },

            { (eObjId)AllWeaponObjId.Katalina_Rukalsa, (eObjId)_katalina.Swap_Rukalsa                                       },
            { (eObjId)AllWeaponObjId.Katalina_Flame_Rapier, (eObjId)_katalina.Swap_FlameRapier                              },
            { (eObjId)AllWeaponObjId.Katalina_Murgleis, (eObjId)_katalina.Swap_Murgleis                                     },
            { (eObjId)AllWeaponObjId.Katalina_Luminiera_Sword_Omega, (eObjId)_katalina.Swap_LuminieraSwordOmega             },
            { (eObjId)AllWeaponObjId.Katalina_Ephemeron, (eObjId)_katalina.Swap_Ephemeron                                   },
            { (eObjId)AllWeaponObjId.Katalina_Blutgang, (eObjId)_katalina.Swap_Blutgang                                     },

            { (eObjId)AllWeaponObjId.Rackam_Flintspike, (eObjId)_rackam.Swap_Flintspike                                     },
            { (eObjId)AllWeaponObjId.Rackam_Wheellock_Axe, (eObjId)_rackam.Swap_WheellockAxe                                },
            { (eObjId)AllWeaponObjId.Rackam_Benedia, (eObjId)_rackam.Swap_Benedia                                           },
            { (eObjId)AllWeaponObjId.Rackam_Tiamat_Bolt_Omega, (eObjId)_rackam.Swap_TiamatBoltOmega                         },
            { (eObjId)AllWeaponObjId.Rackam_Stormcloud, (eObjId)_rackam.Swap_Stormcloud                                     },
            { (eObjId)AllWeaponObjId.Rackam_Freikugel, (eObjId)_rackam.Swap_Freikugel                                       },

            { (eObjId)AllWeaponObjId.Io_Little_Witch_Scepter, (eObjId)_io.Swap_LittleWitchScepter                           },
            { (eObjId)AllWeaponObjId.Io_Zhezl, (eObjId)_io.Swap_Zhezl                                                       },
            { (eObjId)AllWeaponObjId.Io_Gambanteinn, (eObjId)_io.Swap_Gambanteinn                                           },
            { (eObjId)AllWeaponObjId.Io_Colossus_Cane_Omega, (eObjId)_io.Swap_ColossusCaneOmega                             },
            { (eObjId)AllWeaponObjId.Io_Tupsimati, (eObjId)_io.Swap_Tupsimati                                               },
            { (eObjId)AllWeaponObjId.Io_Caduceus, (eObjId)_io.Swap_Caduceus                                                 },

            { (eObjId)AllWeaponObjId.Eugen_Dreyse, (eObjId)_eugen.Swap_Dreyse                                               },
            { (eObjId)AllWeaponObjId.Eugen_Matchlock, (eObjId)_eugen.Swap_Matchlock                                         },
            { (eObjId)AllWeaponObjId.Eugen_AK4A, (eObjId)_eugen.Swap_AK4A                                                   },
            { (eObjId)AllWeaponObjId.Eugen_Leviathan_Muzzle, (eObjId)_eugen.Swap_LeviathanMuzzle                            },
            { (eObjId)AllWeaponObjId.Eugen_Clarion, (eObjId)_eugen.Swap_Clarion                                             },
            { (eObjId)AllWeaponObjId.Eugen_Draconic_Fire, (eObjId)_eugen.Swap_DraconicFire                                  },

            { (eObjId)AllWeaponObjId.Rosetta_Egoism, (eObjId)_rosetta.Swap_Egoism                                           },
            { (eObjId)AllWeaponObjId.Rosetta_Swordbreaker, (eObjId)_rosetta.Swap_Swordbreaker                               },
            { (eObjId)AllWeaponObjId.Rosetta_Love_Eternal, (eObjId)_rosetta.Swap_LoveEternal                                },
            { (eObjId)AllWeaponObjId.Rosetta_Rose_Crystal_Knife, (eObjId)_rosetta.Swap_RoseCrystalKnife                     },
            { (eObjId)AllWeaponObjId.Rosetta_Cortana, (eObjId)_rosetta.Swap_Cortana                                         },
            { (eObjId)AllWeaponObjId.Rosetta_Dagger_of_Bahamut_Coda, (eObjId)_rosetta.Swap_DaggerofBahamutCoda              },

            { (eObjId)AllWeaponObjId.Ferry_Geisterpeitche, (eObjId)_ferry.Swap_Geisterpeitche                               },
            { (eObjId)AllWeaponObjId.Ferry_Leather_Belt, (eObjId)_ferry.Swap_LeatherBelt                                    },
            { (eObjId)AllWeaponObjId.Ferry_Ethereal_Lasher, (eObjId)_ferry.Swap_EtherealLasher                              },
            { (eObjId)AllWeaponObjId.Ferry_Flame_Lit_Curl, (eObjId)_ferry.Swap_FlameLitCurl                                 },
            { (eObjId)AllWeaponObjId.Ferry_Live_Wire, (eObjId)_ferry.Swap_LiveWire                                          },
            { (eObjId)AllWeaponObjId.Ferry_Erinnerung, (eObjId)_ferry.Swap_Erinnerung                                       },

            { (eObjId)AllWeaponObjId.Lancelot_Altachiara, (eObjId)_lancelot.Swap_Altachiara                                 },
            { (eObjId)AllWeaponObjId.Lancelot_Hoarfrost_Blade_Persius, (eObjId)_lancelot.Swap_HoarfrostBladePersius         },
            { (eObjId)AllWeaponObjId.Lancelot_Blanc_Comme_Neige, (eObjId)_lancelot.Swap_BlancCommeNeige                     },
            { (eObjId)AllWeaponObjId.Lancelot_Vegalta, (eObjId)_lancelot.Swap_Vegalta                                       },
            { (eObjId)AllWeaponObjId.Lancelot_Knight_of_Ice, (eObjId)_lancelot.Swap_KnightOfIce                             },
            { (eObjId)AllWeaponObjId.Lancelot_Damascus_Knife, (eObjId)_lancelot.Swap_DamascusKnife                          },

            { (eObjId)AllWeaponObjId.Vane_Alabarda, (eObjId)_vane.Swap_Alabarda                                             },
            { (eObjId)AllWeaponObjId.Vane_Swan, (eObjId)_vane.Swap_Swan                                                     },
            { (eObjId)AllWeaponObjId.Vane_Treuer_Krieger, (eObjId)_vane.Swap_TreuerKrieger                                  },
            { (eObjId)AllWeaponObjId.Vane_Ukonvasara, (eObjId)_vane.Swap_Ukonvasara                                         },
            { (eObjId)AllWeaponObjId.Vane_Blossom_Axe, (eObjId)_vane.Swap_BlossomAxe                                        },
            { (eObjId)AllWeaponObjId.Vane_Mjolnir, (eObjId)_vane.Swap_Mjolnir                                               },

            { (eObjId)AllWeaponObjId.Percival_Flamberge, (eObjId)_percival.Swap_Flamberge                                   },
            { (eObjId)AllWeaponObjId.Percival_Lohengrin, (eObjId)_percival.Swap_Lohengrin                                   },
            { (eObjId)AllWeaponObjId.Percival_Antwerp, (eObjId)_percival.Swap_Antwerp                                       },
            { (eObjId)AllWeaponObjId.Percival_Joyeuse, (eObjId)_percival.Swap_Joyeuse                                       },
            { (eObjId)AllWeaponObjId.Percival_Lord_of_Flames, (eObjId)_percival.Swap_LordOfFlames                           },
            { (eObjId)AllWeaponObjId.Percival_Gottfried, (eObjId)_percival.Swap_Gottfried                                   },

            { (eObjId)AllWeaponObjId.Siegfried_Integrity, (eObjId)_siegfried.Swap_Integrity                                 },
            { (eObjId)AllWeaponObjId.Siegfried_Broadsword_of_Earth, (eObjId)_siegfried.Swap_BroadswordofEarth               },
            { (eObjId)AllWeaponObjId.Siegfried_Ascalon, (eObjId)_siegfried.Swap_Ascalon                                     },
            { (eObjId)AllWeaponObjId.Siegfried_Hrunting, (eObjId)_siegfried.Swap_Hrunting                                   },
            { (eObjId)AllWeaponObjId.Siegfried_Windhose, (eObjId)_siegfried.Swap_Windhose                                   },
            { (eObjId)AllWeaponObjId.Siegfried_Balmung, (eObjId)_siegfried.Swap_Balmung                                     },

            { (eObjId)AllWeaponObjId.Charlotta_Claiomh_Solais, (eObjId)_charlotta.Swap_ClaiomhSolais                        },
            { (eObjId)AllWeaponObjId.Charlotta_Arondight, (eObjId)_charlotta.Swap_Arondight                                 },
            { (eObjId)AllWeaponObjId.Charlotta_Claidheamh_Soluis, (eObjId)_charlotta.Swap_ClaidheamhSoluis                  },
            { (eObjId)AllWeaponObjId.Charlotta_Ushumgal, (eObjId)_charlotta.Swap_Ushumgal                                   },
            { (eObjId)AllWeaponObjId.Charlotta_Sahrivar, (eObjId)_charlotta.Swap_Sahrivar                                   },
            { (eObjId)AllWeaponObjId.Charlotta_Galatine, (eObjId)_charlotta.Swap_Galatine                                   },

            { (eObjId)AllWeaponObjId.Yodarha_Kiku_Ichimonji, (eObjId)_yodarha.Swap_KikuIchimonji                            },
            { (eObjId)AllWeaponObjId.Yodarha_Asura, (eObjId)_yodarha.Swap_Asura                                             },
            { (eObjId)AllWeaponObjId.Yodarha_Fudo_Kuniyuki, (eObjId)_yodarha.Swap_FudoKuniyuki                              },
            { (eObjId)AllWeaponObjId.Yodarha_Higurashi, (eObjId)_yodarha.Swap_Higurashi                                     },
            { (eObjId)AllWeaponObjId.Yodarha_Xeno_Phantom_Demon_Blade, (eObjId)_yodarha.Swap_XenoPhantomDemonBlade          },
            { (eObjId)AllWeaponObjId.Yodarha_Swordfish, (eObjId)_yodarha.Swap_Swordfish                                     },

            { (eObjId)AllWeaponObjId.Narmaya_Nakamaki_Nodachi, (eObjId)_narmaya.Swap_NakamakiNodachi                        },
            { (eObjId)AllWeaponObjId.Narmaya_Kotetsu, (eObjId)_narmaya.Swap_Kotetsu                                         },
            { (eObjId)AllWeaponObjId.Narmaya_Venustas, (eObjId)_narmaya.Swap_Venustas                                       },
            { (eObjId)AllWeaponObjId.Narmaya_Flourithium_Blade, (eObjId)_narmaya.Swap_Flourithium_Blade                     },
            { (eObjId)AllWeaponObjId.Narmaya_Blade_of_Purification, (eObjId)_narmaya.Swap_BladeofPurification               },
            { (eObjId)AllWeaponObjId.Narmaya_Ameno_Habakiri, (eObjId)_narmaya.Swap_AmenoHabakiri                            },

            { (eObjId)AllWeaponObjId.Ghandagoza_Brahma_Gauntlet, (eObjId)_ghandagoza.Swap_BrahmaGauntlet                    },
            { (eObjId)AllWeaponObjId.Ghandagoza_Rope_Knuckles, (eObjId)_ghandagoza.Swap_RopeKnuckles                        },
            { (eObjId)AllWeaponObjId.Ghandagoza_Crimson_Finger, (eObjId)_ghandagoza.Swap_CrimsonFinger                      },
            { (eObjId)AllWeaponObjId.Ghandagoza_Golden_Fists_of_Ura, (eObjId)_ghandagoza.Swap_GoldenFistsOfUra              },
            { (eObjId)AllWeaponObjId.Ghandagoza_Arkab, (eObjId)_ghandagoza.Swap_Arkab                                       },
            { (eObjId)AllWeaponObjId.Ghandagoza_Sky_Piercer, (eObjId)_ghandagoza.Swap_SkyPiercer                            },

            { (eObjId)AllWeaponObjId.Zeta_Spear_of_Arvess, (eObjId)_zeta.Swap_SpearofArvess                                 },
            { (eObjId)AllWeaponObjId.Zeta_Sunspot_Spear, (eObjId)_zeta.Swap_Sunspot_Spear                                   },
            { (eObjId)AllWeaponObjId.Zeta_Brionac, (eObjId)_zeta.Swap_Brionac                                               },
            { (eObjId)AllWeaponObjId.Zeta_Gisla, (eObjId)_zeta.Swap_Gisla                                                   },
            { (eObjId)AllWeaponObjId.Zeta_Huanglong_Spear, (eObjId)_zeta.Swap_HuanglongSpear                                },
            { (eObjId)AllWeaponObjId.Zeta_Gae_Bulg, (eObjId)_zeta.Swap_GaeBulg                                              },

            { (eObjId)AllWeaponObjId.Vaseraga_Great_Scythe_Grynoth, (eObjId)_vaseraga.Swap_GreatScytheGrynoth               },
            { (eObjId)AllWeaponObjId.Vaseraga_Alsarav, (eObjId)_vaseraga.Swap_Alsarav                                       },
            { (eObjId)AllWeaponObjId.Vaseraga_Wurtzite_Scythe, (eObjId)_vaseraga.Swap_WurtziteScythe                        },
            { (eObjId)AllWeaponObjId.Vaseraga_Soul_Eater, (eObjId)_vaseraga.Swap_SoulEater                                  },
            { (eObjId)AllWeaponObjId.Vaseraga_Cosmic_Scythe, (eObjId)_vaseraga.Swap_CosmicScythe                            },
            { (eObjId)AllWeaponObjId.Vaseraga_Ereshkigal, (eObjId)_vaseraga.Swap_Ereshkigal                                 },

            { (eObjId)AllWeaponObjId.Cagliostro_Magnum_Opus, (eObjId)_cagliostro.Swap_MagnumOpus                            },
            { (eObjId)AllWeaponObjId.Cagliostro_Dream_Atlas, (eObjId)_cagliostro.Swap_DreamAtlas                            },
            { (eObjId)AllWeaponObjId.Cagliostro_Transmigration_Tome, (eObjId)_cagliostro.Swap_TransmigrationTome            },
            { (eObjId)AllWeaponObjId.Cagliostro_Sacred_Codex, (eObjId)_cagliostro.Swap_SacredCodex                          },
            { (eObjId)AllWeaponObjId.Cagliostro_Arshivelle, (eObjId)_cagliostro.Swap_Arshivelle                             },
            { (eObjId)AllWeaponObjId.Cagliostro_Zosimos, (eObjId)_cagliostro.Swap_Zosimos                                   },

            { (eObjId)AllWeaponObjId.Id_Ragnarok, (eObjId)_id.Swap_Ragnarok                                                 },
            { (eObjId)AllWeaponObjId.Id_Aviaeth_Faussart, (eObjId)_id.Swap_AviaethFaussart                                  },
            { (eObjId)AllWeaponObjId.Id_Susanoo, (eObjId)_id.Swap_Susanoo                                                   },
            { (eObjId)AllWeaponObjId.Id_Premium_Sword, (eObjId)_id.Swap_PremiumSword                                        },
            { (eObjId)AllWeaponObjId.Id_Ecke_Sachs, (eObjId)_id.Swap_EckeSachs                                              },
            { (eObjId)AllWeaponObjId.Id_Sword_of_Bahamut, (eObjId)_id.Swap_SwordofBahamut                                   },

            { (eObjId)AllWeaponObjId.Sandalphon_Apprentice, (eObjId)_sandalphon.Swap_Apprentice                             },
            { (eObjId)AllWeaponObjId.Sandalphon_World_Ender, (eObjId)_sandalphon.Swap_WorldEnder                             },

            { (eObjId)AllWeaponObjId.Seofon_Sette_di_Spade, (eObjId)_seofon.Swap_SettediSpade                               },
            { (eObjId)AllWeaponObjId.Seofon_Gateway_Star_Sword, (eObjId)_seofon.Swap_GatewayStarSword                       },

            { (eObjId)AllWeaponObjId.Tweyen_Bow_of_Dismissal, (eObjId)_tweyen.Swap_BowofDismissal                           },
            { (eObjId)AllWeaponObjId.Tweyen_Desolation_Crown_Bow, (eObjId)_tweyen.Swap_DesolationCrownBow                   },
        };
    }

    /// <summary>
    /// Contains the config settings for swapping effects.
    /// </summary>
    /// <returns>Dictionary&lt;Source ObjId, Config ObjId&gt;</returns>
    public Dictionary<eObjId, eObjId> GetEffectSwapMap()
    {
        return new()
        {
            { (eObjId)CaptainEffectWeaponObjId.Ascension, (eObjId)_captain.EffectSwap_SwordOfEos                            },
            { (eObjId)CaptainEffectWeaponObjId.Terminus, (eObjId)_captain.EffectSwap_SevenStarSword                         },

            { (eObjId)KatalinaEffectWeaponObjId.Ascension, (eObjId)_katalina.EffectSwap_Murgleis                            },
            { (eObjId)KatalinaEffectWeaponObjId.Terminus, (eObjId)_katalina.EffectSwap_Blutgang                             },

            { (eObjId)RackamEffectWeaponObjId.Ascension, (eObjId)_rackam.EffectSwap_Benedia                                 },
            { (eObjId)RackamEffectWeaponObjId.Terminus, (eObjId)_rackam.EffectSwap_Freikugel                                },

            { (eObjId)IoEffectWeaponObjId.Ascension, (eObjId)_io.EffectSwap_Gambanteinn                                     },
            { (eObjId)IoEffectWeaponObjId.Terminus, (eObjId)_io.EffectSwap_Caduceus                                         },

            { (eObjId)EugenEffectWeaponObjId.Ascension, (eObjId)_eugen.EffectSwap_AK4A                                      },
            { (eObjId)EugenEffectWeaponObjId.Terminus, (eObjId)_eugen.EffectSwap_DraconicFire                               },

            { (eObjId)RosettaEffectWeaponObjId.Ascension, (eObjId)_rosetta.EffectSwap_LoveEternal                           },
            { (eObjId)RosettaEffectWeaponObjId.Flame, (eObjId)_rosetta.EffectSwap_Cortana                                   },
            { (eObjId)RosettaEffectWeaponObjId.Terminus, (eObjId)_rosetta.EffectSwap_DaggerOfBahamutCoda                    },

            { (eObjId)FerryEffectWeaponObjId.Ghostly, (eObjId)_ferry.EffectSwap_Geisterpeitche                              },
            { (eObjId)FerryEffectWeaponObjId.Ascension, (eObjId)_ferry.EffectSwap_EtherealLasher                            },
            { (eObjId)FerryEffectWeaponObjId.Flame, (eObjId)_ferry.EffectSwap_FlameLitCurl                                  },
            { (eObjId)FerryEffectWeaponObjId.Electric, (eObjId)_ferry.EffectSwap_LiveWire                                   },
            { (eObjId)FerryEffectWeaponObjId.Terminus, (eObjId)_ferry.EffectSwap_Erinnerung                                 },

            { (eObjId)LancelotEffectWeaponObjId.Ascension, (eObjId)_lancelot.EffectSwap_KnightOfIce                         },
            { (eObjId)LancelotEffectWeaponObjId.Terminus, (eObjId)_lancelot.EffectSwap_DamascusKnife                        },

            { (eObjId)VaneEffectWeaponObjId.Ascension, (eObjId)_vane.EffectSwap_TreuerKrieger                               },
            { (eObjId)VaneEffectWeaponObjId.Terminus, (eObjId)_vane.EffectSwap_Mjolnir                                      },

            { (eObjId)PercivalEffectWeaponObjId.Ascension, (eObjId)_percival.EffectSwap_LordOfFlames                        },
            { (eObjId)PercivalEffectWeaponObjId.Terminus, (eObjId)_percival.EffectSwap_Gottfried                            },

            { (eObjId)SiegfriedEffectWeaponObjId.Ascension, (eObjId)_siegfried.EffectSwap_Ascalon                           },
            { (eObjId)SiegfriedEffectWeaponObjId.Terminus, (eObjId)_siegfried.EffectSwap_Balmung                            },

            { (eObjId)CharlottaEffectWeaponObjId.Ascension, (eObjId)_charlotta.EffectSwap_Claidheamh                        },
            { (eObjId)CharlottaEffectWeaponObjId.Terminus, (eObjId)_charlotta.EffectSwap_Galatine                           },

            { (eObjId)YodarhaEffectWeaponObjId.Ascension, (eObjId)_yodarha.EffectSwap_FudoKuniyuki                          },
            { (eObjId)YodarhaEffectWeaponObjId.Terminus, (eObjId)_yodarha.EffectSwap_Swordfish                              },

            { (eObjId)NarmayaEffectWeaponObjId.Ascension, (eObjId)_narmaya.EffectSwap_Venustas                              },
            { (eObjId)NarmayaEffectWeaponObjId.Terminus, (eObjId)_narmaya.EffectSwap_AmenoHabakiri                          },

            { (eObjId)GhandagozaEffectWeaponObjId.Ascension, (eObjId)_ghandagoza.EffectSwap_GoldenFistsOfUra                },
            { (eObjId)GhandagozaEffectWeaponObjId.Terminus, (eObjId)_ghandagoza.EffectSwap_SkyPiercer                       },

            { (eObjId)ZetaEffectWeaponObjId.Ascension, (eObjId)_zeta.EffectSwap_Brionac                                     },
            { (eObjId)ZetaEffectWeaponObjId.Terminus, (eObjId)_zeta.EffectSwap_GaeBulg                                      },

            { (eObjId)VaseragaEffectWeaponObjId.Ascension, (eObjId)_vaseraga.EffectSwap_WurtziteScythe                      },
            { (eObjId)VaseragaEffectWeaponObjId.Terminus, (eObjId)_vaseraga.EffectSwap_Ereshkigal                           },

            { (eObjId)CagliostroEffectWeaponObjId.Ascension, (eObjId)_cagliostro.EffectSwap_TransmigrationTome              },
            { (eObjId)CagliostroEffectWeaponObjId.Terminus, (eObjId)_cagliostro.EffectSwap_Zosimos                          },

            { (eObjId)IdEffectWeaponObjId.Ascension, (eObjId)_id.EffectSwap_Susanoo                                         },
            { (eObjId)IdEffectWeaponObjId.Terminus, (eObjId)_id.EffectSwap_PrimalSwordOfBahamut                             },

            // Intentionally no Sandalphon, Seofon, or Tweyen since they only have 1 effect each
        };
    }

    /// <summary>
    /// Contains the config settings for controlling effects, such as toggling on or off.
    /// </summary>
    /// <returns>Dictionary&lt;Source ObjId, Control Type&gt;</returns>
    public Dictionary<eObjId, WeaponEffectControlType> GetEffectControlMap()
    {
        return new()
        {
            { (eObjId)CaptainEffectWeaponObjId.Ascension, _captain.EffectControl_SwordOfEos                           },
            { (eObjId)CaptainEffectWeaponObjId.Terminus, _captain.EffectControl_SevenStarSword                        },

            { (eObjId)KatalinaEffectWeaponObjId.Ascension, _katalina.EffectControl_Murgleis                           },
            { (eObjId)KatalinaEffectWeaponObjId.Terminus, _katalina.EffectControl_Blutgang                            },

            { (eObjId)RackamEffectWeaponObjId.Ascension, _rackam.EffectControl_Benedia                                },
            { (eObjId)RackamEffectWeaponObjId.Terminus, _rackam.EffectControl_Freikugel                               },

            { (eObjId)IoEffectWeaponObjId.Ascension, _io.EffectControl_Gambanteinn                                    },
            { (eObjId)IoEffectWeaponObjId.Terminus, _io.EffectControl_Caduceus                                        },

            { (eObjId)EugenEffectWeaponObjId.Ascension, _eugen.EffectControl_AK4A                                     },
            { (eObjId)EugenEffectWeaponObjId.Terminus, _eugen.EffectControl_DraconicFire                              },

            { (eObjId)RosettaEffectWeaponObjId.Ascension, _rosetta.EffectControl_LoveEternal                          },
            { (eObjId)RosettaEffectWeaponObjId.Flame, (WeaponEffectControlType)_rosetta.EffectControl_Cortana         },
            { (eObjId)RosettaEffectWeaponObjId.Terminus, _rosetta.EffectControl_DaggerOfBahamutCoda                   },

            { (eObjId)FerryEffectWeaponObjId.Ghostly, (WeaponEffectControlType)_ferry.EffectControl_Geisterpeitche    },
            { (eObjId)FerryEffectWeaponObjId.Ascension, _ferry.EffectControl_EtherealLasher                           },
            { (eObjId)FerryEffectWeaponObjId.Flame, (WeaponEffectControlType)_ferry.EffectControl_FlameLitCurl        },
            { (eObjId)FerryEffectWeaponObjId.Electric, (WeaponEffectControlType)_ferry.EffectControl_LiveWire         },
            { (eObjId)FerryEffectWeaponObjId.Terminus, _ferry.EffectControl_Erinnerung                                },

            { (eObjId)LancelotEffectWeaponObjId.Ascension, _lancelot.EffectControl_KnightOfIce                        },
            { (eObjId)LancelotEffectWeaponObjId.Terminus, _lancelot.EffectControl_DamascusKnife                       },

            { (eObjId)VaneEffectWeaponObjId.Ascension, _vane.EffectControl_TreuerKrieger                              },
            { (eObjId)VaneEffectWeaponObjId.Terminus, _vane.EffectControl_Mjolnir                                     },

            { (eObjId)PercivalEffectWeaponObjId.Ascension, _percival.EffectControl_LordOfFlames                       },
            { (eObjId)PercivalEffectWeaponObjId.Terminus, _percival.EffectControl_Gottfried                           },

            { (eObjId)SiegfriedEffectWeaponObjId.Ascension, _siegfried.EffectControl_Ascalon                          },
            { (eObjId)SiegfriedEffectWeaponObjId.Terminus, _siegfried.EffectControl_Balmung                           },

            { (eObjId)CharlottaEffectWeaponObjId.Ascension, _charlotta.EffectControl_Claidheamh                       },
            { (eObjId)CharlottaEffectWeaponObjId.Terminus, _charlotta.EffectControl_Galatine                          },

            { (eObjId)YodarhaEffectWeaponObjId.Ascension, _yodarha.EffectControl_FudoKuniyuki                         },
            { (eObjId)YodarhaEffectWeaponObjId.Terminus, _yodarha.EffectControl_Swordfish                             },

            { (eObjId)NarmayaEffectWeaponObjId.Ascension, _narmaya.EffectControl_Venustas                             },
            { (eObjId)NarmayaEffectWeaponObjId.Terminus, _narmaya.EffectControl_AmenoHabakiri                         },

            { (eObjId)GhandagozaEffectWeaponObjId.Ascension, _ghandagoza.EffectControl_GoldenFistsOfUra               },
            { (eObjId)GhandagozaEffectWeaponObjId.Terminus, _ghandagoza.EffectControl_SkyPiercer                      },

            { (eObjId)ZetaEffectWeaponObjId.Ascension, _zeta.EffectControl_Brionac                                    },
            { (eObjId)ZetaEffectWeaponObjId.Terminus, _zeta.EffectControl_GaeBulg                                     },

            { (eObjId)VaseragaEffectWeaponObjId.Ascension, _vaseraga.EffectControl_WurtziteScythe                     },
            { (eObjId)VaseragaEffectWeaponObjId.Terminus, _vaseraga.EffectControl_Ereshkigal                          },

            { (eObjId)CagliostroEffectWeaponObjId.Ascension, _cagliostro.EffectControl_TransmigrationTome             },
            { (eObjId)CagliostroEffectWeaponObjId.Terminus, _cagliostro.EffectControl_Zosimos                         },

            { (eObjId)IdEffectWeaponObjId.Ascension, _id.EffectControl_Susanoo                                        },
            { (eObjId)IdEffectWeaponObjId.Terminus, _id.EffectControl_PrimalSwordOfBahamut                            },

            { (eObjId)SandalphonEffectWeaponObjId.Terminus, _sandalphon.EffectControl_WorldEnder                      },

            { (eObjId)SeofonEffectWeaponObjId.Terminus, _seofon.EffectControl_GatewayStarSword                        },

            { (eObjId)TweyenEffectWeaponObjId.Terminus, _tweyen.EffectControl_DesolationCrownBow                      },
        };
    }

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
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
#pragma warning restore IDE0079 // Remove unnecessary suppression
    #endregion


}