/// @description Insert description here
// You can write your code in this editor

draw_self();

for (var i = 0; i < array_length_1d(recipes); i++) {
	var entry = recipes[i];
	var result = obj_game.all_items[entry[? "result"]];
	
	if (i == hovered) {
		draw_sprite(spr_recipe_hover, 0, x_origin, y_origin + (i * 16));
	} else if (selected[i]) {
		draw_sprite(spr_recipe_hover, 1, x_origin, y_origin + (i * 16));
	}
	
	scr_item_draw(result, x_origin + 8, y_origin + (i * 16) + 8);
	
	write_text(scr_item_name(result), x_origin + 16, y_origin + (i * 16) + 4, FontEnum.silkscreen);
}
