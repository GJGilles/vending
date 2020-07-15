var x_pos = argument0;
var y_pos = argument1;
var rotation = argument2;
var alpha = argument3;

if (instance_exists(obj_build_mode)) {
	draw_sprite_ext(spr_IO_in, -1, x_pos, y_pos, 1, 1, 90 * rotation, c_white, alpha);
	draw_sprite_ext(spr_IO_out, -1, x_pos, y_pos, 1, 1, 90 * (rotation + 3), c_white, alpha);
}
draw_sprite_ext(spr_mochi_maker, -1, x_pos, y_pos, 1, 1, 0, c_white, alpha);