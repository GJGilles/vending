/// @description 
// You can write your code in this editor

slot_width = 10;
slot_height = 9;

slots = array_create(0);

var location = obj_game.all_locations[obj_game.current_location];
var layouts = location[? "layouts"];
var map = layouts[0];

var inputs = obj_factory_setup.ordered_items;
var idx = 0;

for (var i = 0; i < array_height_2d(map); i++) {
	for (var j = 0; j < array_length_2d(map, i); j++) {
		var entry = map[i, j];
		switch (entry[0]) {
			case IOEnum.any:
				slots[i, j] = instance_create_layer(x + i * TILE_SIZE - 16, y + j * TILE_SIZE - 16, "Factory", obj_slot);
				break;
			case IOEnum.input:
				slots[i, j] = instance_create_layer(x + i * TILE_SIZE - 16, y + j * TILE_SIZE - 16, "Factory", obj_slot_input);
				slots[i, j].rotation = entry[1];
				slots[i, j].item = inputs[idx];
				idx++;
				break;
			case IOEnum.output:
				slots[i, j] = instance_create_layer(x + i * TILE_SIZE - 16, y + j * TILE_SIZE - 16, "Factory", obj_slot_output);
				slots[i, j].rotation = entry[1];
				break;
			case IOEnum.none:
			default:
				slots[i, j] = instance_create_layer(x + i * TILE_SIZE - 16, y + j * TILE_SIZE - 16, "Factory", obj_slot_null);
				break;
		}
	}
}

for (var i = 0; i < array_height_2d(map); i++) {
	for (var j = 0; j < array_length_2d(map, i); j++) {
		var slot = slots[i, j];
		if (i != 0)							   { slot.directions[2] = slots[i - 1, j]; }
		if (i != array_height_2d(map) - 1)     { slot.directions[0] = slots[i + 1, j]; }
		if (j != 0)							   { slot.directions[1] = slots[i, j - 1]; }
		if (j != array_length_2d(map, i) - 1)  { slot.directions[3] = slots[i, j + 1]; }
	}
}
