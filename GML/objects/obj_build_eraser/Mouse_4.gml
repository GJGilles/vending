/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id) {
	if (obj_build_mode.selection == BuildToolsEnum.erase) {
		obj_build_mode.selection = BuildToolsEnum.none;
	} else {
		obj_build_mode.selection = BuildToolsEnum.erase;
	}
}
