/// @description Insert description here
// You can write your code in this editor

directions = array_create(4, -1);

rotation = 0;
component = -1;

io = array_create(4, -1);
buffer = array_create(4, -1);
for (var i = 0; i < 4; i++) {
	buffer[i] = ds_queue_create();
}

wait = 0;
result = -1;
