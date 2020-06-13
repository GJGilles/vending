/// @description Insert description here
// You can write your code in this editor


// Random movement 
//TODO: Bound this so that parts won't clip out of the component
for (var i = 0; i < 4; i++) {
	if (inputs[i] == 1 && !ds_queue_empty(buffer[i])) {
		ds_queue_head(buffer[i]).x += random_range(-2, 2);
		ds_queue_head(buffer[i]).y += random_range(-2, 2);
	}
}
