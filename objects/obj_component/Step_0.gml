/// @description Insert description here
// You can write your code in this editor


// Random movement 
//TODO: Bound this so that parts won't clip out of the component
for (var i = 0; i < 4; i++) {
	if (inputs[i] == 1 && !ds_queue_empty(buffer[i])) {
		var head = ds_queue_head(buffer[i]);
		// head.x += random_range(-2, 2);
		// head.y += random_range(-2, 2);
	}
}
