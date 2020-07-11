var res = argument0;

if (res && instance_exists(obj_save_screen)) {
	scr_save_game(obj_save_screen.pressed - 1);
	instance_destroy(obj_save_screen);
}
