var inputs = argument0;
var result = array_create(4, -1);

var g_tea_leaves = obj_game.all_items[ItemEnum.g_tea_leaves];
var water = obj_game.all_items[ItemEnum.water];

if (array_equals(array_sort(inputs), array_sort([g_tea_leaves, water, -1, -1]))) {
	result[3] = obj_game.all_items[ItemEnum.g_tea];
} else {
	result[3] = obj_game.all_items[ItemEnum.junk];
}

//result[3].quality = median(inputs[0].quality, inputs[2].quality);

return result;
