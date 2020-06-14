/// @description Insert description here
// You can write your code in this editor

var key_left = keyboard_check(vk_left) || keyboard_check(ord("A"));
var key_right = keyboard_check(vk_right) || keyboard_check(ord("D"));
var key_up = keyboard_check(vk_up) || keyboard_check(ord("W"));
var key_down = keyboard_check(vk_down) || keyboard_check(ord("S"));

var input_interact = keyboard_check_pressed(ord("E"));


var cardinal_dir = round(direction / 90);
var total_frames = sprite_get_number(sprite_index) / 4;

x_spd = 0;
y_spd = 0;

if (x_dist % 32 != 0) { x_spd = spd * (cardinal_dir == 0 ? 1 : -1); }
else if (y_dist % 32 != 0) { y_spd = spd * (cardinal_dir == 3 ? 1 : -1); }
else if (key_left || key_right) { x_spd = spd * (key_right - key_left); }
else if (key_up || key_down) { y_spd = spd * (key_down - key_up); }

var input_dir = point_direction(0, 0, x_spd, y_spd);

x += x_spd;
y += y_spd;
x_dist += x_spd;
y_dist += y_spd;

// scr_player_collision();

if (x_spd == 0 && y_spd == 0) {
	image_index = cardinal_dir;
	frame_idx = cardinal_dir;
	x_dist = 0;
	y_dist = 0;
} else {
	direction = input_dir;
	image_index = floor(frame_idx) * 4 + cardinal_dir;
	frame_idx += sprite_get_speed(sprite_index) / FRAME_RATE;

	if (frame_idx >= total_frames) {
		frame_idx -= total_frames;
	}
}

