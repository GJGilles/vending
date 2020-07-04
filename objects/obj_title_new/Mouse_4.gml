/// @description Insert description here
// You can write your code in this editor

with obj_game {
	var length = array_length_1d(all_components);
	var idx = 0;
	for (var i = 0; i < length; i++) {
		var comp = all_components[i];
		var comp_id = comp[? "id"];
		if (comp_id == ComponentEnum.item_in) { continue; }
		if (comp_id == ComponentEnum.item_out) { continue; }
	
		current_components[idx] = comp;
		idx++;
	}

	current_recipies = all_recipes;

	//room_goto(rm_factory);
	room_goto(rm_setup);
}
