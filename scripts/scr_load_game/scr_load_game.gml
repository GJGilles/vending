var slot = string(argument0);

with obj_game {
	ini_open(slot + "_save.ini");

	// Resources
	money = ini_read_real("resources", "money", money);
	max_mana = ini_read_real("resources", "mana", max_mana);

	// Time
	year = ini_read_real("time", "year", year);
	month = ini_read_real("time", "month", month);
	day = ini_read_real("time", "day", day);

	// Weather
	for (var i = 0; i < array_length_1d(all_regions); i++) {
		var region = all_regions[i];
		var weather = region[? "weather"];
	
		while(!ds_queue_empty(weather)) { ds_queue_dequeue(weather); }
	
		for (var j = 0; j < 7; j++) {
			var temp = ini_read_real("weather", string(i) + "-" + string(j) + "-0", 25);
			var percip = ini_read_real("weather", string(i) + "-" + string(j) + "-1", 0);
			ds_queue_enqueue(weather, [temp, percip]);
		}
	}

	// Location
	current_region = ini_read_real("location", "region", current_region);
	current_location = ini_read_real("location", "location", current_location);

	// Component Unlocks
	{
		current_components = [];
	
		var i = 0;
		while (ini_key_exists("component", string(i))) {
			current_components[i] = all_components[ini_read_real("component", string(i), -1)];
			i++;
		}
	}

	// Recipe Unlocks
	{
		current_recipies = [];
	
		var i = 0;
		while (ini_key_exists("recipe", string(i))) {
			current_recipies[i] = all_recipes[ini_read_real("recipe", string(i), -1)];
			i++;
		}
	}

	// Popular
	popular[0] = ini_read_real("popular", "0", popular[0]);
	popular[1] = ini_read_real("popular", "1", popular[1]);
	
	// Stats
	ds_grid_read(item_stats, ini_read_string("stats", "grid", ""));

	ini_close();
}

room_goto(rm_setup);
