/// @description Insert description here
// You can write your code in this editor

var x_pos = (480 - sprite_get_width(spr_build_sidebar));
draw_sprite_ext(spr_build_sidebar, -1, x_pos * SCALE, 0, SCALE, SCALE, 0, c_white, 1);
draw_sprite_ext(spr_exit_btn, -1, (x_pos + 100) * SCALE, 10  * SCALE, SCALE, SCALE, 0, c_white, 1);
