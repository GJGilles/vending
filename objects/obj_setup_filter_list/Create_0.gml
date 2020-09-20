/// @description Insert description here
// You can write your code in this editor

var names = ["Color", "Temp", "Flavor", "Prep"];

var t = obj_game.all_traits;
traits = [t.color, t.temp, t.flavor, t.prep];

for (var i = 0; i < array_length(traits); i++) {
	var x_pos = x + i * sprite_get_width(spr_setup_filter_tab);
	var y_pos = y - sprite_get_height(spr_setup_recipe_tab);
	var tab = instance_create_layer(x_pos, y_pos, "Borders", obj_setup_filter_tab);
	tab.name = names[i];
	tab.idx = i;
	tab.depth -= 1;
}


radios = array_create(0);

var cols = 3;
for (var i = 0; i < 6; i++) {
	var x_pos = x + (i % cols) * sprite_get_width(spr_setup_filter_trait) + (floor(i / cols) % 2) * (sprite_width % sprite_get_width(spr_setup_filter_trait));
	var y_pos = y + floor(i / cols) * sprite_get_height(spr_setup_filter_trait);
	var r = instance_create_layer(x_pos, y_pos, "Borders", obj_setup_filter_trait);
	r.idx = i - 1;
	r.name = (i == 0) ? "All" : traits[0][i - 1].name;
	r.depth -= 1;
	radios[array_length(radios)] = r;
}


sel_tab = 0;
filters = [-1, -1, -1, -1];
