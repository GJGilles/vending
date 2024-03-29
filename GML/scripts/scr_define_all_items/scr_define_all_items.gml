function scr_define_all_items() {

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
		w_parfait,
		s_parfait,
		yakitori,
		flan,
		milk_bread,
		castella,
		katsudon,
		w_katsudon,
		toriten,
		katsu_sando,
		w_katsu_sando,
		strawberry_sando,
		mochi_ice_cream,
		dorayaki
	}


	var item_array = array_create(0);

	item_array[ItemEnum.junk] = scr_define_item("Junk", ItemEnum.junk, 0, spr_junk, [-1, -1, -1, -1], "");
	item_array[ItemEnum.g_tea_leaves] = scr_define_item("Green Tea Leaves", ItemEnum.g_tea_leaves, 0, spr_g_tea_leaves, [-1, -1, -1, -1], "Tea leaves that are green and very very tasty. I would recommend.");
	item_array[ItemEnum.water] = scr_define_item("Water", ItemEnum.water, 0, spr_water, [-1, -1, -1, -1], "");
	item_array[ItemEnum.flour] = scr_define_item("Flour", ItemEnum.flour, 0, spr_flour, [-1, -1, -1, -1], "");
	item_array[ItemEnum.onion] = scr_define_item("Onion", ItemEnum.onion, 0, spr_onion, [-1, -1, -1, -1], "");
	item_array[ItemEnum.milk] = scr_define_item("Milk", ItemEnum.milk, 0, spr_milk, [-1, -1, -1, -1], "");
	item_array[ItemEnum.rice] = scr_define_item("Rice", ItemEnum.rice, 0, spr_rice, [-1, -1, -1, -1], "");
	item_array[ItemEnum.watermelon] = scr_define_item("Watermelon", ItemEnum.watermelon, 0, spr_watermelon, [-1, -1, -1, -1], "");
	item_array[ItemEnum.strawberries] = scr_define_item("Strawberries", ItemEnum.strawberries, 0, spr_strawberries, [-1, -1, -1, -1], "");
	item_array[ItemEnum.chicken] = scr_define_item("Chicken", ItemEnum.chicken, 0, spr_chicken, [-1, -1, -1, -1], "");
	item_array[ItemEnum.eggs] = scr_define_item("Eggs", ItemEnum.eggs, 0, spr_eggs, [-1, -1, -1, -1], "");
	item_array[ItemEnum.sugar] = scr_define_item("Sugar", ItemEnum.sugar, 0, spr_sugar, [-1, -1, -1, -1], "");
	item_array[ItemEnum.pork] = scr_define_item("Pork", ItemEnum.pork, 0, spr_pork, [-1, -1, -1, -1], "");
	item_array[ItemEnum.ginger] = scr_define_item("Ginger", ItemEnum.ginger, 0, spr_ginger, [-1, -1, -1, -1], "");

	item_array[ItemEnum.b_tea_leaves] = scr_define_item("Black Tea Leaves", ItemEnum.b_tea_leaves, 0, spr_b_tea_leaves, [-1, -1, -1, -1], "");
	item_array[ItemEnum.genmai] = scr_define_item("Genmai", ItemEnum.genmai, 0, spr_genmai, [-1, -1, -1, -1], "");
	item_array[ItemEnum.dough] = scr_define_item("Dough", ItemEnum.dough, 0, spr_dough, [-1, -1, -1, -1], "");
	item_array[ItemEnum.batter] = scr_define_item("Batter", ItemEnum.batter, 0, spr_batter, [-1, -1, -1, -1], "");
	item_array[ItemEnum.mochi] = scr_define_item("Mochi", ItemEnum.mochi, 0, spr_mochi, [-1, -1, -1, -1], "");

	item_array[ItemEnum.g_tea] = scr_define_item("Green Tea", ItemEnum.g_tea, 100, spr_g_tea, [ItemColorEnum.green, ItemTempEnum.cool, ItemFlavorEnum.bitter, ItemPrepEnum.simmered], "A grassy and refreshing tea that is delicious served hot or cold \n\nYokai prefer it cold so that they don't burn their tongues.");
	item_array[ItemEnum.b_tea] = scr_define_item("Black Tea", ItemEnum.b_tea, 100, spr_b_tea, [ItemColorEnum.black, ItemTempEnum.hot, ItemFlavorEnum.bitter, ItemPrepEnum.simmered], "");
	item_array[ItemEnum.royal_milk_tea] = scr_define_item("Royal Milk Tea", ItemEnum.royal_milk_tea, 200, spr_royal_milk_tea, [ItemColorEnum.black, ItemTempEnum.hot, ItemFlavorEnum.sweet, ItemPrepEnum.simmered], "");
	item_array[ItemEnum.genmaicha] = scr_define_item("Genmaicha", ItemEnum.genmaicha, 0, spr_genmaicha, [ItemColorEnum.green, ItemTempEnum.hot, ItemFlavorEnum.bitter, ItemPrepEnum.simmered], "");
	item_array[ItemEnum.ice_cream] = scr_define_item("Ice Cream", ItemEnum.ice_cream, 0, spr_ice_cream, [ItemColorEnum.white, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
	item_array[ItemEnum.amazake] = scr_define_item("Amazake", ItemEnum.amazake, 0, spr_amazake, [ItemColorEnum.white, ItemTempEnum.hot, ItemFlavorEnum.sweet, ItemPrepEnum.simmered], "");
	item_array[ItemEnum.yoink] = scr_define_item("Yoink", ItemEnum.yoink, 0, spr_yoink, [ItemColorEnum.white, ItemTempEnum.cool, ItemFlavorEnum.sour, ItemPrepEnum.raw], "");
	item_array[ItemEnum.w_parfait] = scr_define_item("Watermelon Parfait", ItemEnum.w_parfait, 0, spr_red_fruit_parfait, [ItemColorEnum.red, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
	item_array[ItemEnum.s_parfait] = scr_define_item("Strawberry Parfait", ItemEnum.s_parfait, 0, spr_red_fruit_parfait, [ItemColorEnum.red, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
	item_array[ItemEnum.yakitori] = scr_define_item("Yakitori", ItemEnum.yakitori, 0, spr_yakitori, [ItemColorEnum.red, ItemTempEnum.hot, ItemFlavorEnum.umami, ItemPrepEnum.roasted], "");
	item_array[ItemEnum.flan] = scr_define_item("Flan", ItemEnum.flan, 0, spr_flan, [ItemColorEnum.yellow, ItemTempEnum.cool, ItemFlavorEnum.sweet, ItemPrepEnum.roasted], "");
	item_array[ItemEnum.milk_bread] = scr_define_item("Milk Bread", ItemEnum.milk_bread, 0, spr_milk_bread, [ItemColorEnum.white, ItemTempEnum.room_temp, ItemFlavorEnum.sweet, ItemPrepEnum.roasted], "");
	item_array[ItemEnum.castella] = scr_define_item("Castella Cake", ItemEnum.castella, 0, spr_castella_cake, [ItemColorEnum.white, ItemTempEnum.room_temp, ItemFlavorEnum.sweet, ItemPrepEnum.roasted], "");
	item_array[ItemEnum.katsudon] = scr_define_item("Katsudon", ItemEnum.katsudon, 0, spr_katsudon, [ItemColorEnum.yellow, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
	item_array[ItemEnum.w_katsudon] = scr_define_item("Watermelon Katsudon", ItemEnum.w_katsudon, 0, spr_katsudon, [ItemColorEnum.red, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
	item_array[ItemEnum.toriten] = scr_define_item("Toriten", ItemEnum.toriten, 0, spr_toriten, [ItemColorEnum.yellow, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
	item_array[ItemEnum.katsu_sando] = scr_define_item("Katsu Sando", ItemEnum.katsu_sando, 0, spr_katsu_sando, [ItemColorEnum.yellow, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
	item_array[ItemEnum.w_katsu_sando] = scr_define_item("Watermelon Katsu Sando", ItemEnum.w_katsu_sando, 0, spr_katsu_sando, [ItemColorEnum.red, ItemTempEnum.warm, ItemFlavorEnum.umami, ItemPrepEnum.fried], "");
	item_array[ItemEnum.strawberry_sando] = scr_define_item("Strawberry Sando", ItemEnum.strawberry_sando, 0, spr_strawberry_sando, [ItemColorEnum.red, ItemTempEnum.cool, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
	item_array[ItemEnum.mochi_ice_cream] = scr_define_item("Mochi Ice Cream", ItemEnum.mochi_ice_cream, 0, spr_mochi_ice_cream, [ItemColorEnum.white, ItemTempEnum.cold, ItemFlavorEnum.sweet, ItemPrepEnum.raw], "");
	item_array[ItemEnum.dorayaki] = scr_define_item("Dorayaki", ItemEnum.dorayaki, 0, spr_dorayaki, [ItemColorEnum.yellow, ItemTempEnum.room_temp, ItemFlavorEnum.sweet, ItemPrepEnum.fried], "");

	return item_array;



}
