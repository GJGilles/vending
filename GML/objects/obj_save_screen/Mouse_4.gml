/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (obj_game.mouse == id && pressed != -1) {
	if (pressed == 0) {
		audio_play_sound(snd_taiko_decline, 1, false);
		instance_destroy();
	} else {
		var save = saves[pressed - 1];
		if (save == -1) {
			audio_play_sound(snd_taiko_accept, 1, false);
			scr_confirm_save(true);
		} else {
			var inst = scr_dialog_create(obj_dialog_confirm, scr_confirm_save);
			inst.text = "Would you like to overwrite this save?";
		}
	}
}
