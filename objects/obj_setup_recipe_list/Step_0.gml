/// @description Insert description here
// You can write your code in this editor

event_inherited();

hovered = -1;
if (obj_game.mouse == id) {
	var idx = floor((mouse_y - y_origin) / 16);
	if (idx < array_length_1d(recipes)) {
		hovered = idx;
	}
}
