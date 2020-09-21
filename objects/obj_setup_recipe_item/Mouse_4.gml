/// @description Insert description here
// You can write your code in this editor


if (point_in_rectangle(mouse_x, mouse_y, x + 135, y + 10, x + 145, y + 20)) {
	// Add / Remove
} else if (point_in_rectangle(mouse_x, mouse_y, x + 10, y + 10, x + 90, y + 30)) {
	if ((mouse_x - (x + 10)) % 30 <= 20) {
		var idx = floor((mouse_x - (x + 10)) / 30);
		var ing = recipe[? "ing"];
		for (var i = 0; i < array_length(ing); i++) {
			if (ing[i] == -1) { idx += 1; }
		}
		
		if (ing[idx] == -1) { return; }
		
		var item = obj_game.all_items[ing[idx]];
		obj_setup_item_desc.item = item;
		
		//TODO: set recipe if available
	} 
}
