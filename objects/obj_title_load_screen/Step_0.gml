/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (obj_game.mouse == id && point_in_rectangle(mouse_x, mouse_y, bbox_left + 16, bbox_top + 16, bbox_right - 16, bbox_bottom - 16)) {
	var idx = floor((mouse_y - (bbox_top + 16)) / 32);
	hovered = idx;
} else {
	hovered = -1;
}
