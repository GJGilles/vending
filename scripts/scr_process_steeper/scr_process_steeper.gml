var inputs = array_sort(argument0);
var result = array_create(4, -1);

var g_tea_leaves = obj_game.all_items[ItemEnum.g_tea_leaves];
var b_tea_leaves = obj_game.all_items[ItemEnum.b_tea_leaves];
var water = obj_game.all_items[ItemEnum.water];
var milk = obj_game.all_items[ItemEnum.milk];

var g_tea = obj_game.all_items[ItemEnum.g_tea];
var b_tea = obj_game.all_items[ItemEnum.b_tea];
var milk_tea = obj_game.all_items[ItemEnum.royal_milk_tea];
var junk = obj_game.all_items[ItemEnum.junk];

if (array_equals(inputs, array_sort([g_tea_leaves, water, -1, -1]))) {
	result[3] = g_tea;
} else if (array_equals(inputs, array_sort([b_tea_leaves, water, -1, -1]))) {
	result[3] = b_tea;
} else if (array_equals(inputs, array_sort([b_tea_leaves, milk, -1, -1]))) {
	result[3] = milk_tea;
}else {
	result[3] = junk;
}

return result;
