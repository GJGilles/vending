/// @description Insert description here
// You can write your code in this editor

event_inherited();

var h = sprite_get_height(spr_inventory_mid); 
var top = (CAMERA_HEIGHT / 2) - (max_size / 2) * h + h / 2;
for (var i = 0; i < max_size; i++) {
	if (i == 0) {
		draw_sprite_ext(spr_inventory_top, -1, x - 6, y + top + h * i, 1, 1, 0, selected == i ? c_orange : c_white, 1);
	} else if (i == max_size - 1) {
		draw_sprite_ext(spr_inventory_bot, -1, x - 6, y + top + h * i, 1, 1, 0, selected == i ? c_orange : c_white, 1);
	} else {
		draw_sprite_ext(spr_inventory_mid, -1, x - 6, y + top + h * i, 1, 1, 0, selected == i ? c_orange : c_white, 1);
	}
	
	if (items[i] != -1) {
		var item = items[i];
		draw_sprite_ext(item[? "sprite"], -1, x - 6, y + top + h * i, 1, 1, 0, c_white, 1);
		
		draw_set_font(fnt_ken_mini_8);
		draw_set_color(c_black);
		draw_text(x + 3, y + 4 + top + h * i, string(numbers[i]));
	}
}
