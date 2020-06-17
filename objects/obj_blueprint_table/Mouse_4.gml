/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && distance_to_object(obj_player) < 50) { 
	obj_factory.building_mode = true;
	instance_create_layer(0, 0, BUILD_GUI_LAYER, obj_build_GUI);
}
	