/// @description Insert description here
// You can write your code in this editor

event_inherited();
draw_self();

for (var i = 0; i < array_length_1d(buttons); i++) {
	var vals = buttons[i];
	
	var x_pos = (vals[0] < 0 ? bbox_right : bbox_left) + vals[0];
	var y_pos = (vals[1] < 0 ? bbox_bottom : bbox_top) + vals[1];
	var w = sprite_get_width(vals[2]);
	var h = sprite_get_height(vals[2]);
	
	var frame = (obj_game.mouse == id &&  point_in_rectangle(mouse_x, mouse_y, x_pos, y_pos, x_pos + w, y_pos + h));
	draw_sprite(vals[2], frame, x_pos, y_pos);
}
