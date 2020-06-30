/// @description Insert description here
// You can write your code in this editor

draw_self();

var count = array_create(ds_list_size(obj_setup_ing_list.ing), 0);
for (var i = 0; i < array_length_1d(tokens); i++) {
	var idx = tokens[i];
	
	var x_pos = x;
	var y_pos = y + (16 * i);
	
	if (dragging == i) { // follow mouse
		x_pos = mouse_x - 8; 
		y_pos = mouse_y - 8;
	} else if (idx != -1) { 
		x_pos = obj_setup_ing_list.bbox_right - (8 * (5 - count[idx]));
		y_pos = obj_setup_ing_list.y_origin + (16 * idx);
		count[idx]++;
	}
	
	draw_sprite(spr_input_token, -1, x_pos, y_pos);
	write_text(string(i), x_pos + 5, y_pos + 1);
}
