/// @description Insert description here
// You can write your code in this editor


script_execute(script, idx);

if (instance_exists(obj_title_load_screen)) {
	instance_destroy(obj_title_load_screen);
}

if (instance_exists(obj_title_save_screen)) {
	instance_destroy(obj_title_save_screen);
}
