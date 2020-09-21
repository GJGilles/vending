/// @description Insert description here
// You can write your code in this editor

image_index = recipe != -1;
draw_self();

if (item == -1) return;

write_text(item[? "name"], x + 10, y + 5, FontEnum.silkscreen_2w);

draw_sprite(item[? "sprite"], -1, x + 20, y + 20);

if (recipe == -1) {
	write_text("Raw Ingredient", x + 60, y + 40, FontEnum.silkscreen_2w);
	write_text("-", x + 10, y + 70, FontEnum.silkscreen_2w);
} else {
	var ing = recipe[? "ing"];
	for (var i = 0; i < array_length(ing); i++) {
		if (ing[i] == -1) { continue; }
		
		var it = obj_game.all_items[ing[i]];
		draw_sprite(it[? "sprite"], -1, x + 60, y + 40);
	}

	var traits = [item[? "color"], item[? "temp"], item[? "flavor"], item[? "prep"]];
	var all_traits = [obj_game.all_traits.color, obj_game.all_traits.temp, obj_game.all_traits.flavor, obj_game.all_traits.prep];
	var str = "";
	for (var i = 0; i < array_length(traits); i++) {
		str += all_traits[traits[i]].name;
		if (i != (array_length(traits) - 1)) { str += "-"; }
	}

	write_text(str, x + 10, y + 70, FontEnum.silkscreen_2w);
}


write_wrap_text(item[? "description"], x + 10, y + 90, FontEnum.silkscreen, 140);
