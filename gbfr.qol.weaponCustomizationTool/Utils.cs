using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gbfr.qol.weaponCustomizationTool;

public class Utils
{
    public static uint GetObjIdCategory(eObjId objId)
        => (uint)objId >> 16;

    public static bool HasEffect(eObjId objId)
    {
        return WeaponEffects.AllGlowWeapons.Contains(objId);
    }

    public static string GetObjIdCategoryPrefixString(eObjId objId)
    {
        uint category = GetObjIdCategory(objId);
        return category switch
        {
            0x01 => $"pl",
            0x02 => $"em",
            0x03 => $"wp",
            0x04 => $"et",
            0x05 => $"ef",
            0x07 => $"it",
            0x09 => $"sc",
            0x0C => $"bg",
            0x0E => $"bh",
            0x0F => $"ba",
            0x100 => $"fp",
            0x101 => $"fe",
            0x102 => $"fn",
            0x103 => $"we",
            0x104 => $"wn",
            0x10A => $"np",
            0x10B => $"tr",
            0x10C => $"bt",
            _ => throw new ArgumentException($"Invalid object id category {category}", nameof(objId))
        };
    }

    public static string ObjIdToModelId(eObjId objId)
    {
        uint modelId = (uint)objId & 0xFFFF;

        string categoryStr = GetObjIdCategoryPrefixString(objId);
        return $"{categoryStr}{modelId:X4}";
    }

    public static bool IsCharacterWeapon(eObjId charaId, eObjId weaponObjId)
    {
        if ((uint)charaId >> 16 != 1)
            throw new ArgumentException("Not a char id.", nameof(charaId));

        if ((uint)weaponObjId >> 16 != 3)
            throw new ArgumentException("Not a weapon id.", nameof(weaponObjId));

        return ((uint)charaId & 0x0000FF00) == ((uint)weaponObjId & 0x0000FF00);
    }

    public static string GetObjModelInfoPath(eObjId objId)
    {
        string prefix = GetObjIdCategoryPrefixString(objId);
        string modelId = ObjIdToModelId(objId);
        return $"model/{prefix}/{modelId}/{modelId}.minfo";
    }

    public static string ObjIdToSheathId(eObjId objId)
    {
        // Skips Katalina, Gran+Djeeta rebelwear, Gran default, Rosetta, and Yodarha because hiding sheaths is hardcoded into the executable

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

        eObjId characterId = WeaponObjIdToCharacterId(objId);
        char sheathPrefix;
        string sheathId;

        if (characterId == eObjId.PL_Gran_Rebel) // only messing with the default outfit but not rebelwear or any of Gran since they have a single large sheath each
        {
            sheathPrefix = 'b';

            if (objId == eObjId.WP_Captain_Partenza)
            {
                sheathId = $"{sheathPrefix}00_sheath";
            }
            else
            {
                sheathId = $"{sheathPrefix}10_sheath";
            }
        }
        else if (characterId == eObjId.PL_Narmaya) // Narmaya
        {
            sheathPrefix = 'a';
            char modelId = $"{((uint)objId & 0xFFFF):X4}"[^1]; // Grabs last number

            sheathId = $"{sheathPrefix}{modelId}0_sheath";
        }
        else
        {
            throw new ArgumentException($"Character {characterId} does not have a swappable sheath, this method should not have been called");
        }

        return sheathId;
    }

    public static eObjId WeaponObjIdToCharacterId(eObjId weaponId)
    {
        if ((uint)weaponId >> 16 != 3)
            throw new ArgumentException("Not a weapon id.", nameof(weaponId));

        return (eObjId)(0x10000 + ((uint)weaponId & 0x0000FF00));
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

}
