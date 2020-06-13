/// @description Insert description here
// You can write your code in this editor

freq = 10;
count = 0;

item = -1;

dir = 0;

buff_size = 1;
buffer = array_create(4, -1);
for (var i = 0; i < 4; i++) {
	buffer[i] = ds_queue_create();
}
