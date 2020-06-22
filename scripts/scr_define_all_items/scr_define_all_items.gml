
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
item_array[ItemEnum.junk] = scr_define_item("Junk", ItemEnum.junk, spr_junk);
item_array[ItemEnum.water] = scr_define_item("Water", ItemEnum.water, spr_water);
item_array[ItemEnum.g_tea_leaves] = scr_define_item("Green Tea Leaves", ItemEnum.g_tea_leaves, spr_g_tea_leaves);
item_array[ItemEnum.g_tea] = scr_define_item("Green Tea", ItemEnum.g_tea, spr_g_tea);
item_array[ItemEnum.b_tea] = scr_define_item("Black Tea", ItemEnum.b_tea, spr_b_tea);
item_array[ItemEnum.b_tea_leaves] = scr_define_item("Black Tea Leaves", ItemEnum.b_tea_leaves, spr_b_tea_leaves);
item_array[ItemEnum.milk] = scr_define_item("Milk", ItemEnum.milk, spr_milk);
item_array[ItemEnum.royal_milk_tea] = scr_define_item("Royal Milk Tea", ItemEnum.royal_milk_tea, spr_royal_milk_tea);

return item_array;
