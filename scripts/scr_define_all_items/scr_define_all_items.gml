
enum ItemColorEnum {
	white = 0,
	green = 1,
	black = 2,
	yellow = 3,
	red = 4,
	none = -1
}

enum ItemTempEnum {
	hot = 0, // < 0
	warm = 1, // 0 - 20
	room_temp = 2, // 20 - 22
	cool = 3, // 22 - 26
	cold = 4 // > 26
}

enum ItemFlavorEnum {
	salty = 0,
	sweet = 1,
	sour = 2,
	bitter = 3,
	umami = 4,
	none = -1
}

enum ItemPrepEnum {
	raw = 0,
	simmered = 1,
	fried = 2,
	steamed = 3,
	roasted = 4,
}

enum ItemEnum {
	junk = 0,
	water = 1,
	g_tea_leaves = 2,
	g_tea = 3,
	b_tea = 4,
	b_tea_leaves = 5,
	milk = 6,
	royal_milk_tea = 7
}


var item_array = array_create(0);
item_array[ItemEnum.junk] = scr_define_item("Junk", ItemEnum.junk, 0, spr_junk, [ItemColorEnum.black, ItemTempEnum.room_temp, ItemFlavorEnum.none, ItemPrepEnum.raw], "");
item_array[ItemEnum.water] = scr_define_item("Water", ItemEnum.water, 0, spr_water, [ItemColorEnum.white, ItemTempEnum.room_temp, ItemFlavorEnum.none, ItemPrepEnum.raw], "");
item_array[ItemEnum.g_tea_leaves] = scr_define_item("Green Tea Leaves", ItemEnum.g_tea_leaves, 0, spr_g_tea_leaves, [ItemColorEnum.green, ItemTempEnum.room_temp, ItemFlavorEnum.none, ItemPrepEnum.raw], "");
item_array[ItemEnum.g_tea] = scr_define_item("Green Tea", ItemEnum.g_tea, 100, spr_g_tea, [ItemColorEnum.green, ItemTempEnum.warm, ItemFlavorEnum.bitter, ItemPrepEnum.raw], "");
item_array[ItemEnum.b_tea] = scr_define_item("Black Tea", ItemEnum.b_tea, 100, spr_b_tea, [ItemColorEnum.black, ItemTempEnum.warm, ItemFlavorEnum.bitter, ItemPrepEnum.raw], "");
item_array[ItemEnum.b_tea_leaves] = scr_define_item("Black Tea Leaves", ItemEnum.b_tea_leaves, 0, spr_b_tea_leaves, [ItemColorEnum.black, ItemTempEnum.room_temp, ItemFlavorEnum.none, ItemPrepEnum.raw], "");
item_array[ItemEnum.milk] = scr_define_item("Milk", ItemEnum.milk, 0, spr_milk, [ItemColorEnum.white, ItemTempEnum.cool, ItemFlavorEnum.none, ItemPrepEnum.raw], "");
item_array[ItemEnum.royal_milk_tea] = scr_define_item("Royal Milk Tea", ItemEnum.royal_milk_tea, 200, spr_royal_milk_tea, [ItemColorEnum.black, ItemTempEnum.warm, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");

return item_array;
