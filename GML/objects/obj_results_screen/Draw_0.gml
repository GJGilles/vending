/// @description Insert description here
// You can write your code in this editor

if (!instance_exists(obj_factory_setup)) { return; }

var x_pos = x_origin;
var y_pos = y_origin;

var w = sprite_get_width(spr_results_background);
var h = sprite_get_height(spr_results_background);
var margin = h;


draw_sprite(spr_results_background, 0, x_pos, y_pos);
y_pos += h;

for (var i = 0; i < array_length_1d(obj_game.all_items); i++) {
	var item = obj_game.all_items[i];
	var numb = obj_game.item_stats[# i, 0];
	
	if (numb < 1) { continue; }
	
	draw_sprite(spr_results_background, 1, x_pos, y_pos);
	scr_item_draw(item, x_pos + margin, y_pos + 16);
	write_text(scr_item_name(item), x_pos + margin + 32, y_pos, FontEnum.silkscreen);
	write_text(numb, x_pos + w - 128, y_pos, FontEnum.silkscreen);
	write_text(scr_item_cost(item) * numb, x_pos + w - 32, y_pos, FontEnum.silkscreen);
	y_pos += h;
}

draw_sprite(spr_results_background, 2, x_pos, y_pos);
y_pos += h;
