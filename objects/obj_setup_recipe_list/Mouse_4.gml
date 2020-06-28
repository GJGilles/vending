/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && hovered >= 0) {
	var ing = obj_setup_ing_list.ing;
	var num = obj_setup_ing_list.numbers;
	
	var recipe = obj_game.current_recipies[hovered];
	var vals = recipe[? "ing"];
	var craftable = recipe[? "craft"];
	
	if (!selected[hovered]) {
		selected[hovered] = 1;
		
		for (var i = 0; i < array_length_1d(vals); i++) {
			if (craftable[i]) { continue; }
			
			var exists = false;
			for (var j = 0; j < ds_list_size(ing); j++) {
				var idx = ds_list_find_index(ing, vals[i]);
				if (idx != -1) {
					ds_list_set(num, idx, ds_list_find_value(num, idx) + 1);
					exists = true;
					break;
				}
			}
			if (!exists) {
				ds_list_add(ing, vals[i]);
				ds_list_add(num, 1);
			}
		}
	} else {
		selected[hovered] = 0;
		
		for (var i = 0; i < array_length_1d(vals); i++) {
			if (craftable[i]) { continue; }
			
			for (var j = 0; j < ds_list_size(ing); j++) {
				var idx = ds_list_find_index(ing, vals[i]);
				if (idx != -1) {
					ds_list_set(num, idx, ds_list_find_value(num, idx) - 1);
					if (ds_list_find_value(num, idx) < 1) {
						ds_list_delete(ing, idx);
						ds_list_delete(num, idx);
					}
					break;
				}
			}
		}
	}
}

