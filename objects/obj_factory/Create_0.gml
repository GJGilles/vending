/// @description 
// You can write your code in this editor

slot_width = 10;
slot_height = 9;

slots[0, 0] = 0;
for (var i = 0; i < slot_width; i++) {
	for (var j = 0; j < slot_height; j++) {
		slots[i, j] = instance_create_layer(x + i * TILE_SIZE - 16, y + j * TILE_SIZE - 16, "Factory", obj_slot);
	}
}

instance_destroy(slots[1, 0]);
slots[1, 0] = instance_create_layer(x + 1 * TILE_SIZE - 16, y + 0 * TILE_SIZE - 16, "Factory", obj_slot_input);
slots[1, 0].item = ItemEnum.water;

instance_destroy(slots[2, 0]);
slots[2, 0] = instance_create_layer(x + 2 * TILE_SIZE - 16, y + 0 * TILE_SIZE - 16, "Factory", obj_slot_input);
slots[2, 0].item = ItemEnum.milk;

instance_destroy(slots[3, 0]);
slots[3, 0] = instance_create_layer(x + 3 * TILE_SIZE - 16, y + 0 * TILE_SIZE - 16, "Factory", obj_slot_input);
slots[3, 0].item = ItemEnum.g_tea_leaves;

instance_destroy(slots[6, 3]);
slots[6, 3] = instance_create_layer(x + 6 * TILE_SIZE - 16, y + 3 * TILE_SIZE - 16, "Factory", obj_slot_output);


for (var i = 0; i < slot_width; i++) {
	for (var j = 0; j < slot_height; j++) {
		var slot = slots[i, j];
		if (i != 0)                { slot.directions[2] = slots[i - 1, j]; }
		if (i != slot_width - 1)   { slot.directions[0] = slots[i + 1, j]; }
		if (j != 0)                { slot.directions[1] = slots[i, j - 1]; }
		if (j != slot_height - 1)  { slot.directions[3] = slots[i, j + 1]; }
	}
}
