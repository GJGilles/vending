/// @description Insert description here
// You can write your code in this editor

draw_self();

var isBuild = obj_game.mouse == id && instance_exists(obj_build_mode);
if (component != -1) {
	if (isBuild && obj_build_mode.selection == BuildToolsEnum.erase) {
		draw_sprite(component[? "sprite"], -1, x, y);
		draw_sprite(spr_eraser, -1, x, y);
	} else {
		draw_sprite(component[? "sprite"], -1, x, y);
	}

	if (instance_exists(obj_build_mode)) {
		var io = component[? "io"];
		for (var i = 0; i < 4; i++) {
			if (io[i] == IOEnum.input) {
				draw_sprite_ext(spr_IO_in, -1, x, y, 1, 1, rotation * 90, c_white, 1);
			} else if (io[i] == IOEnum.output) {
				draw_sprite_ext(spr_IO_out, -1, x, y, 1, 1, rotation * 90, c_white, 1);
			}
		}
	}
} else if (isBuild && obj_build_mode.selection >= BuildToolsEnum.build) {
	draw_sprite_ext(obj_build_mode.selection[? "sprite"], -1, x, y, 1, 1, obj_build_mode.rotation * 90, c_white, 0.5);
	var io = obj_build_mode.selection[? "io"];
	for (var i = 0; i < 4; i++) {
		if (io[i] == IOEnum.input) {
			draw_sprite_ext(spr_IO_in, -1, x, y, 1, 1, obj_build_mode.rotation * 90, c_white, 1);
		} else if (io[i] == IOEnum.output) {
			draw_sprite_ext(spr_IO_out, -1, x, y, 1, 1, obj_build_mode.rotation * 90, c_white, 1);
		}
	}
}
