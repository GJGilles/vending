/// @description Insert description here
// You can write your code in this editor

event_inherited();

enum BuildToolsEnum {
	erase = -2,
	none = -1,
	build = 0
}

selection = BuildToolsEnum.none;
rotation = 0;

components = array_create(0);
x_btn = -1;
eraser = -1;

animo_frame = 0;
animo_len = 25;

alarm[0] = 1;
