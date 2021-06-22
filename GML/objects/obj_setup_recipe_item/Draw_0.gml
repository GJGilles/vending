/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (recipe != -1) {
	var ing = recipe[? "ing"];
	
	var itop = min(max(0, top - 10), 32);
	var ibot = min(max(0, bot - 10), 32);
	
	var idx = 0;
	for (var i = 0; i < array_length(ing); i++) {
		if (ing[i] == -1) { continue; }
		
		var item = obj_game.all_items[ing[i]];
		draw_sprite_part(item[? "sprite"], -1, 0, itop, sprite_get_width(item[? "sprite"]), sprite_get_height(item[? "sprite"]) - itop - ibot, x + (30 * idx) + 10, y + 10 - top + itop);
		idx++;
	}
	
	var res = obj_game.all_items[recipe[? "result"]];
	draw_sprite_part(res[? "sprite"], -1, 0, itop, sprite_get_width(res[? "sprite"]), sprite_get_height(res[? "sprite"]) - itop - ibot, x + 110, y + 10 - top + itop);
}
