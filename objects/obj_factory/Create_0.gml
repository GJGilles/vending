/// @description 
// You can write your code in this editor

slot_width = 10;
slot_height = 10;

inputs = array_create(2 * (slot_width + slot_height), -1);
outputs = array_create(2 * (slot_width + slot_height), -1);

var width = sprite_get_width(spr_slot);
var height = sprite_get_height(spr_slot);

slots[0, 0] = 0;
for (var i = 0; i < slot_width; i++) {
	for (var j = 0; j < slot_height; j++) {
		slots[i, j] = instance_create_layer(16 + i * width, 16 + j * height, "Factory", obj_slot);
	}
}


for (var i = 0; i < slot_width; i++) {
	for (var j = 0; j < slot_height; j++) {
		if (i != 0)                { slots[i, j].left = slots[i - 1, j]; }
		if (i != slot_width - 1)   { slots[i, j].right = slots[i + 1, j]; }
		if (j != 0)                { slots[i, j].up = slots[i, j - 1]; }
		if (j != slot_height - 1)  { slots[i, j].down = slots[i, j + 1]; }
	}
}


// Test
slots[0, 0].component = instance_create_layer(slots[0, 0].x, slots[0, 0].y, "Components", obj_g_tea_leaves_in);
slots[0, 1].component = instance_create_layer(slots[0, 1].x, slots[0, 1].y, "Components", obj_pipe);
slots[0, 1].component.rotation = 1;