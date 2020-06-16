var x_pos = argument0;
var y_pos = argument1;
var rotation = argument2;


draw_sprite_ext(spr_y_combinator, -1, x_pos, y_pos, 1, 1, 90 * rotation, c_white, 1);
draw_sprite_ext(spr_y_IO, -1, x_pos, y_pos, 1, 1, 90 * rotation, c_white, 1);
draw_sprite_ext(spr_steeper, -1, x_pos, y_pos, 1, 1, 0, c_white, 1);
