/// @description Insert description here
// You can write your code in this editor

if (component != -1) {
	var opposite = [2, 3, 0, 1];
	
	var io = component[? "io"];
	var size = component[? "size"];
	
	for (var i = 0; i < 4; i++) {
		var idx = i + rotation;
		if (idx > 3) { idx -= 4; }
		var prev_slot = directions[idx];
		
		if (io[i] == IOEnum.input && prev_slot.component != -1) {
			var prev_idx = opposite[idx] - prev_slot.rotation;
			if (prev_idx < 0) { prev_idx += 4; }
			
			var buff = prev_slot.buffer[prev_idx];
			while (ds_queue_size(buff) > 0 && ds_queue_size(buffer[i]) < size) {
				var item = ds_queue_dequeue(buff);
				ds_queue_enqueue(buffer[i], item);
			}
		}
	}
}