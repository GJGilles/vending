/// @description Insert description here
// You can write your code in this editor

event_inherited();

x = x_origin + radius * sin(2 * pi *animo_frame / animo_len);
y = y_origin + radius * cos(2 * pi *animo_frame / animo_len);

animo_frame++;
if (animo_frame == animo_len) {
	animo_frame = 0;
}

