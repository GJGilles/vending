/// @description Insert description here
// You can write your code in this editor

if (!instance_exists(obj_factory_stats)) { return; }

var x_pos = x_origin;
var y_pos = y_origin;

var w = sprite_get_width(spr_results_background);
var h = sprite_get_height(spr_results_background);
var margin = h;


draw_sprite(spr_results_background, 0, x_pos, y_pos);
y_pos += h;

for (var i = 0; i < array_length_1d(obj_factory_stats.ordered_items); i++) {
	var item = obj_game.all_items[obj_factory_stats.ordered_items[i]];
	var spd = obj_factory_stats.ordered_speeds[i];
	
	draw_sprite(spr_results_background, 1, x_pos, y_pos);
	//draw_sprite(spr_item_in, -1, x_pos + margin, y_pos);
	draw_sprite(item[? "sprite"], -1, x_pos + margin, y_pos + 16);
	write_text(item[? "name"], x_pos + margin + 32, y_pos, FontEnum.silkscreen);
	write_text(spd, x_pos + w - 128, y_pos, FontEnum.silkscreen);
	write_text("xxxxx", x_pos + w - 32, y_pos, FontEnum.silkscreen);
	y_pos += h;
}

draw_sprite(spr_results_background, 1, x_pos, y_pos);
y_pos += h;

for (var i = 0; i < array_length_1d(obj_factory_stats.created_items); i++) {
	var item = obj_factory_stats.created_items[i];
	var numb = obj_factory_stats.created_numbers[i];
	
	draw_sprite(spr_results_background, 1, x_pos, y_pos);
	draw_sprite(item[? "sprite"], -1, x_pos + margin, y_pos + 16);
	write_text(item[? "name"], x_pos + margin + 32, y_pos, FontEnum.silkscreen);
	write_text(numb, x_pos + w - 128, y_pos, FontEnum.silkscreen);
	write_text("-", x_pos + w - 32, y_pos, FontEnum.silkscreen);
	y_pos += h;
}

draw_sprite(spr_results_background, 1, x_pos, y_pos);
y_pos += h;

for (var i = 0; i < array_length_1d(obj_factory_stats.sold_items); i++) {
	var item = obj_factory_stats.sold_items[i];
	var numb = obj_factory_stats.sold_numbers[i];
	
	draw_sprite(spr_results_background, 1, x_pos, y_pos);
	draw_sprite(item[? "sprite"], -1, x_pos + margin, y_pos + 16);
	write_text(item[? "name"], x_pos + margin + 32, y_pos, FontEnum.silkscreen);
	write_text(numb, x_pos + w - 128, y_pos, FontEnum.silkscreen);
	write_text(item[? "cost"] * numb, x_pos + w - 32, y_pos, FontEnum.silkscreen);
	y_pos += h;
}

draw_sprite(spr_results_background, 2, x_pos, y_pos);
y_pos += h;
