/// @description Insert description here
// You can write your code in this editor

event_inherited();

if (instance_exists(obj_timer) && !obj_timer.running) { return; }
	
if (component != -1) {
	var io = component[? "io"];
	var size = component[? "size"];
	
	if (result == -1) {
		var is_input = true;
		for (var i = 0; i < 4; i++) {
			if (io[i] == IOEnum.input && ds_queue_empty(buffer[i])) { is_input = false; }
		}
		
		if (is_input) {
			var input = array_create(4, -1);
			for (var i = 0; i < 4; i++) {
				if (io[i] == IOEnum.input) {
					input[i] = ds_queue_dequeue(buffer[i]);
				}
			}
			
			result = script_execute(component[? "process"], input);
		}
		
		
	} else if (wait < component[? "time"]) {
		wait++;
	} else {
		var is_output = true;
		for (var i = 0; i < 4; i++) {
			if (io[i] == IOEnum.output && ds_queue_size(buffer[i]) >= size[i]) { is_output = false; }
		}
		
		if (is_output) {
			for (var i = 0; i < 4; i++) {
				if (io[i] == IOEnum.output) {
					ds_queue_enqueue(buffer[i], result[i]);
				}
			}
			
			wait = 0;
			result = -1;
		}
	}
}

