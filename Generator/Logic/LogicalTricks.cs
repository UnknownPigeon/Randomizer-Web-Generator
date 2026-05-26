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

        public static Dictionary<string, string> listOfTricks = new()
        {
            // { Plaintext name, logic name }
            // ex: Generator side: Lake Lantern Cave Without Lantern, logic side: llc_no_lantern
			
            // General Tricks
            { "Destroy Webs With Bombs and Ball and Chain", "webs_with_bombs_bnc" },
            { "Use Bombs and Boomerang To Destroy Out of Reach Rocks", "launch_bombs_with_boomerang" },
            { "Grab Freestanding Items With Ball and Chain", "freestandings_with_bnc" },
            { "Drained Magic Armor As A Substitute for Iron Boots", "drained_MA_as_irons" },
            { "Defeat Shadow Beasts Without MDH", "shadow_beasts_without_mdh" },
			
            // Ordon Tricks
			
            // Faron Tricks
            { "Faron Mist Stump Chest as Wolf", "mist_stump_chest_as_wolf" },
			
            { "Baba Serpent Grotto With Wolf", "baba_serpent_grotto_with_wolf" },
			
            // Eldin Tricks
            { "Kakariko Gorge Double Clawshot Chest as Wolf", "kak_gorge_skip_claws_with_wolf" },
			
            { "Kakariko Village Bomb Rock Spire Heart Piece With Epona and Clawshot", "kak_rock_spire_poh_with_epona_claw" },
            { "Kakariko Village Bomb Rock Spire Heart Piece With Boomerang", "kak_rock_spire_poh_with_boomerang" },
            { "Kakariko Village Watchtower Alcove Chest as Wolf", "watchtower_alcove_chest_as_wolf" },
			
            { "Death Mountain Geysers Shield Skip", "geysers_shield_skip" },
            { "Death Mountain Climb Without Irons", "dm_climb_without_irons" },
			
            { "Bridge of Eldin Owl Statue Chest as Wolf", "bridge_owl_chest_as_wolf" },
			
            { "Eldin Lava Cave Upper Chest With Nothing", "lava_cave_itemless_upper_chest" },
            { "Eldin Lava Cave Wolf Jump to Bottom", "lava_cave_wolf_jump_to_bottom" },
			
            { "Hidden Village Checks Without Clawshot", "hv_without_claw" },
			
            // Lanayru Tricks
            { "Helmasaur Grotto With Only Clawshot", "helmasaur_grotto_with_claw" },
			
            { "Star 1 Without Clawshot", "star_1_without_claw" },
            { "Star 2 Without Double Clawshot", "star_2_without_2_claws" },
			
            { "Outside Castle Town South Double Claw Chest With Wolf", "outside_ct_chasm_with_wolf" },
            { "Outside Castle Town South Double Claw Chest With Sword", "outside_ct_chasm_with_sword" },
            { "Outside Castle Town South Double Claw Chest With Irons", "outside_ct_chasm_with_irons" },
            { "Outside Castle Town South Double Claw Chest Itemless", "outside_ct_chasm_itemless" },
            { "Outside Castle Town South Fountain Chest With Sword + Back Slice", "outside_ct_fountain_with_bs" },
			
            { "Izas Helping Hand With Boomerang", "iza_1_with_boomerang" },
            { "Legendary Hylian Loach With Frog Lure", "loach_with_frog_lure" },
			
			{ "Zoras Domain Underwater Rupees Without Zora Armor", "zd_underwater_rupees_without_za" },
			{ "Zoras Domain Waterfall Ledge With Box and Sword", "zd_waterfall_ledge_box_and_sword" },
            { "Zoras Domain Wafterfall Ledge With Spinner", "zd_waterfall_ledge_spinner" },
            { "Underwater Goron Without Zora Armor", "underwater_goron_without_za" },
			
            { "Lake Lantern Cave Without Lantern", "llc_no_lantern" },
            { "Shell Blade Grotto With Normal Bombs", "shell_blade_grotto_normal_bombs" },
            { "Water Toadpoli Grotto With Wolf", "toadpoli_grotto_with_wolf" },
			
            // Desert Tricks
            { "Bulblin Camp Boar With Irons", "camp_boar_with_irons" },
			
            // Snowpeak Tricks
			
            // Forest Temple
            { "Forest Temple Lobby Without Ranged Items", "ft_lobby_without_ranged_items" },
            { "Forest Temple Lobby With Wolf", "ft_lobby_with_wolf" },
            { "Forest Temple West Wing With Bombling", "ft_west_wing_bombling" },
            { "Forest Temple North Tile Worm Boost To Chest", "ft_north_tile_worm_boost" },
            { "Forest Temple North Wing With Bomb Boosts", "ft_north_bomb_boosts" },
            { "Forest Temple Ook access With Midna", "ft_ook_with_midna" },
			
			// Goron Mines
            { "Defeat Fyrus Without Sword", "fyrus_without_sword" },
            { "Defeat Fyrus Without Irons", "fyrus_without_irons" },
            
			// Lakebed Temple
            { "Lakebed Temple Chandelier Drop", "lbt_chandelier_drop" },
            { "Lakebed Temple Big Key Chest Without Bombs", "lbt_bk_without_bombs" },
            { "Lakebed Temple Big Key Skip", "lbt_bk_skip" },
            { "Defeat Morpheel Without Sword", "morpheel_without_sword" },
            
			// Arbiters Grounds
            { "Arbiters Grounds Entrance Chain Without Clawshot", "ag_entrance_chain_without_claw" },
            { "Arbiters Grounds Pillar Jump", "ag_pillar_jump" },
            { "Arbiters Grounds Big Key With Wolf", "ag_bk_with_wolf" },
            
			// Snowpeak Ruins
            { "Snowpeak Ruins Lobby Chandelier Chest Without Wolf", "spr_lobby_chandelier_without_wolf" },
            { "Snowpeak Ruins Northeast Chandelier Chest With Back Slice", "spr_ne_chandelier_with_bs" },
            { "Snowpeak Ruins Ladder Freezard Cancel", "spr_ladder_freezard_cancel" },
            
			// Temple of Time
            { "Temple of Time Crystal Switches With Clawshot", "tot_crystal_switches_with_claw" },
            
			// City in the Sky
            { "City in the Sky Entrance Crystal Switch With Ball and Chain", "cits_entrance_with_bnc" },
            { "City in the Sky Fan Skip", "cits_fan_skip" },
            { "City in the Sky Central Occa Room With No Items", "cits_itemless_central_room" },
            { "City in the Sky East Wing First Room With No Items", "cits_itemless_east_first_room" },
            { "City in the Sky Dinalfos Room With Clawshot", "cits_dinalfos_with_claw" },
            { "City in the Sky Central Outside Ledge Chest With Clawshot", "cits_central_outside_ledge_chest_with_claw" },
			{ "City in the Sky Compass Chest With Double Clawshots", "cits_compass_chest_with_2_claws" },
            { "City in the Sky North Wing With Double Clawshots", "cits_north_with_2_claws" },
            
			// Palace of Twilight
            
			// Hyrule Castle
            { "Hyrule Castle Skip Main Hall Barrier", "hc_skip_main_hall_barrier" },
            { "Hyrule Castle Chandeliers With Single Clawshot", "hc_chandeliers_with_1_claw" },
            { "Hyrule Castle Painting Switch With Bombs", "hc_painting_switch_with_bombs" },
            { "Hyrule Castle Painting Switch With Jump Strike", "hc_painting_switch_with_js" },
            { "Hyrule Castle Painting Switch With Back Slice", "hc_painting_switch_with_bs" },
            { "Hyrule Castle Tower Climb With Single Clawshot", "hc_tower_climb_with_1_claw" },
            { "Defeat Dark Beast Ganon Without Wolf", "beast_ganon_without_wolf" },
        };
    }
}
