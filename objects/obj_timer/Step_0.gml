/// @description Insert description here
// You can write your code in this editor

if (!running) { 
	event_inherited();
	return; 
}

tick++;
if (tick == rate) {
	time++;
	tick = 0;
	
	if (time >= day) { 
		running = false;
		if (instance_exists(obj_room_transition)) {
			obj_room_transition.alarm[1] = 1;
			alarm[0] = obj_room_transition.animo_len;
		}
	}
}
