using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gbfr.qol.weaponCustomizationTool;

/// <summary>
/// Utilities mostly for various ObjId conversions and bool checks.
/// </summary>
public class Utils
{
    /// <summary>
    /// Checks if the provided weapon has a glow effect.<br />
    /// Will return false if the weapon only has a callselector effect,
    /// or if it has no effects.
    /// </summary>
    /// <param name="weaponObjId"></param>
    /// <returns>True or False</returns>
    public static bool HasGlowEffect(eObjId weaponObjId)
    {
        return WeaponEffects.AllGlowWeapons.Contains(weaponObjId);
    }

    /// <summary>
    /// Grabs ObjId category uint from full eObjId.
    /// </summary>
    /// <param name="objId"></param>
    /// <returns></returns>
    public static uint GetObjIdCategory(eObjId objId)
        => (uint)objId >> 16;

    /// <summary>
    /// Grabs ObjId category string value from full eObjId.
    /// </summary>
    /// <param name="objId"></param>
    /// <returns>2 letter category string</returns>
    /// <exception cref="ArgumentException">Invalid object id category</exception>
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

    /// <summary>
    /// Converts full eObjId value to its string equivalent.
    /// </summary>
    /// <param name="objId"></param>
    /// <returns>"{category string}{ID number}"</returns>
    public static string ObjIdToModelId(eObjId objId)
    {
        uint modelId = (uint)objId & 0xFFFF;

        string categoryStr = GetObjIdCategoryPrefixString(objId);
        return $"{categoryStr}{modelId:X4}";
    }

    /// <summary>
    /// Checks if the provided weapon belongs to the provided character.
    /// </summary>
    /// <param name="characterObjId">Character eObjId</param>
    /// <param name="weaponObjId">Weapon eObjId</param>
    /// <returns>True or False</returns>
    /// <exception cref="ArgumentException">Value is either not a character id or not a weapon id</exception>
    public static bool IsCharacterWeapon(eObjId characterObjId, eObjId weaponObjId)
    {
        if ((uint)characterObjId >> 16 != 1)
            throw new ArgumentException("Not a char id.", nameof(characterObjId));

        if ((uint)weaponObjId >> 16 != 3)
            throw new ArgumentException("Not a weapon id.", nameof(weaponObjId));

        return ((uint)characterObjId & 0x0000FF00) == ((uint)weaponObjId & 0x0000FF00);
    }

    /// <summary>
    /// Gets the path for the provided model's minfo file.
    /// </summary>
    /// <param name="objId">Model eObjId</param>
    /// <returns>"model/{category}/{modelId}/{modelId}.minfo"</returns>
    public static string GetObjModelInfoPath(eObjId objId)
    {
        string prefix = GetObjIdCategoryPrefixString(objId);
        string modelId = ObjIdToModelId(objId);
        return $"model/{prefix}/{modelId}/{modelId}.minfo";
    }

    /// <summary>
    /// Returns the matching sheath ID for the provided weapon ObjId.
    /// </summary>
    /// <param name="objId">Weapon eObjId</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Either the weapon's character doesn't have a supported sheath or the provided ObjId isn't a weapon.</exception>
    public static string ObjIdToSheathId(eObjId objId)
    {
        // Skips Katalina, Gran+Djeeta rebelwear, Gran default, Rosetta, and Yodarha because hiding sheaths is hardcoded into the executable

        /// Weapons that Hide Sheaths
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

        // Should be noted this is only for retrieving the sheath ID.
        // ProcessSheathSwap only modifies PL_Djeeta_Original, but WeaponObjIdToCharacterId wouldn't return a matching value for that model.
        if (characterId == eObjId.PL_Gran_Rebel || characterId == eObjId.PL_Djeeta_Rebel)
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

    /// <summary>
    /// Returns the matching Character eObjId for the provided Weapon eObjId
    /// </summary>
    /// <param name="weaponId"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static eObjId WeaponObjIdToCharacterId(eObjId weaponId)
    {
        if ((uint)weaponId >> 16 != 3)
            throw new ArgumentException("Not a weapon id.", nameof(weaponId));

        return (eObjId)(0x10000 + ((uint)weaponId & 0x0000FF00));
    }

    /// <summary>
    /// Gets the possible paths for the provided model's files.<br />
    /// Used for overwriting models directly, but that isn't<br />
    /// the preferred model swap method. Use info.objread<br />
    /// editing instead where possible.
    /// </summary>
    /// <param name="modelId"></param>
    /// <returns></returns>
    //static List<string> ObjIdToModelPaths(string modelId)
    //{
    //    string category = modelId[..2];

    //    List<string> paths = [];

    //    List<string> filePathFormats =
    //    [
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
    //    ];

    //    foreach (var format in filePathFormats)
    //    {
    //        paths.Add(string.Format(format, category, modelId));
    //    }

    //    return paths;
    //}

}
