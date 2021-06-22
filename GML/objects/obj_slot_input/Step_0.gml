/// @description Insert description here
// You can write your code in this editor

if (instance_exists(obj_timer) && !obj_timer.running) { return; }

if (component != -1) {
	if (result == -1) {
		result = [-1, -1, -1, item];		
	} else if (wait < component[? "time"]) {
		wait++;
	} else {
		ds_queue_enqueue(buffer[3], result[3]);
		wait = 0;
		result = -1;
	}
}
