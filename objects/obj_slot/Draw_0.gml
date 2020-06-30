/// @description Insert description here
// You can write your code in this editor

draw_self();

var isBuild = obj_game.mouse == id && instance_exists(obj_build_mode);
if (component != -1 && isBuild && obj_build_mode.selection == BuildToolsEnum.erase) {
	script_execute(component[? "draw"], x, y, rotation, 0.5);
	draw_sprite(spr_eraser, -1, x, y);
} else if (component != -1) {
	script_execute(component[? "draw"], x, y, rotation, 1);
} else if (isBuild && obj_build_mode.selection >= BuildToolsEnum.build) {
	script_execute(obj_build_mode.selection[? "draw"], x, y, obj_build_mode.rotation, 0.5);
}
