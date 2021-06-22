/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id) {
	with obj_game {
		// scr_new_game();
		audio_play_sound(snd_taiko_accept, 1, false);
		room_goto(rm_setup);
	}
}
