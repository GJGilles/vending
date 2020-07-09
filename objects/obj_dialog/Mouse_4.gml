/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && point_in_rectangle(mouse_x, mouse_y, bbox_right - 32, bbox_top, bbox_right, bbox_top + 32)) {
	instance_destroy();
}
