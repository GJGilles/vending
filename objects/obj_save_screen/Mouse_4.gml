/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (obj_game.mouse == id && pressed != -1) {
	if (pressed == 0) {
		instance_destroy();
	} else {
		var save = saves[pressed - 1];
		if (save == -1) {
			scr_confirm_save(true);
		} else {
			var inst = scr_dialog_create(obj_dialog_confirm, scr_confirm_save);
			//inst.text = "";
		}
	}
}
