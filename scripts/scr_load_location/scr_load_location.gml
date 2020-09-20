function scr_load_location(argument0) {
	var slot = string(argument0);

	ini_open(slot + "_save.ini");

	var current_region = obj_game.all_regions[ini_read_real("location", "region", 0)];
	var locs = current_region[? "locs"];
	var current_location = locs[ini_read_real("location", "location", 0)];

	ini_close();

	return [current_region[? "name"], current_location[? "name"]];


}
