/// @description Insert description here
// You can write your code in this editor

draw_self();

var region = obj_game.all_regions[obj_game.current_region];
var locs = region[? "locs"];
var location = locs[obj_game.current_location];
var layouts = location[? "layouts"];
var map = layouts[0];

for (var i = 0; i < array_height_2d(map); i++) {
	for (var j = 0; j < array_length_2d(map, i); j++) {
		var entry = map[i, j];
		draw_sprite_ext(spr_minmap_item, entry[0], x + (i * 16) + 8, y + (j * 16) + 8, 1, 1, entry[1] * 90, c_white, 1);
	}
}
