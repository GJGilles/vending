/// @description Insert description here
// You can write your code in this editor

if (obj_factory.selected_component != -1) {
	obj_factory.selected_rotation += 1;
	if (obj_factory.selected_rotation > 3) {
		obj_factory.selected_rotation -= 4;
	}
}
