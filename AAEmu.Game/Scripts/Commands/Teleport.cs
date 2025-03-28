﻿using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Managers.World;
using AAEmu.Game.Models.Game;
using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Core.Packets.G2C;
using System.Collections.Generic;
using AAEmu.Game.Models.Game.Teleport;
using AAEmu.Game.Utils.Scripts;

namespace AAEmu.Game.Scripts.Commands;

public class Teleport : ICommand
{
    public List<TPloc> locations = new();
    public bool AllowPingPos { get; set; } = true; // Enable or Disable /teleport . (dot) command functionality

    public void OnLoad()
    {
        CommandManager.Instance.Register("teleport", this);

        loadLocations();
    }

    public string GetCommandLineHelp()
    {
        return "[location]";
    }

    public string GetCommandHelpText()
    {
        if (AllowPingPos)
            return
                "Teleports you to target location. if no [location] is provided, you will get a list of available names. " +
                "You can also use a period (.) as a location name to teleport to a location you marked on the map.";
        else
            return "Teleports you to target location. if no [location] is provided, you will get a list of available names.";
    }

    public void loadLocations()
    {
        #region west
        // West
        // locations.Add(new TPloc { Region = TeleReg.West, Name = "aubrecradle", Info = "Aubre Cradle, Ironwrought", X = 7664, Y = 12957, Z = 400 });//228,71
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "cinderstone",
            Info = "Cinderstone Moor, Seachild Wharf",
            X = 15400,
            Y = 11543,
            Z = 107,
            AltNames = new string[] { "cinder" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "dewstone",
            Info = "Dewstone Plains, Sandcloud",
            X = 12204,
            Y = 13305,
            Z = 178,
            AltNames = new string[] { "dew" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "gweonid",
            Info = "Gweonid Forest, Memoria",
            X = 10604,
            Y = 14925,
            Z = 280,
            AltNames = new string[] { "gwen" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "halcyona",
            Info = "Halcyona, Suns End",
            X = 9342,
            Y = 10321,
            Z = 187,
            AltNames = new string[] { "halcy" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "hellswamp",
            Info = "Hellswamp, Anarchi",
            X = 7482,
            Y = 9853,
            Z = 189,
            AltNames = new string[] { "hell" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "karkasse",
            Info = "Karkasse Ridgelands, Lavis",
            X = 10470,
            Y = 17346,
            Z = 186,
            AltNames = new string[] { "kar", "karkase" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "lilyut",
            Info = "Lilyut Hills, Windshade",
            X = 12666,
            Y = 15520,
            Z = 165,
            AltNames = new string[] { "lily", "lili" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "marianople",
            Info = "Marianople, Marianople",
            X = 11144,
            Y = 12066,
            Z = 145,
            AltNames = new string[] { "maria", "west" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "sanddeep",
            Info = "Sanddeep, Golden Fable Harbor",
            X = 10720,
            Y = 9591,
            Z = 105,
            AltNames = new string[] { "sand" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "solzreed",
            Info = "Solzreed Peninsula, Cresent Throne",
            X = 15369,
            Y = 13864,
            Z = 159,
            AltNames = new string[] { "solz" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "twocrowns",
            Info = "Two Crowns, Ezna",
            X = 13500,
            Y = 10531,
            Z = 223,
            AltNames = new string[] { "2c", "twoc" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.West,
            Name = "whitearden",
            Info = "White Arden, Birchkeep",
            X = 9682,
            Y = 12775,
            Z = 161,
            AltNames = new string[] { "arden" }
        });
        #endregion

        #region east
        // East
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "arcumiris",
            Info = "Arcum Iris, Parchsun Settlement",
            X = 20509,
            Y = 7173,
            Z = 193,
            AltNames = new string[] { "arcum" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "falcorth",
            Info = "Falcorth Plains, Oxion Clan",
            X = 23818,
            Y = 9102,
            Z = 589
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "rokhala",
            Info = "Rokhala Plains",
            X = 28057,
            Y = 10005,
            Z = 866
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "hasla",
            Info = "Hasla, Veroe",
            X = 30029,
            Y = 8760,
            Z = 539
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "mahadevi",
            Info = "Mahadevi, City of Towers",
            X = 19284,
            Y = 8620,
            Z = 227,
            AltNames = new string[] { "maha" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "perinoor",
            Info = "Perinor Ruins, Stonehew",
            X = 27787,
            Y = 6732,
            Z = 572,
            AltNames = new string[] { "peri", "perinor" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "rookborne",
            Info = "Rookborne Basin, Watermist",
            X = 25388,
            Y = 9753,
            Z = 714,
            AltNames = new string[] { "rook", "rookborn" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "silentforest",
            Info = "Silent Forest, Count Sebastians Retreat",
            X = 23306,
            Y = 12526,
            Z = 271,
            AltNames = new string[] { "sf", "silent" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "solis",
            Info = "Solis Headlands, Austera",
            X = 16743,
            Y = 9018,
            Z = 120,
            AltNames = new string[] { "austera", "east" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "tigerspine",
            Info = "Tigerspine Mountains, Anvilton",
            X = 21772,
            Y = 8089,
            Z = 404,
            AltNames = new string[] { "tiger" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "villanelle",
            Info = "Villanelle, Lutesong Harbor",
            X = 21178,
            Y = 10604,
            Z = 119,
            AltNames = new string[] { "villa" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "windscour",
            Info = "Windscour Savanah, Skyfang",
            X = 25926,
            Y = 6855,
            Z = 362,
            AltNames = new string[] { "windscoure", "ws" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.East,
            Name = "ynyster",
            Info = "Ynystere, Caernord",
            X = 20931,
            Y = 13158,
            Z = 116,
            AltNames = new string[] { "yny" }
        });
        #endregion

        #region origin
        // Auroria
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "calmlands",
            Info = "Calmlands",
            X = 22349,
            Y = 24941,
            Z = 189
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "oshcastle",
            Info = "Osh Castle",
            X = 17257,
            Y = 27516,
            Z = 141,
            AltNames = new string[] { "oc" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "wastelandofcorvus",
            Info = "Wasteland of Corvus",
            X = 19611,
            Y = 28288,
            Z = 295,
            AltNames = new string[] { "woc" }

        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "blooddewgorge",
            Info = "Blooddew Gorge",
            X = 23422,
            Y = 27719,
            Z = 179,
            AltNames = new string[] { "bg" }

        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "diamondshores",
            Info = "Diamond Shores",
            X = 19332,
            Y = 26883,
            Z = 130,
            AltNames = new string[] { "ds", "auroria", "origin" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "exeloch",
            Info = "Exeloch",
            X = 22349,
            Y = 24941,
            Z = 189,
            AltNames = new string[] { "exe" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "goldenruins",
            Info = "Golden Ruins",
            X = 17230,
            Y = 27501,
            Z = 141,
            AltNames = new string[] { "golden" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "heedmar",
            Info = "Heedmar",
            X = 20110,
            Y = 24568,
            Z = 156
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "marcala",
            Info = "Marcala",
            X = 20140,
            Y = 24768,
            Z = 189
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "nuimari",
            Info = "Nuimari",
            X = 21731,
            Y = 23751,
            Z = 146
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "reedwind",
            Info = "Reedwind",
            X = 19628,
            Y = 28339,
            Z = 295
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Auroria,
            Name = "sungold",
            Info = "Sungold Fields",
            X = 22122,
            Y = 26412,
            Z = 163
        });
        // locations.Add(new TPloc { Region = TeleReg.Origin, Name = "whalesong", Info = "Whalesong Harbor", X = 14436, Y = 26696, Z = 135, altNames = ("whale"} });
        #endregion

        #region misc
        // Others
        // locations.Add(new TPloc { Region = TeleReg.Other, Name = "aegisisland", Info = "Aegis Island", X = 14436, Y = 26696, Z = 134, altNames = ("aegis"} });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "freedich",
            Info = "Sunspeck Sea, Freedich Island",
            X = 20944,
            Y = 18799,
            Z = 134,
            AltNames = new string[] { "freeditch", "free" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "growlgate",
            Info = "Stormraw Sound, Growlgate Island",
            X = 15138,
            Y = 22983,
            Z = 105,
            AltNames = new string[] { "pirate" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "ynys",
            Info = "Arcadian Sea, Ynys Island, Docks",
            X = 16570,
            Y = 14885,
            Z = 102
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "nuiajail",
            Info = "Marianople, Guard Barracks",
            X = 10860,
            Y = 11950,
            Z = 132,
            AltNames = new string[] { "nuianjail", "westjail" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "haranyajail",
            Info = "Solis Headlands, Isle of Penance",
            X = 17000,
            Y = 9566,
            Z = 135,
            AltNames = new string[] { "haranijail", "eastjail" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "nuian",
            Info = "Solzreed, Nuian Starter Area",
            X = 15578,
            Y = 15382,
            Z = 128
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "elf",
            Info = "Gweonid Forest, Elven Starter Area",
            X = 10388,
            Y = 15982,
            Z = 370
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "harani",
            Info = "Arcum Iris, Harani Starting Area",
            X = 19304,
            Y = 7646,
            Z = 215,
            AltNames = new string[] { "harihana" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Other,
            Name = "firran",
            Info = "Falcorth Plains, Firran Starting Area",
            X = 23881,
            Y = 10495,
            Z = 592,
            AltNames = new string[] { "ferre" }
        });
        #endregion

        #region dungeons
        // Dungeons
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Dungeons,
            Name = "sharpwind",
            Info = "Dewstone Plains, Sharpwind Mines",
            X = 11375,
            Y = 13135,
            Z = 146,
            AltNames = new string[] { "sm", "gsm", "mines" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Dungeons,
            Name = "burnt",
            Info = "Cinderstone, Burnt Castle Armory",
            X = 15683,
            Y = 12590,
            Z = 170,
            AltNames = new string[] { "bc", "bca", "gbc", "castle", "orchidna" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Dungeons,
            Name = "cellar",
            Info = "Mahadevi, City of Towers, Palace Cellar",
            X = 19317,
            Y = 8512,
            Z = 198,
            AltNames = new string[] { "pc", "gpc", "sewer" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Dungeons,
            Name = "hadir",
            Info = "Ynystere, Hadir Farm",
            X = 20022,
            Y = 12777,
            Z = 140,
            AltNames = new string[] { "hf", "ghf", "farm" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Dungeons,
            Name = "cradle",
            Info = "Rookborne Basin, Kroloal Cradle",
            X = 26862,
            Y = 9042,
            Z = 777,
            AltNames = new string[] { "kc", "gkc", "kroloal", "kroloa", "koala" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Dungeons,
            Name = "abyss",
            Info = "Hellswamp, Howling Abyss",
            X = 7800,
            Y = 10315,
            Z = 251,
            AltNames = new string[] { "ha", "gha", "howling" }
        });
        locations.Add(new TPloc
        {
            Region = TeleportCommandRegions.Dungeons,
            Name = "serpentis",
            Info = "Exeloch, Serpentis",
            X = 23041,
            Y = 25848,
            Z = 142,
            AltNames = new string[] { "snake", "snek" }
        });
        #endregion
    }

    public void Execute(Character character, string[] args, IMessageOutput messageOutput)
    {
        if (args.Length == 1)
        {
            var n = args[0].ToLower();

            if (AllowPingPos && (n == "."))
            {
                if ((character.LocalPingPosition.X == 0f) && (character.LocalPingPosition.Y == 0f))
                {
                    character.SendMessage("|cFFFFFF00[Teleport] Make sure you marked a location on the map WHILE IN A PARTY OR RAID, before using this teleport function.\n" +
                        "If required, you can use the /soloparty command to make a party of just yourself.|r");
                }
                else
                {
                    var height = WorldManager.Instance.GetHeight(character.Transform.ZoneId, character.LocalPingPosition.X, character.LocalPingPosition.Y);
                    if (height == 0f)
                    {
                        character.SendMessage("|cFFFF0000[Teleport] Target height was |cFFFFFFFFzero|cFFFF0000. " +
                            "You likely tried to teleport out of bounds, or no heightmaps where loaded on the server.\n" +
                            "If you still want to move to the target location, you can use |cFFFFFFFF/move|cFFFF0000 to go to the following location|cFF40FF40\n" +
                            "X:" + character.LocalPingPosition.X.ToString("0.0") + " Y:" + character.LocalPingPosition.Y.ToString("0.0") + "|r");
                    }
                    else
                    {
                        height += 2.5f; // compensate a bit for terrain irregularities
                        character.SendMessage("Teleporting to |cFFFFFFFFX:" + character.LocalPingPosition.X + " Y:" + character.LocalPingPosition.Y + " Z:" + height + "|r");
                        character.ForceDismount();
                        character.DisabledSetPosition = true;
                        character.SendPacket(new SCTeleportUnitPacket(TeleportReason.Portal, ErrorMessageType.NoErrorMessage, character.LocalPingPosition.X, character.LocalPingPosition.Y, height, 0));
                    }
                }
            }
            else
            if (character.InstanceId != WorldManager.DefaultInstanceId)
            {
                character.SendMessage("|cFFFFFF00[Teleport] Named teleports are not allowed inside a instance.|r");
            }
            else
            {
                bool foundIt = false;
                foreach (TPloc item in locations)
                {
                    if (item.Name == n)
                    {
                        foundIt = true;
                    }
                    else if (item.AltNames != null)
                    {
                        foreach (string alt in item.AltNames)
                        {
                            if (alt == n)
                            {
                                foundIt = true;
                                break;
                            }
                        }
                    }
                    if (foundIt)
                    {
                        character.SendMessage("Teleporting to |cFFFFFFFF" + item.Info + "|r");
                        character.ForceDismount();
                        character.DisabledSetPosition = true;
                        character.SendPacket(new SCTeleportUnitPacket(TeleportReason.Portal, ErrorMessageType.NoErrorMessage, item.X, item.Y, item.Z, 0));

                        break;
                    }
                }
                if (!foundIt)
                {
                    character.SendMessage("|cFFFF0000[Teleport] Unavailable Location [" + args[0] + "]|r");
                }
            }
        }
        else
        {
            if (AllowPingPos)
                character.SendMessage("Usage : " + CommandManager.CommandPrefix + "teleport <Location>\n" +
                                      "Use a period (.) to teleport to YOUR marked location on the map, " +
                                      "or use one of the following locations :");
            /*else
                character.SendMessage("Usage : " + CommandManager.CommandPrefix + "teleport <Location>\n" +
                                      "Teleport to one of the following locations :"); */

            List<string> sb = new List<string>();
            foreach (TeleportCommandRegions r in System.Enum.GetValues(typeof(TeleportCommandRegions)))
                sb.Add("|cFFFFFFFF" + r.ToString() + "|r: ");
            foreach (TPloc item in locations)
            {
                sb[(int)item.Region] += item.Name + "  ";
            }
            foreach (string s in sb)
                character.SendMessage(s + "\n");
        }
    }

    public enum TeleportCommandRegions { East = 0, West = 1, Auroria = 2, Dungeons = 3, Other = 4 }

    public class TPloc
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string[] AltNames { get; set; }
        public TeleportCommandRegions Region { get; set; }
    }
}
