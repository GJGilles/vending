/// @description Insert description here
// You can write your code in this editor

var x1 = camera_get_view_x(view_get_camera(0));
var y1 = camera_get_view_y(view_get_camera(0));

var loc = locations[selected];
var coords = loc[? "coords"];

var x2 = min(max(0, coords[0] - CAMERA_WIDTH / 2), room_width - CAMERA_WIDTH);
var y2 = min(max(0, coords[1] - CAMERA_HEIGHT / 2), room_height - CAMERA_HEIGHT);

var x_pos = x1 + (x2 - x1) * (animo_frame / animo_len);
var y_pos = y1 + (y2 - y1) * (animo_frame / animo_len);
camera_set_view_pos(view_get_camera(0), x_pos, y_pos);

if (animo_frame == animo_len) {
	animo_frame = 0;
} else {
	animo_frame++;
	alarm[0] = 1;
}
