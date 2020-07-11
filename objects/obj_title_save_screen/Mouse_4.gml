/// @description Insert description here
// You can write your code in this editor

//event_inherited();
if (obj_game.mouse == id && point_in_rectangle(mouse_x, mouse_y, bbox_right - 32, bbox_top, bbox_right, bbox_top + 32)) {
	instance_destroy();
}

if (obj_game.mouse == id) {
	selected = hovered;
	scr_dialog_create(obj_dialog_confirm, scr_confirm_save);
}
