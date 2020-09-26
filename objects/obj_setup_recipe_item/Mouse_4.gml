/// @description Insert description here
// You can write your code in this editor


if (point_in_rectangle(mouse_x, mouse_y, x + 135, y + 10, x + 145, y + 20)) {
	var sl = obj_setup_selected_list.recipes;
	var num = ds_list_size(sl);
	if (sel == -1) {
		sel = instance_create_layer(obj_setup_selected_list.x + 10, obj_setup_selected_list.y + 20 + (40 * num), "Borders", obj_setup_selected_item);
		sel.recipe = id;
		ds_list_add(sl, sel);
	} else {
		var idx = ds_list_find_index(sl, sel);
		ds_list_delete(sl, idx);
		instance_destroy(sel);
		sel = -1;
		
		for (var i = idx; i < (num - 1); i++) {
			ds_list_find_value(sl, i).y -= 40;
		}
	}
} else if (point_in_rectangle(mouse_x, mouse_y, x + 10, y + 10, x + 90, y + 30) && (mouse_x - (x + 10)) % 30 <= 20) {
	var idx = floor((mouse_x - (x + 10)) / 30);
	var ing = recipe[? "ing"];
	for (var i = 0; i < array_length(ing); i++) {
		if (ing[i] == -1) { idx += 1; }
	}
		
	if (idx >= array_length(ing) || ing[idx] == -1) { return; }
		
	var item = obj_game.all_items[ing[idx]];
	obj_setup_item_desc.item = item;
	obj_setup_item_desc.recipe = -1; 
		
	//TODO: set recipe if available
} else {
	var item = obj_game.all_items[recipe[? "result"]];
	obj_setup_item_desc.item = item;
	obj_setup_item_desc.recipe = recipe; 
}
