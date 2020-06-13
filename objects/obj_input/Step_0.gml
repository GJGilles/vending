/// @description Insert description here
// You can write your code in this editor

if (count >= freq) {
	if (ds_queue_size(buffer[dir]) < buff_size) {
		ds_queue_enqueue(buffer[dir], instance_create_layer(x, y, "Instances", item));
		count = 0;
	}
} else {
	count++;
}
