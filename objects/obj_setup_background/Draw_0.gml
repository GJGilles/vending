/// @description Insert description here
// You can write your code in this editor

draw_self();

if (point_in_rectangle(mouse_x, mouse_y, 367, 7, 475, 155)) {
	draw_sprite(spr_setup_background_h, -1, 0, 0)
}

draw_set_font(global.fonts[FontEnum.silkscreen_2w]);
draw_text_transformed(367, 7, "Test Test Blah Blah", 1, 1, -13);
