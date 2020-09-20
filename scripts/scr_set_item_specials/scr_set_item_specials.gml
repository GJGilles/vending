function scr_set_item_specials() {

	var items = obj_game.all_items;
	var spec = obj_game.all_special;
	var recipes = obj_game.all_recipes;

	var region = obj_game.current_region;
	var month = obj_game.month;

	for (var i = 0; i < array_length_1d(items); i++) {
		var it = items[i];
		it[? "special"] = [];
	}

	for (var i = 0; i < array_length_1d(spec); i++) {
		var s = spec[i];
		if (s == -1) { continue; }
	
		var r = s[? "region"];
		var m = s[? "months"];
	
		if (r == region && m[month]) {
			var it = items[i];
			var arr = it[? "special"];
			arr[array_length_1d(arr)] = s;
			it[? "special"] = arr;
		}
	}

	for (var i = 0; i < array_length_1d(recipes); i++) {
		var rec = recipes[i];
		var it = items[rec[? "result"]];
		var s = it[? "special"];
		var ings = rec[? "ing"];
	
		for (var j = 0; j < array_length_1d(ings); j++) {
			if (ings[j] == -1) { continue; }
			var ing = items[ings[j]];
		
			var arr = ing[? "special"];
			for (var k = 0; k < array_length_1d(arr); k++) {
				s[array_length_1d(s)] = arr[k];
			}
			it[? "special"] = s;
		}
	}



}
