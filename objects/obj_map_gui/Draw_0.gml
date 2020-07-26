/// @description Insert description here
// You can write your code in this editor

event_inherited();

var loc = locations[selected];
var coords = loc[? "coords"];
draw_sprite(spr_map_marker, -1, coords[0], coords[1]);


draw_sprite(spr_map_menu, 0, x, y);

var h = sprite_get_height(spr_map_menu);
var y_off = h;
for (var i = 0; i < array_length_1d(locations); i++) {
	var loc = locations[i];
	
	if (selected == i) {
		draw_sprite_ext(spr_map_menu, 1, x, y + y_off, 1, 1, 0, c_red, 1);
	} else if (hovered == i) {
		draw_sprite_ext(spr_map_menu, 1, x, y + y_off, 1, 1, 0, c_orange, 1);
	} else {
		draw_sprite(spr_map_menu, 1, x, y + y_off);
	}
	write_text(loc[? "name"], x + 3, y + 1 + y_off, FontEnum.silkscreen);
	y_off += h;
}

draw_sprite(spr_map_menu, 2, x, y + y_off);
