/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && hovered >= 0) {
	var ing = obj_setup_ing_list.ing;
	var num = obj_setup_ing_list.numbers;
	
	var recipe = recipes[hovered];
	var vals = recipe[? "ing"];
	var craftable = recipe[? "craft"];
	
	if (!selected[hovered]) {
		selected[hovered] = 1;
		
		var skip = 0;
		for (var i = 0; i < array_length_1d(vals); i++) {
			if (vals[i] == -1) { 
				skip++;
				continue; 
			}
			if (craftable[i - skip]) { continue; }
			
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
		
		var skip = 0;
		for (var i = 0; i < array_length_1d(vals); i++) {
			if (vals[i] == -1) { 
				skip++;
				continue; 
			}
			if (craftable[i - skip]) { continue; }
			
			for (var j = 0; j < ds_list_size(ing); j++) {
				var idx = ds_list_find_index(ing, vals[i]);
				if (idx != -1) {
					ds_list_set(num, idx, ds_list_find_value(num, idx) - 1);
					if (ds_list_find_value(num, idx) < 1) {
						var inputs = obj_setup_input_list;
						for (var k = 0; k < array_length_1d(inputs.tokens); k++) {
							if (inputs.tokens[k] > idx) {
								inputs.tokens[k]--;
							} else if (inputs.tokens[k] == idx) {
								inputs.tokens[k] = -1;
							}
						}
						
						ds_list_delete(ing, idx);
						ds_list_delete(num, idx);
					}
					break;
				}
			}
		}
	}
}

