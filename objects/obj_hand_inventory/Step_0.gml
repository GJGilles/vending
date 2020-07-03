/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (mouse_wheel_up()) {
	selected--;
	if (selected < 0) { selected = (max_size - 1); }
} else if (mouse_wheel_down()) {
	selected++;
	if (selected >= max_size) { selected = 0; }
}
