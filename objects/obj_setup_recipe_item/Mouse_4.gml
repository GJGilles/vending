/// @description Insert description here
// You can write your code in this editor


if (point_in_rectangle(mouse_x, mouse_y, x + 10, y + 10, x + 90, y + 30) && (mouse_x - (x + 10)) % 30 <= 20) {
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
