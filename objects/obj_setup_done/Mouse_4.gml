/// @description Insert description here
// You can write your code in this editor

var inputs = obj_setup_input_list;
var ing = obj_setup_ing_list;

for (var i = 0; i < array_length_1d(inputs.tokens); i++) {
	var idx = inputs.tokens[i]; 
	if (idx != -1) {
		var item = ds_list_find_value(ing.ing, idx);
		
		obj_factory_stats.ordered_items[i] = item;
		obj_factory_stats.ordered_speeds[i] = 1;
	} else {
		obj_factory_stats.ordered_items[i] = ItemEnum.junk;
		obj_factory_stats.ordered_speeds[i] = 1;
	}
}

room_goto(rm_factory);
