using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TPRandomizer.SSettings.Enums;

namespace TPRandomizer
{
    public class LogicTricks
    {
        public static Dictionary<string, int> generateTrickList()
        {
            Dictionary<string, int> trickDict = new();
            var tricks = listOfTricks.Keys.ToList();
            for (int i = 0; i < tricks.Count; i++)
            {
                trickDict.Add(" " + tricks[i], i);
            }
            return trickDict;
        }

        public static Dictionary<string, string> listOfTricks =
            new()
            {
                // { Plaintext name , logic name }
                // ex: Generator side: Lake Lantern Cave Without Lantern , logic side: llc_no_lantern
                // General Tricks
                { "Destroy Webs With Bombs and Ball and Chain", "" },
                { "Use Bombs and Boomerang To Destroy Out of Reach Rocks", "" },
                { "Grab Freestanding Items With Ball and Chain", "" },
                { "Drained Magic Armor As A Substitute for Iron Boots", "" },
                { "Defeat Shadow Beasts Without MDH", "" },
                // Ordon Tricks
                // Faron Tricks
                { "Faron Mist Stump Chest as Wolf", "" },
                { "Baba Serpent Grotto With Sword", "" },
                { "Baba Serpent Grotto With Wolf", "" },
                // Eldin Tricks
                { "Death Mountain Geysers Shield Skip", "" },
                { "Death Mountain Climb Without Irons", "" },
                { "Eldin Lava Cave Upper Chest With Nothing", "" },
                { "Eldin Lava Cave Wolf Jump to Bottom", "" },
                { "Kakariko Village Watchtower Alcove Chest as Wolf", "" },
                { "Kakariko Village Bomb Rock Spire Heart with Epona and Claw", "" },
                { "Kakariko Village Rock Spire Heart Piece with Boomerang", "" },
                { "Kakariko Gorge Double Clawshot Chest as Wolf", "" },
                { "Bridge of Eldin Owl Statue Chest as Wolf", "" },
                { "Hidden Village Checks Without Clawshot", "" },
                // Lanayru Tricks
                { "Helmasaur Grotto with Clawshot", "" },
                { "Izas Helping Hand With Boomerang", "" },
                { "Underwater Goron Without Zora Armor", "" },
                { "Lake Lantern Cave Without Lantern", "llc_no_lantern" },
                { "Outside Castle Town South Double Claw Chest With Wolf", "" },
                { "Outside Castle Town South Double Claw Chest With Sword", "" },
                { "Outside Castle Town South Double Claw Chest With Irons", "" },
                { "Outside Castle Town South Double Claw Chest Itemless", "" },
                { "Outside Castle Town South Fountain Chest With Sword + Back Slice", "" },
                { "Shell Blade Grotto With Normal Bombs", "" },
                { "Star 1 Without Clawshot", "" },
                { "Star 2 Without Double Clawshot", "" },
                { "Water Toadpoli Grotto with Wolf", "" },
                { "Zoras Domain Box Jump", "" },
                // Desert Tricks
                { "Bulblin Camp Boar with only Irons", "" },
                // Snowpeak Tricks
                // Forest Temple
                { "Forest Temple Lobby Without Ranged Items", "" },
                { "Forest Temple Lobby with Wolf", "" },
                { "Forest Temple West Wing With Bombling", "" },
                { "Forest Temple North Tile Worm Boost To Chest", "" },
                { "Forest Temple North Wing With Bomb Boosts", "" },
                { "Forest Temple Ook access with Midna", "" },
                // Goron Mines
                { "Defeat Fyrus Without Sword", "" },
                { "Defeat Fyrus withow Bow", "" },
                // Lakebed Temple
                { "Lakebed Temple Chandelier Drop", "" },
                { "Lakebed Temple Central Room With Enemy LJAs", "" },
                { "Defeat Morpheel Without Sword", "" },
                { "Lakebed Temple Big Key Chest Without Bombs", "" },
                { "Lakebed Temple Big Key Skip", "" },
                // Arbiters Grounds
                { "Arbiters Grounds Poe 1 Skip", "" },
                { "Arbiters Grounds Big Key with Wolf", "" },
                { "Arbiters Grounds Entrance Chain without Clawshot", "" },
                // Snowpeak Ruins
                { "Snowpeak Ruins Ladder Freezard Cancel", "" },
                { "Snowpeak Ruins Northeast Chandelier Chest With Backslice", "" },
                { "Snowpeak Ruins Lobby Chandelier Chest Without Wolf", "" },
                // Temple of Time
                { "Temple of Time Activate Crystal Switches With Clawshot", "" },
                // City in the Sky
                { "City in the Sky Fan Skip", "" },
                { "City in the Sky Central Room With No Items", "" },
                { "City in the Sky Entrance Crystal Switch with Ball and Chain", "" },
                { "City in the Sky East Wing First Room with No Items", "" },
                { "City in the Sky North Wing With Double Clawshots", "" },
                { "City in the Sky Dinalfos Room with Clawshot", "" },
                { "City in the Sky Central Outside Ledge Chest With Clawshot", "" },
                // Palace of Twilight
                // Hyrule Castle
                { "Hyrule Castle Painting Switch With Bombs", "" },
                { "Hyrule Castle Painting Switch with Jump Strike", "" },
                { "Hyrule Castle Painting Switch With Back Slice", "" },
                { "Hyrule Castle Skip Main Hall Barrier", "" },
                { "Hyrule Castle Chandeliers with Single Clawshot", "" },
                { "Hyrule Castle Tower Climb with Single Clawshot", "" },
                { "Defeat Dark Beast Ganon without Wolf", "" },
            };
    }
}
