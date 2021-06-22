/// @description Insert description here
// You can write your code in this editor

var location = obj_game.all_locations[obj_game.current_location];
var layouts = location[? "layouts"];
var map = layouts[0];

var inputs = 0;
for (var i = 0; i < array_height_2d(map); i++) {
	for (var j = 0; j < array_length_2d(map, i); j++) {
		var entry = map[i, j];
		if (entry[0] == IOEnum.input) { inputs++; }
	}
}


tokens = array_create(inputs, -1);
dragging = -1;
