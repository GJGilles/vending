/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (obj_game.mouse == id) {
	switch(pressed) {
		case 0: 
		case 2:
			result = false;
			audio_play_sound(snd_taiko_decline, 1, false);
			instance_destroy();
			break;
		case 1:
			result = true;
			audio_play_sound(snd_taiko_accept, 1, false);
			instance_destroy();
			break;
		default:
			break;
	}
}
