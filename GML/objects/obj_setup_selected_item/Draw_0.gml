/// @description Insert description here
// You can write your code in this editor

draw_self();

var r = recipe.recipe;
var ing = r[? "ing"];
	
var idx = 0;
for (var i = 0; i < array_length(ing); i++) {
	if (ing[i] == -1) { continue; }
		
	var item = obj_game.all_items[ing[i]];
	draw_sprite(item[? "sprite"], -1, x + (30 * idx) + 20, y + 20);
	idx++;
}
	
var res = obj_game.all_items[r[? "result"]];
draw_sprite(res[? "sprite"], -1, x + 120, y + 20);
	