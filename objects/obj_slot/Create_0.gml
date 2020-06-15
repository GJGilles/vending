/// @description Insert description here
// You can write your code in this editor

left = -1;
right = -1;
up = -1;
down = -1;

component = -1;

buffer = array_create(4, -1);
for (var i = 0; i < 4; i++) {
	buffer[i] = ds_queue_create();
}

wait = 0;
result = -1;
