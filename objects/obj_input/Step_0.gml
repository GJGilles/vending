/// @description Insert description here
// You can write your code in this editor

if (count >= freq) {
	if (ds_queue_size(buffer[rotation]) < buff_size) {
		ds_queue_enqueue(buffer[rotation], instance_create_layer(x, y, "Components", item));
		count = 0;
	}
} else {
	count++;
}
