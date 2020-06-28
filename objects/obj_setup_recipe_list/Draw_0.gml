/// @description Insert description here
// You can write your code in this editor

draw_self();

var recipes = obj_game.current_recipies;
for (var i = 0; i < array_length_1d(recipes); i++) {
	var entry = recipes[i];
	
	if (i == hovered) {
		draw_sprite(spr_recipe_hover, 0, x_origin, y_origin + (i * 32));
	} else if (selected[i]) {
		draw_sprite(spr_recipe_hover, 1, x_origin, y_origin + (i * 32));
	}
	
	draw_sprite(entry[? "sprite"], -1, x_origin + 20, y_origin + (i * 32) + 12);
	
	draw_set_font(fnt_ken_mini_8);
	draw_set_color(c_black);
	draw_text(x_origin + 40, y_origin + (i * 32) + 5, entry[? "name"]);
}
