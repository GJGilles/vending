/// @description Insert description here
// You can write your code in this editor

event_inherited();

for (var i = 0; i < array_length_1d(components); i++) {
	instance_destroy(components[i]);
}

instance_destroy(x_btn);

obj_factory.selected_component = -1;
