/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (obj_game.mouse == id) {
	switch(pressed) {
		case 0: 
		case 2:
			result = false;
			instance_destroy();
			break;
		case 1:
			result = true;
			instance_destroy();
			break;
		default:
			break;
	}
}
