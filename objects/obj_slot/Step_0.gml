/// @description Insert description here
// You can write your code in this editor


if (component) {
	var directions = [right, up, left, down];
	var opposite = [2, 3, 0, 1];
	for (var i = 0; i < 4; i++) {
		var idx = i + component.rotation;
		if (idx > 3) { idx -= 4; }
		var prev_slot = directions[idx];
		
		if (component.inputs[i] && prev_slot.component) {
			var prev_idx = opposite[idx] + prev_slot.component.rotation;
			if (prev_idx > 3) { prev_idx -= 4; }
			
			var buff = prev_slot.component.buffer[prev_idx];
			while (ds_queue_size(buff) > 0 && !ds_queue_head(buff).moved && ds_queue_size(component.buffer[i]) < component.buff_size[i]) {
				var item = ds_queue_dequeue(buff);
				item.x = component.x;
				item.y = component.y;
				item.moved = true;
				ds_queue_enqueue(component.buffer[i], item);
			}
		}
	}
	
	if (component.process) {
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
			
				wait = 0;
			}
		}
	}
}

