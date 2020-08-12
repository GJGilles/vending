/// @description Insert description here
// You can write your code in this editor

y_off = 0;

scr_set_item_specials();

sel_tab = obj_game.all_categories[CategoryEnum.full];

recipes = array_create(0);
height = 0;

var categories = obj_game.all_categories;
var cols = 3;
for (var i = 0; i < array_length_1d(categories); i++) {
	var tab = instance_create_layer(x + (i % cols) * sprite_get_width(spr_setup_tab), y - (floor(i / cols) + 1) * sprite_get_height(spr_setup_tab), "Borders", obj_setup_recipe_tab);
	tab.category = categories[i];
	tab.depth -= 1;
}

scr_create_recipe_list();

