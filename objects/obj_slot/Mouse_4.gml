/// @description Insert description here
// You can write your code in this editor

var isBuild = obj_game.mouse == id && instance_exists(obj_build_mode);
if (isBuild &&  obj_build_mode.selection >= BuildToolsEnum.build) {
	component = obj_build_mode.selection;
	rotation = obj_build_mode.rotation;
} else if (isBuild && obj_build_mode.selection == BuildToolsEnum.erase) {
	component = -1;
	rotation = 0;
}
