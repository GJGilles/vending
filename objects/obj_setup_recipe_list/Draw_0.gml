/// @description Insert description here
// You can write your code in this editor

draw_self();

var recipes = obj_game.current_recipies;
for (var i = 0; i < array_length_1d(recipes); i++) {
	var entry = recipes[i];
	var result = obj_game.all_items[entry[? "result"]];
	
	if (i == hovered) {
		draw_sprite(spr_recipe_hover, 0, x_origin, y_origin + (i * 16));
	} else if (selected[i]) {
		draw_sprite(spr_recipe_hover, 1, x_origin, y_origin + (i * 16));
	}
	
	draw_sprite(result[? "sprite"], -1, x_origin + 8, y_origin + (i * 16) + 8);
	
	draw_set_font(fnt_ken_mini_8);
	draw_set_color(c_black);
	draw_text(x_origin + 16, y_origin + (i * 16), result[? "name"]);
}
