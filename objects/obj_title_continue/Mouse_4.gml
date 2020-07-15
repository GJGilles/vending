/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id) {
	if (scr_save_exists(0)) {
		scr_load_game(0);
		audio_play_sound(snd_taiko_accept, 1, false);
		room_goto(rm_setup);
	}
}
