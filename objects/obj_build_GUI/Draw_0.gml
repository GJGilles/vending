/// @description Insert description here
// You can write your code in this editor

var camera = view_get_camera(0);
x = camera_get_view_x(camera);
y = camera_get_view_y(camera);


draw_sprite_ext(spr_build_sidebar, -1, x, y, 1, 1, 0, c_white, 1);
draw_sprite_ext(spr_exit_btn, -1, x + (sprite_get_width(spr_build_sidebar) - sprite_get_width(spr_exit_btn) - 5), y + 5, 1, 1, 0, c_white, 1);
