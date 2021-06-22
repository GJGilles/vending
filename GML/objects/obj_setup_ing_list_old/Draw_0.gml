/// @description Insert description here
// You can write your code in this editor

draw_self();

for (var i = 0; i < ds_list_size(ing); i++) {
	var idx = ds_list_find_value(ing, i);
	var item = obj_game.all_items[idx];
	
	scr_item_draw(item, x_origin + 8, y_origin + (i * 16) + 8);
	
	write_text(scr_item_name(item), x_origin + 16, y_origin + (i * 16), FontEnum.silkscreen);
}
