/// @description Insert description here
// You can write your code in this editor

image_index = recipe != -1;
draw_self();

if (item == -1) return;

write_text(item[? "name"], x + 12, y + 4, FontEnum.silkscreen);

draw_sprite(item[? "sprite"], -1, x + 30, y + 30);

var traits = [item[? "color"], item[? "temp"], item[? "flavor"], item[? "prep"]];
var all_traits = [obj_game.all_traits.color, obj_game.all_traits.temp, obj_game.all_traits.flavor, obj_game.all_traits.prep];
var str = "";
for (var i = 0; i < array_length(traits); i++) {
	if (traits[i] == -1) { continue; }
	
	str += all_traits[i][traits[i]].name;
	if (i != (array_length(traits) - 1)) { str += "-"; }
}

if (recipe == -1) {
	write_text("Raw Ingredient", x + 62, y + 34, FontEnum.silkscreen);
	write_text(string_length(str) ? str : "No Traits", x + 12, y + 64, FontEnum.silkscreen);
	write_wrap_text(item[? "description"], x + 12, y + 92, FontEnum.silkscreen, 136);
} else {
	var ing = recipe[? "ing"];
	var idx = 0;
	for (var i = 0; i < array_length(ing); i++) {
		if (ing[i] == -1) { continue; }
		
		var it = obj_game.all_items[ing[i]];
		draw_sprite(it[? "sprite"], -1, x + 70 + (30 * idx), y + 30);
		idx++;
	}
	
	var comp = obj_game.all_components[recipe[? "comp"]];
	draw_sprite(comp[? "sprite"], -1, x + 50, y + 66);
	write_text(comp[? "name"], x + 72, y + 64, FontEnum.silkscreen);
	
	
	write_text(string_length(str) ? str : "No Traits", x + 12, y + 94, FontEnum.silkscreen);
	write_wrap_text(item[? "description"], x + 12, y + 112, FontEnum.silkscreen, 136);
}
