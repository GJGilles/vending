/// @description Insert description here
// You can write your code in this editor

// Needs collision
if (obj_game.mouse == id) {
	var h = sprite_get_height(spr_inventory_mid); 
	var top = (CAMERA_HEIGHT / 2) - (max_size / 2) * h;
	var camera = view_get_camera(0);
	var idx = floor((mouse_y - camera_get_view_y(camera) - top) / h);
	if (0 <= idx && idx < max_size) {
		selected = idx;
	}
}
