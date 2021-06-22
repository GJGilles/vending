function scr_dialog_create(argument0, argument1) {



	var obj = argument0;
	var cb = argument1;

	var z = layer_get_depth(layer_get_id("Dialogs")) - 2 * ds_stack_size(obj_dialog_manager.dialogs);
	var inst = instance_create_depth(0, 0, z, obj);

	inst.x_origin = (camera_get_view_width(view_camera[0]) - inst.sprite_width) / 2;
	inst.y_origin = (camera_get_view_height(view_camera[0]) - inst.sprite_height) / 2;


	ds_stack_push(obj_dialog_manager.dialogs, cb);
	return inst;



}
