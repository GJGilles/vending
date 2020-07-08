/// @description Insert description here
// You can write your code in this editor

x_origin = x;
y_origin = y;


recipes = array_create(0);
for (var i = 0; i < array_length_1d(obj_game.all_recipes); i++) {
	var recipe = obj_game.all_recipes[i];
	var ing = recipe[? "ing"];
	
	var found = true;
	for (var j = 0; j < array_length_1d(ing); j++) {
		var a = obj_game.all_items[ing[j]];
		
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
		recipes[array_length_1d(recipes)] = recipe;
	}
}

hovered = -1;
selected = array_create(array_length_1d(recipes), 0);
