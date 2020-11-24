/// @description Insert description here
// You can write your code in this editor

event_inherited();

selected = -1;
hovered = -1;

animo_frame = 0;
animo_len = 60;

locations = array_sort(obj_game.current_locations, true);
for (var i = 0; i < array_length_1d(locations); i++) {
	if (locations[i] == obj_game.current_location) {
		selected = i;
		alarm[0] = 1;
	}
	
	locations[i] = obj_game.all_locations[locations[i]];
}
