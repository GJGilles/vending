function scr_item_draw(argument0, argument1, argument2) {
	var item = argument0;
	var x_pos = argument1;
	var y_pos = argument2;


	draw_sprite(item[? "sprite"], -1, x_pos, y_pos);

	var s = item[? "special"];
	if (array_length_1d(s)) {
		draw_sprite(spr_item_special, -1, x_pos, y_pos)
	}



}
