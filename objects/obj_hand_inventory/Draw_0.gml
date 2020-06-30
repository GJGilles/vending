/// @description Insert description here
// You can write your code in this editor

event_inherited();

var h = sprite_get_height(spr_inventory_mid); 
var w = sprite_get_width(spr_inventory_mid);
var top = (CAMERA_HEIGHT / 2) - (max_size / 2) * h + h / 2;
for (var i = 0; i < max_size; i++) {
	if (i == 0) {
		draw_sprite(spr_inventory_top, selected == i ? 1 : 0, x - (w / 2), y + top + h * i);
	} else if (i == max_size - 1) {
		draw_sprite(spr_inventory_bot, selected == i ? 1 : 0, x - (w / 2), y + top + h * i);
	} else {
		draw_sprite(spr_inventory_mid, selected == i ? 1 : 0, x - (w / 2), y + top + h * i);
	}
	
	if (items[i] != -1) {
		var item = items[i];
		draw_sprite(item[? "sprite"], -1, x - (w / 2), y + top + h * i);
		
		write_text(string(numbers[i]), x - (w / 3), y + 4 + top + h * i, FontEnum.silkscreen);
	}
}
