/// @description Insert description here
// You can write your code in this editor

draw_sprite(component[? "sprite"], -1, x, y);

if (instance_exists(obj_build_mode)) {
	draw_sprite_ext(spr_IO_out, -1, x, y, 1, 1, (rotation + 3) * 90, c_white, 1);
}
