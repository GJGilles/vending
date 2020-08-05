/// @description Insert description here
// You can write your code in this editor

draw_self();

if (recipe != -1) {
	var ing = recipe[? "ing"];
	
	var idx = 0;
	for (var i = 0; i < array_length_1d(ing); i++) {
		if (ing[i] == -1) { continue; }
		
		var item = obj_game.all_items[ing[i]];
		draw_sprite(item[? "sprite"], -1, x + (30 * idx) + 10, y + 10);
		idx++;
	}
	
	var res = obj_game.all_items[recipe[? "result"]];
	draw_sprite(res[? "sprite"], -1, x + 110, y + 10)
}
