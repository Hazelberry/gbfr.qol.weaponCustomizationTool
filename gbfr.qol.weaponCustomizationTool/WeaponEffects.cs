
using System.Net.Http.Headers;

namespace gbfr.qol.weaponCustomizationTool
{
    public class WeaponEffects
    {
        private static readonly List<string> formats = new()
        {
                "effect/savedata/{0}/2000.est", // 0
                "effect/savedata/{0}/2005.est", // 1
                "effect/savedata/{0}/2010.est", // 2
                "effect/savedata/{0}/2020.est", // 3
                "effect/savedata/{0}/2110.est", // 4
                "effect/savedata/{0}/2120.est", // 5
                "effect/savedata/{0}/2001.est", // 6, only used by Narmaya's Terminus
                "effect/savedata/{0}/2002.est", // 7, only used by Narmaya's Terminus
        };

        public static Dictionary<string, string> AscensionWeapons()
        {
            Dictionary<string, string> ascensionWeapons = new()
            {
                { "Captain",    "wp0002" }, // Sword of Eos
                { "Katalina",   "wp0202" }, // Murgleis
                { "Rackam",     "wp0302" }, // Benedia
                { "Io",         "wp0402" }, // Gambanteinn
                { "Eugen",      "wp0502" }, // Ak-4A
                { "Rosetta",    "wp0602" }, // Love Eternal
                { "Ferry",      "wp0705" }, // Erinnerung
                { "Lancelot",   "wp0804" }, // Knight of Ice
                { "Vane",       "wp0902" }, // Treuer Krieger
                { "Percival",   "wp1004" }, // Lord of Flames
                { "Siegfried",  "wp1102" }, // Ascalon
                { "Charlotta",  "wp1202" }, // Claidheamh Soluis
                { "Yodarha",    "wp1302" }, // Fudo-Kuniyuki
                { "Narmaya",    "wp1402" }, // Venustas
                { "Ghandagoza", "wp1503" }, // Golden Fists of Ura
                { "Zeta",       "wp1602" }, // Brionac
                { "Vaseraga",   "wp1702" }, // Wurtzite Scythe
                { "Cagliostro", "wp1802" }, // Transmigration Tome
                { "Id",         "wp1902" }, // Susanoo
            };

            return ascensionWeapons;
        }

        public static Dictionary<string, string> TerminusWeapons()
        {
            Dictionary<string, string> terminusWeapons = new()
            {
                { "Captain",    "wp0005" }, // Seven-Star Sword
                { "Katalina",   "wp0205" }, // Blutgang
                { "Rackam",     "wp0305" }, // Freikugel
                { "Io",         "wp0405" }, // Caduceus
                { "Eugen",      "wp0505" }, // Draconic Fire
                { "Rosetta",    "wp0605" }, // Dagger of Bahamut Coda
                { "Ferry",      "wp0702" }, // Ethereal Lasher
                { "Lancelot",   "wp0805" }, // Damascus Knife
                { "Vane",       "wp0905" }, // Mjolnir
                { "Percival",   "wp1005" }, // Gottfried
                { "Siegfried",  "wp1105" }, // Balmung
                { "Charlotta",  "wp1205" }, // Galatine
                { "Yodarha",    "wp1305" }, // Swordfish
                { "Narmaya",    "wp1405" }, // Ameno Habakiri
                { "Ghandagoza", "wp1505" }, // Sky Piercer
                { "Zeta",       "wp1605" }, // Gae Bulg
                { "Vaseraga",   "wp1705" }, // Ereshkigal
                { "Cagliostro", "wp1805" }, // Zosimos
                { "Id",         "wp1905" }, // Sword of Bahamut
                { "Sandalphon", "wp2106" }, // World Ender
                { "Seofon",     "wp2206" }, // Gateway-Star Sword
                { "Tweyen",     "wp2306" }, // Desolation-Crown Bow
            };

            return terminusWeapons;
        }

        public static Dictionary<string, string> FerryGlowWeapons()
        {
            Dictionary<string, string> ferryGlowWeapons = new()
            {
                { "Ascension",      AscensionWeapons()["Ferry"] },
                { "Terminus",       TerminusWeapons()["Ferry"] },
                { "Ghostly",        "wp0700" }, // Geisterpeitche
                { "Flame",          "wp0703" }, // Flame Lit Curl
                { "Electric",       "wp0704" }, // Live Wire
            };

            return ferryGlowWeapons;
        }

        public static Dictionary<string, string> RosettaGlowWeapons()
        {
            Dictionary<string, string> rosettaGlowWeapons = new()
            {
                { "Ascension",  AscensionWeapons()["Rosetta"] },
                { "Terminus",   TerminusWeapons()["Rosetta"] },
                { "Flame",      "wp0604" }, // Cortana
            };

            return rosettaGlowWeapons;
        }

        public static List<string> AllGlowWeapons()
        {
            List<string> allGlowWeapons = new()
            {
                AscensionWeapons()["Captain"],
                TerminusWeapons()["Captain"],
                AscensionWeapons()["Katalina"],
                TerminusWeapons()["Katalina"],
                AscensionWeapons()["Rackam"],
                TerminusWeapons()["Rackam"],
                AscensionWeapons()["Io"],
                TerminusWeapons()["Io"],
                AscensionWeapons()["Eugen"],
                TerminusWeapons()["Eugen"],
                RosettaGlowWeapons()["Ascension"],
                RosettaGlowWeapons()["Flame"],
                RosettaGlowWeapons()["Terminus"],
                FerryGlowWeapons()["Ghostly"],
                FerryGlowWeapons()["Ascension"],
                FerryGlowWeapons()["Flame"],
                FerryGlowWeapons()["Electric"],
                FerryGlowWeapons()["Terminus"],
                AscensionWeapons()["Lancelot"],
                TerminusWeapons()["Lancelot"],
                AscensionWeapons()["Vane"],
                TerminusWeapons()["Vane"],
                AscensionWeapons()["Percival"],
                TerminusWeapons()["Percival"],
                AscensionWeapons()["Siegfried"],
                TerminusWeapons()["Siegfried"],
                AscensionWeapons()["Charlotta"],
                TerminusWeapons()["Charlotta"],
                AscensionWeapons()["Yodarha"],
                TerminusWeapons()["Yodarha"],
                AscensionWeapons()["Narmaya"],
                TerminusWeapons()["Narmaya"],
                AscensionWeapons()["Ghandagoza"],
                TerminusWeapons()["Ghandagoza"],
                AscensionWeapons()["Zeta"],
                TerminusWeapons()["Zeta"],
                AscensionWeapons()["Vaseraga"],
                TerminusWeapons()["Vaseraga"],
                AscensionWeapons()["Cagliostro"],
                TerminusWeapons()["Cagliostro"],
                AscensionWeapons()["Id"],
                TerminusWeapons()["Id"],
                TerminusWeapons()["Sandalphon"],
                TerminusWeapons()["Seofon"],
                TerminusWeapons()["Tweyen"],
            };

            return allGlowWeapons;
        }

        public static Dictionary<string, char> FerryCallSelectorSuffixes()
        {
            Dictionary<string, char> ferryAttackEffects = new()
            {
                { FerryGlowWeapons()["Ghostly"],    '0' }, // wp0700
                { "wp0701",                         '0' }, // Leather belt, doesn't have normal effects only a callselector/attack effect
                { FerryGlowWeapons()["Terminus"],   '4' }, // wp0702, only character to have a weird terminus number
                { FerryGlowWeapons()["Flame"],      '2' }, // wp0703
                { FerryGlowWeapons()["Electric"],   '3' }, // wp0704
                { FerryGlowWeapons()["Ascension"],  '1' }, // wp0705
            };

            return ferryAttackEffects;
        }

        public static Dictionary<string, List<string>> EffectDictionary()// => effectFiles = new()
        {
            Dictionary<string, List<string>> effectFiles = new Dictionary<string, List<string>>()
            {
                {
                    AscensionWeapons()["Captain"],
                    new List<string>()
                    {
                        formats[0],
                        formats[2],
                        formats[3],
                        formats[3],
                        formats[4],
                        formats[5],
                    }
                },
                {
                    TerminusWeapons()["Captain"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                        formats[4],
                        formats[5],
                    }
                },
                {
                    AscensionWeapons()["Katalina"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Katalina"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Rackam"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Rackam"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Io"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Io"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Eugen"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Eugen"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Rosetta"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    RosettaGlowWeapons()["Flame"],
                    new List<string>()
                    {
                        formats[0],
                    }
                },
                {
                    TerminusWeapons()["Rosetta"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    FerryGlowWeapons()["Ghostly"],
                    new List<string>()
                    {
                        formats[0],
                    }
                },
                {
                    AscensionWeapons()["Ferry"],
                    new List<string>()
                    {
                        formats[1],
                        formats[2],
                        formats[3],
                    }
                },
                {
                    FerryGlowWeapons()["Flame"],
                    new List<string>()
                    {
                        formats[0],
                    }
                },
                {
                    FerryGlowWeapons()["Electric"],
                    new List<string>()
                    {
                        formats[0],
                        formats[1],
                    }
                },
                {
                    TerminusWeapons()["Ferry"],
                    new List<string>()
                    {
                        formats[0],
                        formats[1],
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Lancelot"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Lancelot"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Vane"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Vane"],
                    new List<string>()
                    {
                        formats[0],
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Percival"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Percival"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Siegfried"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Siegfried"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Charlotta"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Charlotta"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Yodarha"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Yodarha"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Narmaya"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Narmaya"],
                    new List<string>()
                    {
                        formats[0],
                        formats[6],
                        formats[7],
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Ghandagoza"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Ghandagoza"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Zeta"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Zeta"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Vaseraga"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Vaseraga"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Cagliostro"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Cagliostro"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    AscensionWeapons()["Id"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Id"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Sandalphon"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Seofon"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                },
                {
                    TerminusWeapons()["Tweyen"],
                    new List<string>()
                    {
                        formats[2],
                        formats[3],
                    }
                }
            };

            return effectFiles;
        }
    }
}
