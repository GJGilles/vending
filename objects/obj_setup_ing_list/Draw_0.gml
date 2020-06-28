/// @description Insert description here
// You can write your code in this editor

draw_self();

for (var i = 0; i < ds_list_size(ing); i++) {
	var idx = ds_list_find_value(ing, i);
	var item = obj_game.all_items[idx];
	
	draw_sprite(item[? "sprite"], -1, x_origin + 8, y_origin + (i * 16) + 8);
	
	draw_set_font(fnt_ken_mini_8);
	draw_set_color(c_black);
	draw_text(x_origin + 16, y_origin + (i * 16), item[? "name"]);
}
