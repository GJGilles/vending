/// @description Insert description here
// You can write your code in this editor

var isBuild = obj_game.mouse == id && instance_exists(obj_build_mode);
if (isBuild &&  obj_build_mode.selection >= BuildToolsEnum.build) {
	scr_slot_set_component(id, obj_build_mode.selection, obj_build_mode.rotation);
} else if (isBuild && obj_build_mode.selection == BuildToolsEnum.erase) {
	scr_slot_set_component(id, -1, 0);
}
