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
	}
}
