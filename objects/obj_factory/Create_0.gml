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


for (var i = 0; i < slot_width; i++) {
	for (var j = 0; j < slot_height; j++) {
		var slot = slots[i, j];
		if (i != 0)                { slot.directions[2] = slots[i - 1, j]; }
		if (i != slot_width - 1)   { slot.directions[0] = slots[i + 1, j]; }
		if (j != 0)                { slot.directions[1] = slots[i, j - 1]; }
		if (j != slot_height - 1)  { slot.directions[3] = slots[i, j + 1]; }
	}
}


/*
// Test
slots[1, 0].component = obj_game.all_components[ComponentEnum.g_tea_leaves_in];

slots[1, 1].component = obj_game.all_components[ComponentEnum.pipe];
slots[1, 1].rotation = 1;

slots[1, 3].component = obj_game.all_components[ComponentEnum.water_in];
slots[1, 3].rotation = 2;

slots[1, 2].component = obj_game.all_components[ComponentEnum.steeper];
slots[1, 2].rotation = 1;

slots[2, 2].component = obj_game.all_components[ComponentEnum.pipe];
slots[2, 2].rotation = 2;



slots[3, 3].component = obj_game.all_components[ComponentEnum.elbow];
slots[3, 3].rotation = 3;

slots[3, 4].component = obj_game.all_components[ComponentEnum.elbow];
slots[3, 4].rotation = 0;

slots[4, 3].component = obj_game.all_components[ComponentEnum.pipe];

slots[4, 4].component = obj_game.all_components[ComponentEnum.pipe];
slots[4, 4].rotation = 2;

slots[5, 3].component = obj_game.all_components[ComponentEnum.elbow];
slots[5, 3].rotation = 2;

slots[5, 4].component = obj_game.all_components[ComponentEnum.elbow];
slots[5, 4].rotation = 1;
*/