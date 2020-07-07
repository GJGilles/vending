var inputs = array_sort(argument0);
var result = array_create(4, -1);

var g_tea_leaves = obj_game.all_items[ItemEnum.g_tea_leaves];

var b_tea_leaves = obj_game.all_items[ItemEnum.b_tea_leaves];
var junk = obj_game.all_items[ItemEnum.junk];

var item = junk;
if (array_equals(inputs, array_sort([g_tea_leaves, -1, -1, -1]))) {
	item = b_tea_leaves;
} else {
	item = junk;
}

result[3] = item;
return result;
