/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (dragging != -1 && !point_in_rectangle(mouse_x, mouse_y, obj_setup_ing_list.bbox_left, bbox_top, bbox_right, bbox_bottom)) {
	dragging = -1;	
}
