/// @description Insert description here
// You can write your code in this editor

draw_self();

draw_set_font(fnt_ken_mini_8);
draw_set_color(c_black);
for (var i = 0; i < array_length_1d(tokens); i++) {
	var idx = tokens[i];
	
	var x_pos = x;
	var y_pos = y + (16 * i);
	
	if (dragging == i) { // follow mouse
		x_pos = mouse_x - 8; 
		y_pos = mouse_y - 8;
	} else if (idx != -1) { 
		x_pos = obj_setup_ing_list.x;
		y_pos = obj_setup_ing_list.y_origin + (16 * idx);
	}
	
	draw_sprite(spr_input_token, -1, x_pos, y_pos);
	draw_text(x_pos + 5, y_pos + 1, string(i));
}
