/// @description Insert description here
// You can write your code in this editor

// linear movement
var width = 0; // sprite width

for (var i = 0; i < 4; i++) {
	if (inputs[i] == 1 && !ds_queue_empty(buffer[i])) {
		ds_queue_head(buffer[i]).x += width / max_wait;
		ds_queue_head(buffer[i]).y += random_range(-2, 2);
	}
}