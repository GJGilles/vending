/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && instance_exists(obj_build_mode) && obj_build_mode.selection != -1) {
	component = obj_build_mode.selection;
	rotation = obj_build_mode.rotation;
}
