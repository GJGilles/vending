/// @description Insert description here
// You can write your code in this editor

event_inherited();

components = array_create(0);

var num_cols = 3;
var spacing = 40;
for (var i = 0; i < array_length_1d(obj_game.current_components); i++) {
	var x_pos = spacing * (1 + (i % num_cols));
	var y_pos = spacing * (1 + floor(i / num_cols));
	components[i] = instance_create_layer(x_pos, y_pos, BUILD_GUI_LAYER, obj_build_component);
	components[i].component = obj_game.current_components[i];
	components[i].depth -= 1;
}

x_btn = instance_create_layer(sprite_width - sprite_get_width(spr_exit_btn) - 5, 5, BUILD_GUI_LAYER, obj_build_exit);
