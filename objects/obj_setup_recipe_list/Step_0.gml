/// @description Insert description here
// You can write your code in this editor

event_inherited();

hovered = -1;
if (obj_game.mouse == id) {
	var idx = floor((mouse_y - y_origin) / 32);
	if (idx < array_length_1d(obj_game.current_recipies)) {
		hovered = idx;
	}
}