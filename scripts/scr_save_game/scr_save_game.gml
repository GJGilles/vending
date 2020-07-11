var slot = string(argument0);

with obj_game {
	ini_open(slot + "_save.ini");

	// Resources
	ini_write_real("resources", "money", money);
	ini_write_real("resources", "mana", max_mana);

	// Time
	ini_write_real("time", "year", year);
	ini_write_real("time", "month", month);
	ini_write_real("time", "day", day);

	// Weather
	for (var i = 0; i < array_length_1d(all_regions); i++) {
		var region = all_regions[i];
		var weather = region[? "weather"];
	
		var j = 0;
		var temp = ds_queue_create();
		while (!ds_queue_empty(weather)) {
			var elem = ds_queue_dequeue(weather);
			ini_write_real("weather", string(i) + "-" + string(j) + "-0", elem[0]);
			ini_write_real("weather", string(i) + "-" + string(j) + "-1", elem[1]);
			ds_queue_enqueue(temp, elem);
			j++
		}
	
		while (!ds_queue_empty(temp)) { ds_queue_enqueue(weather, ds_queue_dequeue(temp)); }
		ds_queue_destroy(temp);
	}

	// Location
	ini_write_real("location", "region", current_region);
	ini_write_real("location", "location", current_location);

	// Component Unlocks
	for (var i = 0; i < array_length_1d(current_components); i++) {
		var elem = current_components[i];
		ini_write_real("component", string(i), elem[? "id"]);
	}

	// Recipe Unlocks
	for (var i = 0; i < array_length_1d(current_recipies); i++) {
		var elem = current_recipies[i];
		ini_write_real("recipe", string(i), elem[? "id"]);
	}

	// Popular
	ini_write_real("popular", "0", popular[0]);
	ini_write_real("popular", "1", popular[1]);
	
	// Datetime
	ini_write_real("datetime", "write", date_current_datetime());
	
	// Stats
	ini_write_string("stats", "grid", ds_grid_write(item_stats));

	ini_close();
}
