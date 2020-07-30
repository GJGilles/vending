/// @description Insert description here
// You can write your code in this editor

var inputs = obj_setup_input_list;
if (inputs.dragging != -1) {
	var idx = floor((mouse_y - y_origin) / 16);
	if (idx < ds_list_size(ing)) {
		inputs.tokens[inputs.dragging] = idx;
		inputs.dragging = -1;
	}
}