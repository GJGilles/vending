function scr_create_recipe_list() {

	instance_destroy(obj_setup_recipe_item);
	
	var rl = obj_setup_recipe_list;
	var fl = obj_setup_filter_list;
	
	var tab = rl.sel_tab[? "recipes"];
	var recipes = [];

	for (var i = 0; i < array_length(obj_game.current_components); i++) {
		var component = obj_game.current_components[i];
	
		var recipe_arr = component[? "recipes"];
		if (recipe_arr == -1) { continue; }
	
		for (var k = 0; k < array_length(recipe_arr); k++) {
			var recipe = obj_game.all_recipes[recipe_arr[k]];
			var ing = recipe[? "ing"];
	
			var found = false;
			for (var j = 0; j < array_length(tab); j++) {
				if (recipe[? "id"] == tab[j]) {
					found = true;
					break;
				}
			}
		
			if (!found) {
				continue;
			}
			
			
			var filtered = false;
			var res = obj_game.all_items[recipe[? "result"]];
			var traits = [res[? "color"], res[? "temp"], res[? "flavor"], res[? "prep"]];
			for (var j = 0; j < array_length(traits); j++) {
				if (fl.filters[j] != -1 && fl.filters[j] != traits[j]) {
					filtered = true;
					break;
				} 
			}
			
			if (filtered) {
				continue;
			}
		
		
			for (var j = 0; j < array_length(ing); j++) {
				var idx = ing[j];
				if (idx == -1) { continue; }
				var a = obj_game.all_items[idx];
		
				var contains = false;
				for (var k = 0; k < array_length(obj_game.current_ingredients); k++) {
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
				recipes[array_length(recipes)] = instance_create_layer(rl.x + 5, rl.y + (array_length(recipes) * 32), "Instances", obj_setup_recipe_item);
				recipes[array_length(recipes) - 1].recipe = recipe;
				recipes[array_length(recipes) - 1].depth -=1;
			}
		}
	}

	return recipes;
}
