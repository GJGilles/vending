/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id) {
	if (obj_build_mode.selection == component) {
		obj_build_mode.selection = -1;
	} else {
		obj_build_mode.selection = component;
		obj_build_mode.rotation = 0;
	}
}
