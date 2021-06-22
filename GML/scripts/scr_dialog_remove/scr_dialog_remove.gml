function scr_dialog_remove(argument0) {



	var result = argument0;

	var cb = ds_stack_pop(obj_dialog_manager.dialogs);
	if (cb != -1) {
		script_execute(cb, result);
	}



}
