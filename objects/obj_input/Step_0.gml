/// @description Insert description here
// You can write your code in this editor

if (count >= freq) {
	if (ds_queue_size(buffer[3]) < buff_size[3]) {
		ds_queue_enqueue(buffer[3], instance_create_layer(x, y, "Components", item));
		count = 0;
	}
} else {
	count++;
}
