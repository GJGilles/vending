/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && distance_to_object(obj_player) < 50) { 
	instance_create_layer(480, 0, BUILD_GUI_LAYER, obj_build_mode);
}
	