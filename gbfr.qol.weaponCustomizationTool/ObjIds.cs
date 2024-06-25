using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gbfr.qol.weaponCustomizationTool;

#pragma warning disable IDE1006 // Disables naming rule violation for eObjId, using lowercase here because it matches how the game refers to ObjIds

/// <summary>
/// Contains hex IDs for weapons and characters.
/// </summary>
public enum eObjId : uint
{
    // pl
    PL_Gran_Rebel = 0x10000,
    PL_Gran_Original = 0x10001,
    PL_Djeeta_Rebel = 0x10100,
    PL_Djeeta_Original = 0x10101,
    PL_Katalina = 0x10200,
    PL_Rackam = 0x10300,
    PL_Io = 0x10400,
    PL_Eugen = 0x10500,
    PL_Rosetta = 0x10600,
    PL_Ferry = 0x10700,
    PL_Lancelot = 0x10800,
    PL_Vane = 0x10900,
    PL_Percival = 0x11000,
    PL_Siegfried = 0x11100,
    PL_Charlotta = 0x11200,
    PL_Yodarha = 0x11300,
    PL_Narmaya = 0x11400,
    PL_Ghandagoza = 0x11500,
    PL_Zeta = 0x11600,
    PL_Vaseraga = 0x11700,
    PL_Cagliostro = 0x11800,
    PL_Id = 0x11900,
    PL_Id_Transformation = 0x12000,
    PL_Sandalphon = 0x12100,
    PL_Seofon = 0x12200,
    PL_Tweyen = 0x12300,

    // wp
    WP_Captain_Travellers_Sword = 0x30000u,
    WP_Captain_Durandal = 0x30001u,
    WP_Captain_Sword_of_Eos = 0x30002u,
    WP_Captain_Albacore_Blade = 0x30003u,
    WP_Captain_Ultima_Sword = 0x30004u,
    WP_Captain_Seven_Star_Sword = 0x30005u,
    WP_Captain_Partenza = 0x30100u,

    WP_Katalina_Rukalsa = 0x30200u,
    WP_Katalina_Flame_Rapier = 0x30201u,
    WP_Katalina_Murgleis = 0x30202u,
    WP_Katalina_Luminiera_Sword_Omega = 0x30203u,
    WP_Katalina_Ephemeron = 0x30204u,
    WP_Katalina_Blutgang = 0x30205u,

    WP_Rackam_Flintspike = 0x30300u,
    WP_Rackam_Wheellock_Axe = 0x30301u,
    WP_Rackam_Benedia = 0x30302u,
    WP_Rackam_Tiamat_Bolt_Omega = 0x30303u,
    WP_Rackam_Stormcloud = 0x30304u,
    WP_Rackam_Freikugel = 0x30305u,

    WP_Io_Little_Witch_Scepter = 0x30400u,
    WP_Io_Zhezl = 0x30401u,
    WP_Io_Gambanteinn = 0x30402u,
    WP_Io_Colossus_Cane_Omega = 0x30403u,
    WP_Io_Tupsimati = 0x30404u,
    WP_Io_Caduceus = 0x30405u,

    WP_Eugen_Dreyse = 0x30500u,
    WP_Eugen_Matchlock = 0x30501u,
    WP_Eugen_AK4A = 0x30502u,
    WP_Eugen_Leviathan_Muzzle = 0x30503u,
    WP_Eugen_Clarion = 0x30504u,
    WP_Eugen_Draconic_Fire = 0x30505u,

    WP_Rosetta_Egoism = 0x30600u,
    WP_Rosetta_Swordbreaker = 0x30601u,
    WP_Rosetta_Love_Eternal = 0x30602u,
    WP_Rosetta_Rose_Crystal_Knife = 0x30603u,
    WP_Rosetta_Cortana = 0x30604u,
    WP_Rosetta_Dagger_of_Bahamut_Coda = 0x30605u,

    WP_Ferry_Geisterpeitche = 0x30700u,
    WP_Ferry_Leather_Belt = 0x30701u,
    WP_Ferry_Ethereal_Lasher = 0x30702u,
    WP_Ferry_Flame_Lit_Curl = 0x30703u,
    WP_Ferry_Live_Wire = 0x30704u,
    WP_Ferry_Erinnerung = 0x30705u,

    WP_Lancelot_Altachiara = 0x30800u,
    WP_Lancelot_Hoarfrost_Blade_Persius = 0x30801u,
    WP_Lancelot_Blanc_Comme_Neige = 0x30802u,
    WP_Lancelot_Vegalta = 0x30803u,
    WP_Lancelot_Knight_of_Ice = 0x30804u,
    WP_Lancelot_Damascus_Knife = 0x30805u,

    WP_Vane_Alabarda = 0x30900u,
    WP_Vane_Swan = 0x30901u,
    WP_Vane_Treuer_Krieger = 0x30902u,
    WP_Vane_Ukonvasara = 0x30903u,
    WP_Vane_Blossom_Axe = 0x30904u,
    WP_Vane_Mjolnir = 0x30905u,

    WP_Percival_Flamberge = 0x31000u,
    WP_Percival_Lohengrin = 0x31001u,
    WP_Percival_Antwerp = 0x31002u,
    WP_Percival_Joyeuse = 0x31003u,
    WP_Percival_Lord_of_Flames = 0x31004u,
    WP_Percival_Gottfried = 0x31005u,

    WP_Siegfried_Integrity = 0x31100u,
    WP_Siegfried_Broadsword_of_Earth = 0x31101u,
    WP_Siegfried_Ascalon = 0x31102u,
    WP_Siegfried_Hrunting = 0x31103u,
    WP_Siegfried_Windhose = 0x31104u,
    WP_Siegfried_Balmung = 0x31105u,

    WP_Charlotta_Claiomh_Solais = 0x31200u,
    WP_Charlotta_Arondight = 0x31201u,
    WP_Charlotta_Claidheamh_Soluis = 0x31202u,
    WP_Charlotta_Ushumgal = 0x31203u,
    WP_Charlotta_Sahrivar = 0x31204u,
    WP_Charlotta_Galatine = 0x31205u,

    WP_Yodarha_Kiku_Ichimonji = 0x31300u,
    WP_Yodarha_Asura = 0x31301u,
    WP_Yodarha_Fudo_Kuniyuki = 0x31302u,
    WP_Yodarha_Higurashi = 0x31303u,
    WP_Yodarha_Xeno_Phantom_Demon_Blade = 0x31304u,
    WP_Yodarha_Swordfish = 0x31305u,

    WP_Narmaya_Nakamaki_Nodachi = 0x31400u,
    WP_Narmaya_Kotetsu = 0x31401u,
    WP_Narmaya_Venustas = 0x31402u,
    WP_Narmaya_Flourithium_Blade = 0x31403u,
    WP_Narmaya_Blade_of_Purification = 0x31404u,
    WP_Narmaya_Ameno_Habakiri = 0x31405u,

    WP_Ghandagoza_Brahma_Gauntlet = 0x31500u,
    WP_Ghandagoza_Rope_Knuckles = 0x31501u,
    WP_Ghandagoza_Crimson_Finger = 0x31502u,
    WP_Ghandagoza_Golden_Fists_of_Ura = 0x31503u,
    WP_Ghandagoza_Arkab = 0x31504u,
    WP_Ghandagoza_Sky_Piercer = 0x31505u,

    WP_Zeta_Spear_of_Arvess = 0x31600u,
    WP_Zeta_Sunspot_Spear = 0x31601u,
    WP_Zeta_Brionac = 0x31602u,
    WP_Zeta_Gisla = 0x31603u,
    WP_Zeta_Huanglong_Spear = 0x31604u,
    WP_Zeta_Gae_Bulg = 0x31605u,

    WP_Vaseraga_Great_Scythe_Grynoth = 0x31700u,
    WP_Vaseraga_Alsarav = 0x31701u,
    WP_Vaseraga_Wurtzite_Scythe = 0x31702u,
    WP_Vaseraga_Soul_Eater = 0x31703u,
    WP_Vaseraga_Cosmic_Scythe = 0x31704u,
    WP_Vaseraga_Ereshkigal = 0x31705u,

    WP_Cagliostro_Magnum_Opus = 0x31800u,
    WP_Cagliostro_Dream_Atlas = 0x31801u,
    WP_Cagliostro_Transmigration_Tome = 0x31802u,
    WP_Cagliostro_Sacred_Codex = 0x31803u,
    WP_Cagliostro_Arshivelle = 0x31804u,
    WP_Cagliostro_Zosimos = 0x31805u,

    WP_Id_Ragnarok = 0x31900u,
    WP_Id_Aviaeth_Faussart = 0x31901u,
    WP_Id_Susanoo = 0x31902u,
    WP_Id_Premium_Sword = 0x31903u,
    WP_Id_Ecke_Sachs = 0x31904u,
    WP_Id_Sword_of_Bahamut = 0x31905u,

    WP_Seofon_Sette_di_Spade = 0x32200u,
    WP_Seofon_Gateway_Star_Sword = 0x32206u,

    WP_Tweyen_Bow_of_Dismissal = 0x32300u,
    WP_Tweyen_Desolation_Crown_Bow = 0x32306u,

    WP_Sandalphon_Apprentice = 0x32100u,
    WP_Sandalphon_World_Ender = 0x32106u,
}