/// @description Insert description here
// You can write your code in this editor

if (point_in_rectangle(mouse_x, mouse_y, bbox_left, bbox_top, bbox_right, bbox_bottom)) {
	if (obj_game.mouse == -1 || obj_game.mouse.depth > depth) { 
		obj_game.mouse = id; 
	}
} else if (obj_game.mouse == id) { 
	obj_game.mouse = -1; 
}
