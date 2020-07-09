


var obj = argument0;
var cb = argument1;

var inst = instance_create_layer(0, 0, "Dialogs", obj);
inst.depth -= 2 * ds_stack_size(obj_dialog_manager.dialogs);
ds_stack_push(obj_dialog_manager.dialogs, cb);

