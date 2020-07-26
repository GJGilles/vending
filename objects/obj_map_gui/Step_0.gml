/// @description Insert description here
// You can write your code in this editor

event_inherited();

var w = sprite_get_width(spr_map_menu);
var h = sprite_get_height(spr_map_menu);

if (point_in_rectangle(mouse_x, mouse_y, x, y + h, x + w, y + (h * (array_length_1d(locations) + 1)))) {
	var i = floor((mouse_y - y - h) / h);
	
	if (mouse_check_button_pressed(mb_left)) {
		selected = i;
		animo_frame = 0;
		alarm[0] = 1;
		
		var loc = locations[i];
		obj_game.current_location = loc[? "id"];
	} else {
		hovered = i;
	}
}
