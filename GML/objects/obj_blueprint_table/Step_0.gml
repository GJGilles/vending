/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (obj_game.mouse == id && distance_to_object(obj_player) < 50) { 
	image_index = 1;
} else {
	image_index = 0;
}
