/// @description Insert description here
// You can write your code in this editor


if (component) {
	var directions = [left, up, right, down];
	var opposite = [2, 3, 0, 1];
	for (var i = 0; i < 4; i++) {
		if (component.inputs[i] && directions[i].component) {
			var buff = directions[i].component.buffer[opposite[i]];
			while (ds_queue_size(buff) > 0 && ds_queue_size(buffer[i]) < buff_size[i]) {
				ds_queue_enqueue(buffer[i], ds_queue_dequeue(buff));
			}
		}
	}
	
	if (result == -1) {
		var is_input = true;
		for (var i = 0; i < 4; i++) {
			if (component.inputs[i] == 1 && ds_queue_empty(component.buffer[i])) { is_input = false; }
		}
		
		if (is_input) {
			var input = array_create(4, -1);
			for (var i = 0; i < 4; i++) {
				if (component.inputs[i] == 1) {
					input[i] = ds_queue_dequeue(component.buffer[i]);
				}
			}
			
			result = script_execute(component.process, input);
		}
		
		
	} else if (wait < max_wait) {
		wait++;
	} else {
		var is_output = true;
		for (var i = 0; i < 4; i++) {
			if (component.outputs[i] == 1 && ds_queue_size(component.buffer[i]) >= component.buff_size[i]) { is_input = false; }
		}
		
		if (is_output) {
			for (var i = 0; i < 4; i++) {
				if (component.outputs[i] == 1) {
					ds_queue_enqueue(component.buffer[i], result[i]);
				}
			}
		}
	}
}

