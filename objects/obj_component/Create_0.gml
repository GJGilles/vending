/// @description Insert description here
// You can write your code in this editor

inputs = array_create(4, 0);
outputs = array_create(4, 0);

buff_size = array_create(4, 1);
buffer = array_create(4, -1);
for (var i = 0; i < 4; i++) {
	buffer[i] = ds_queue_create();
}

rotation = 0;

max_wait = 1;
wait = 0;


process = -1;
result = -1;
