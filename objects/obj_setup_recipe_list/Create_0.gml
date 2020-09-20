/// @description Insert description here
// You can write your code in this editor

y_off = 0;

scr_set_item_specials();

sel_tab = obj_game.all_categories[CategoryEnum.full];

recipes = array_create(0);
height = 0;

var categories = obj_game.all_categories;
var cols = 3;
for (var i = 0; i < array_length(categories); i++) {
	var x_pos = x + (i % cols) * sprite_get_width(spr_setup_recipe_tab) + (floor(i / cols) % 2) * sprite_get_width(spr_setup_filler_tab);
	var y_pos = y - (floor(i / cols) + 1) * sprite_get_height(spr_setup_recipe_tab);
	var tab = instance_create_layer(x_pos, y_pos, "Borders", obj_setup_recipe_tab);
	tab.category = categories[i];
	tab.depth -= 1;
}

for (var i = 0; i < array_length(categories) / cols; i++) {
	var x_pos = x + ((i + 1) % 2) * cols * sprite_get_width(spr_setup_recipe_tab);
	var y_pos = y - (i + 1) * sprite_get_height(spr_setup_recipe_tab);
	var tab = instance_create_layer(x_pos, y_pos, "Borders", obj_setup_filler_tab);
	tab.depth -= 1;
}

scr_create_recipe_list();

