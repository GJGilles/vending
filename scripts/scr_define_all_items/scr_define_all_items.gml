
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
	roasted = 4
}

enum ItemEnum {
	junk,
	g_tea_leaves,
	water,
	flour,
	onion,
	milk,
	rice,
	watermelon,
	strawberries,
	chicken,
	eggs,
	sugar,
	pork,
	ginger,
	
	b_tea_leaves,
	genmai,
	dough,
	batter,
	mochi,
	
	g_tea,
	b_tea,
	royal_milk_tea,
	genmaicha,
	ice_cream,
	amazake,
	yoink,
	watermelon_parfait,
	strawberry_parfait,
	yakitori,
	flan,
	milk_bread,
	castella_cake,
	katsudon,
	watermelon_katsu,
	toriten,
	katsu_sando,
	watermelon_katsu_sando,
	strawberry_sando,
	mochi_ice_cream,
	dorayaki
}


var item_array = array_create(0);

item_array[ItemEnum.junk] = scr_define_item("Junk", ItemEnum.junk, 0, spr_junk, [], "");
item_array[ItemEnum.g_tea_leaves] = scr_define_item("Green Tea Leaves", ItemEnum.g_tea_leaves, 0, spr_g_tea_leaves, [], "");
item_array[ItemEnum.water] = scr_define_item("Water", ItemEnum.water, 0, spr_water, [], "");
item_array[ItemEnum.flour] = scr_define_item("Flour", ItemEnum.flour, 0, spr_flour, [], "");
item_array[ItemEnum.onion] = scr_define_item("Onion", ItemEnum.onion, 0, spr_onion, [], "");
item_array[ItemEnum.milk] = scr_define_item("Milk", ItemEnum.milk, 0, spr_milk, [], "");
item_array[ItemEnum.rice] = scr_define_item("Rice", ItemEnum.rice, 0, spr_rice, [], "");
item_array[ItemEnum.watermelon] = scr_define_item("Watermelon", ItemEnum.watermelon, 0, spr_watermelon, [], "");
item_array[ItemEnum.strawberries] = scr_define_item("Strawberries", ItemEnum.strawberries, 0, spr_strawberries, [], "");
item_array[ItemEnum.chicken] = scr_define_item("Chicken", ItemEnum.chicken, 0, spr_chicken, [], "");
item_array[ItemEnum.eggs] = scr_define_item("Eggs", ItemEnum.eggs, 0, spr_eggs, [], "");
item_array[ItemEnum.sugar] = scr_define_item("Sugar", ItemEnum.sugar, 0, spr_sugar, [], "");
item_array[ItemEnum.pork] = scr_define_item("Pork", ItemEnum.pork, 0, spr_pork, [], "");
item_array[ItemEnum.ginger] = scr_define_item("Ginger", ItemEnum.ginger, 0, spr_ginger, [], "");

item_array[ItemEnum.b_tea_leaves] = scr_define_item("Black Tea Leaves", ItemEnum.b_tea_leaves, 0, spr_b_tea_leaves, [], "");
item_array[ItemEnum.genmai] = scr_define_item("Genmai", ItemEnum.genmai, 0, spr_genmai, [], "");
item_array[ItemEnum.dough] = scr_define_item("Dough", ItemEnum.dough, 0, spr_dough, [], "");
item_array[ItemEnum.batter] = scr_define_item("Batter", ItemEnum.batter, 0, spr_batter, [], "");
item_array[ItemEnum.mochi] = scr_define_item("Mochi", ItemEnum.mochi, 0, spr_mochi, [], "");

item_array[ItemEnum.g_tea] = scr_define_item("Green Tea", ItemEnum.g_tea, 100, spr_g_tea, [ItemColorEnum.green, ItemTempEnum.cool, ItemFlavorEnum.bitter, ItemPrepEnum.simmered], "");
item_array[ItemEnum.b_tea] = scr_define_item("Black Tea", ItemEnum.b_tea, 100, spr_b_tea, [ItemColorEnum.black, ItemTempEnum.hot, ItemFlavorEnum.bitter, ItemPrepEnum.simmered], "");
item_array[ItemEnum.royal_milk_tea] = scr_define_item("Royal Milk Tea", ItemEnum.royal_milk_tea, 200, spr_royal_milk_tea, [ItemColorEnum.black, ItemTempEnum.hot, ItemFlavorEnum.sweet, ItemPrepEnum.simmered], "");
item_array[ItemEnum.genmaicha] = scr_define_item("Genmaicha", ItemEnum.genmaicha, 0, spr_genmaicha, [ItemColorEnum.green, ItemTempEnum.hot, ItemFlavorEnum.bitter, ItemPrepEnum.simmered], "");
item_array[ItemEnum.ice_cream] = scr_define_item("Ice Cream", ItemEnum.ice_cream, 0, spr_ice_cream, [ItemColorEnum.white, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
item_array[ItemEnum.amazake] = scr_define_item("Amazake", ItemEnum.amazake, 0, spr_amazake, [ItemColorEnum.white, ItemTempEnum.hot, ItemFlavorEnum.sweet, ItemPrepEnum.simmered], "");
item_array[ItemEnum.yoink] = scr_define_item("Yoink", ItemEnum.yoink, 0, spr_yoink, [ItemColorEnum.white, ItemTempEnum.cool, ItemFlavorEnum.sour, ItemPrepEnum.raw], "");
item_array[ItemEnum.watermelon_parfait] = scr_define_item("Watermelon Parfait", ItemEnum.watermelon_parfait, 0, spr_red_fruit_parfait, [ItemColorEnum.red, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
item_array[ItemEnum.strawberry_parfait] = scr_define_item("Strawberry Parfait", ItemEnum.strawberry_parfait, 0, spr_red_fruit_parfait, [ItemColorEnum.red, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
item_array[ItemEnum.yakitori] = scr_define_item("Yakitori", ItemEnum.yakitori, 0, spr_yakitori, [ItemColorEnum.red, ItemTempEnum.hot, ItemFlavorEnum.umami, ItemPrepEnum.roasted], "");
item_array[ItemEnum.flan] = scr_define_item("Flan", ItemEnum.flan, 0, spr_flan, [ItemColorEnum.yellow, ItemTempEnum.cool, ItemFlavorEnum.sweet, ItemPrepEnum.roasted], "");
item_array[ItemEnum.milk_bread] = scr_define_item("Milk Bread", ItemEnum.milk_bread, 0, spr_milk_bread, [ItemColorEnum.white, ItemTempEnum.room_temp, ItemFlavorEnum.sweet, ItemPrepEnum.roasted], "");
item_array[ItemEnum.castella_cake] = scr_define_item("Castella Cake", ItemEnum.castella_cake, 0, spr_castella_cake, [ItemColorEnum.white, ItemTempEnum.room_temp, ItemFlavorEnum.sweet, ItemPrepEnum.roasted], "");
item_array[ItemEnum.katsudon] = scr_define_item("Katsudon", ItemEnum.katsudon, 0, spr_katsudon, [ItemColorEnum.yellow, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
item_array[ItemEnum.watermelon_katsu] = scr_define_item("Watermelon Katsudon", ItemEnum.watermelon_katsu, 0, spr_katsudon, [ItemColorEnum.red, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
item_array[ItemEnum.toriten] = scr_define_item("Toriten", ItemEnum.toriten, 0, spr_toriten, [ItemColorEnum.yellow, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
item_array[ItemEnum.katsu_sando] = scr_define_item("Katsu Sando", ItemEnum.katsu_sando, 0, spr_katsu_sando, [ItemColorEnum.yellow, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
item_array[ItemEnum.watermelon_katsu_sando] = scr_define_item("Watermelon Katsu Sando", ItemEnum.watermelon_katsu_sando, 0, spr_katsu_sando, [ItemColorEnum.red, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
item_array[ItemEnum.strawberry_sando] = scr_define_item("Strawberry Sando", ItemEnum.strawberry_sando, 0, spr_strawberry_sando, [ItemColorEnum.red, ItemTempEnum.cool, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
item_array[ItemEnum.mochi_ice_cream] = scr_define_item("Mochi Ice Cream", ItemEnum.mochi_ice_cream, 0, spr_mochi_ice_cream, [ItemColorEnum.white, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
item_array[ItemEnum.dorayaki] = scr_define_item("Dorayaki", ItemEnum.dorayaki, 0, spr_dorayaki, [ItemColorEnum.yellow, ItemTempEnum.room_temp, ItemFlavorEnum.sweet, ItemPrepEnum.fried], "");

return item_array;
