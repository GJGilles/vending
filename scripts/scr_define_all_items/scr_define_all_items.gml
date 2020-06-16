
enum ItemEnum {
	junk = 0,
	water = 1,
	g_tea_leaves = 2,
	g_tea = 3
}


var item_array = array_create(0);
item_array[ItemEnum.junk] = scr_define_item("Junk", ItemEnum.junk, spr_junk);
item_array[ItemEnum.water] = scr_define_item("Water", ItemEnum.water, spr_water);
item_array[ItemEnum.g_tea_leaves] = scr_define_item("Green Tea Leaves", ItemEnum.g_tea_leaves, spr_g_tea_leaves);
item_array[ItemEnum.g_tea] = scr_define_item("Green Tea", ItemEnum.g_tea, spr_g_tea);

return item_array;
