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

instance_destroy(slots[0, 7]);
slots[0, 7] = instance_create_layer(x + 0 * TILE_SIZE - 16, y + 7 * TILE_SIZE - 16, "Factory", obj_slot_input);
slots[0, 7].item = ItemEnum.g_tea_leaves;
slots[0, 7].rotation = 1;

instance_destroy(slots[7, 0]);
slots[7, 0] = instance_create_layer(x + 7 * TILE_SIZE - 16, y + 0 * TILE_SIZE - 16, "Factory", obj_slot_input);
slots[7, 0].item = ItemEnum.water;

for (var i = 0; i < slot_width; i++) {
	for (var j = 0; j < slot_height; j++) {
		var slot = slots[i, j];
		if (i != 0)                { slot.directions[2] = slots[i - 1, j]; }
		if (i != slot_width - 1)   { slot.directions[0] = slots[i + 1, j]; }
		if (j != 0)                { slot.directions[1] = slots[i, j - 1]; }
		if (j != slot_height - 1)  { slot.directions[3] = slots[i, j + 1]; }
	}
}
