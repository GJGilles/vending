/// @description Insert description here
// You can write your code in this editor

event_inherited();
if (obj_game.mouse == id && !point_in_rectangle(mouse_x, mouse_y, bbox_left, bbox_top + top, bbox_right, bbox_bottom - bot)) {
	obj_game.mouse = -1;
}

