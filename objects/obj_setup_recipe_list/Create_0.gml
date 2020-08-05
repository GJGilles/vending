/// @description Insert description here
// You can write your code in this editor

y_off = 0;

scr_set_item_specials();

recipes = array_create(0);
for (var i = 0; i < array_length_1d(obj_game.current_components); i++) {
	var component = obj_game.current_components[i];
	var recipe_arr = component[? "recipes"];
	if (recipe_arr == -1) { continue; }
	
	for (var k = 0; k < array_length_1d(recipe_arr); k++) {
		var recipe = obj_game.all_recipes[recipe_arr[k]];
		var ing = recipe[? "ing"];
	
		var found = true;
		for (var j = 0; j < array_length_1d(ing); j++) {
			var idx = ing[j];
			if (idx == -1) { continue; }
			var a = obj_game.all_items[idx];
		
			var contains = false;
			for (var k = 0; k < array_length_1d(obj_game.current_ingredients); k++) {
				var b = obj_game.current_ingredients[k];
				if (a[? "id"] == b[? "id"]) {
					contains = true;
					break;
				}
			}
		
			if (!contains) {
				found = false;
				break;
			}
		}
	
		if (found) {
			recipes[array_length_1d(recipes)] = instance_create_layer(x + 5, y + (array_length_1d(recipes) * 32), "Instances", obj_setup_recipe_item);
			recipes[array_length_1d(recipes) - 1].recipe = recipe;
		}
	}
}


height = array_length_1d(recipes) * 32;
