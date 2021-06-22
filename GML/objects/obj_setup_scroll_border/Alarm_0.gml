/// @description Insert description here
// You can write your code in this editor

var x1 = camera_get_view_x(view_get_camera(0));
var x2 = 0;

if (x1 == x2) {
	animo_frame = animo_len;
} else {
	var x_pos = x1 + (x2 - x1) * (animo_frame / animo_len);
	camera_set_view_pos(view_get_camera(0), x_pos, 0);
}

if (animo_frame == animo_len) {
	animo_frame = 0;
} else {
	animo_frame++;
	alarm[0] = 1;
}