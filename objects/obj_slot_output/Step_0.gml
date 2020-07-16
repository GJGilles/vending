/// @description Insert description here
// You can write your code in this editor

if (instance_exists(obj_timer) && !obj_timer.running) { return; }
	
if (component != -1) {
	if (result == -1) {
		result = [-1, -1, -1, -1];
		
		var item = ds_queue_dequeue(buffer[2]);
		var vend = obj_vending_sidebar;

		for (var i = 0; i < array_length_1d(vend.items); i++) {
			if (vend.items[i] == item && vend.numbers[i] < vend.stack_size) {
				vend.numbers[i]++;
				return result;
			}
		}
		for (var i = 0; i < array_length_1d(vend.items); i++) {
			if (vend.items[i] == -1) {
				vend.items[i] = item;
				vend.numbers[i] = 1;
				return result;
			}
		}
	} else if (wait < component[? "time"]) {
		wait++;
	} else {
		wait = 0;
		result = -1;
	}
}
