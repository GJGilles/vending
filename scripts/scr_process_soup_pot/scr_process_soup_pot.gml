var inputs = array_sort(argument0);
var result = array_create(4, -1);

var item = obj_game.all_items[ItemEnum.junk];

result[3] = item;
return result;
