/// @description Insert description here
// You can write your code in this editor

if (point_in_rectangle(mouse_x, mouse_y, x + 135, y + 10, x + 145, y + 20)) {
	var sl = obj_setup_selected_list.recipes;
	var num = ds_list_size(sl);
	var idx = ds_list_find_index(sl, id);
	ds_list_delete(sl, idx);
		
	for (var i = idx; i < (num - 1); i++) {
		ds_list_find_value(sl, i).y -= 40;
	}
	
	instance_destroy();
}
