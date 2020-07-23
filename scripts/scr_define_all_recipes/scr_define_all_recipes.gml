
enum RecipeEnum {
	b_tea_leaves,
	genmai,
	dough,
	batter,
	mochi,
	wrapper,
	soba_noodles,
	ramen_noodles,
	udon_noodles,
	fish_cake,
	anko,
	dashi_stock,
	cha_cup,
	ramen_broth,
	ramen_base,
	cabbage_batter,
	
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


var recipes = array_create(0);

recipes[RecipeEnum.b_tea_leaves] = scr_define_recipe(RecipeEnum.b_tea_leaves, ItemEnum.b_tea_leaves, ComponentEnum.tea_roaster, array_sort([ItemEnum.g_tea_leaves, -1, -1, -1]), [0]);
recipes[RecipeEnum.genmai] = scr_define_recipe(RecipeEnum.b_tea_leaves, ItemEnum.b_tea_leaves, ComponentEnum.tea_roaster, array_sort([ItemEnum.rice, -1, -1, -1]), [0]);
recipes[RecipeEnum.dough] = scr_define_recipe(RecipeEnum.dough, ItemEnum.dough, ComponentEnum.blender, array_sort([ItemEnum.flour, ItemEnum.eggs, ItemEnum.sugar, -1]), [0, 0, 0]);
recipes[RecipeEnum.batter] = scr_define_recipe(RecipeEnum.batter, ItemEnum.batter, ComponentEnum.blender, array_sort([ItemEnum.flour, ItemEnum.eggs, ItemEnum.water, -1]), [0, 0, 0]);
recipes[RecipeEnum.mochi] = scr_define_recipe(RecipeEnum.mochi, ItemEnum.mochi, ComponentEnum.mochi_maker, array_sort([ItemEnum.rice, ItemEnum.water, -1, -1]), [0, 0]);

recipes[RecipeEnum.g_tea] = scr_define_recipe(RecipeEnum.g_tea, ItemEnum.g_tea, ComponentEnum.steeper, array_sort([ItemEnum.g_tea_leaves, ItemEnum.water, -1, -1]), [0, 0]);
recipes[RecipeEnum.b_tea] = scr_define_recipe(RecipeEnum.b_tea, ItemEnum.b_tea, ComponentEnum.steeper, array_sort([ItemEnum.b_tea_leaves, ItemEnum.water, -1, -1, -1]), [1, 0]);
recipes[RecipeEnum.royal_milk_tea] = scr_define_recipe(RecipeEnum.royal_milk_tea, ItemEnum.royal_milk_tea, ComponentEnum.steeper, array_sort([ItemEnum.b_tea_leaves, ItemEnum.milk, -1, -1]), [1, 0]);
recipes[RecipeEnum.genmaicha] = scr_define_recipe(RecipeEnum.genmaicha, ItemEnum.genmaicha, ComponentEnum.steeper, array_sort([ItemEnum.genmai, ItemEnum.water, -1, -1]), [1, 0]);
recipes[RecipeEnum.ice_cream] = scr_define_recipe(RecipeEnum.ice_cream, ItemEnum.ice_cream, ComponentEnum.freezer, array_sort([ItemEnum.milk, ItemEnum.milk, -1, -1]), [0, 0]);
recipes[RecipeEnum.amazake] = scr_define_recipe(RecipeEnum.amazake, ItemEnum.amazake, ComponentEnum.fermenter, array_sort([ItemEnum.rice, ItemEnum.water, -1, -1]), [0, 0]);
recipes[RecipeEnum.yoink] = scr_define_recipe(RecipeEnum.yoink, ItemEnum.yoink, ComponentEnum.fermenter, array_sort([ItemEnum.milk, ItemEnum.milk, -1, -1]), [0, 0]);
recipes[RecipeEnum.w_parfait] = scr_define_recipe(RecipeEnum.w_parfait, ItemEnum.w_parfait, ComponentEnum.freezer, array_sort([ItemEnum.ice_cream, ItemEnum.watermelon, -1, -1]), [1, 0]);
recipes[RecipeEnum.s_parfait] = scr_define_recipe(RecipeEnum.s_parfait, ItemEnum.s_parfait, ComponentEnum.freezer, array_sort([ItemEnum.ice_cream, ItemEnum.strawberries, -1, -1]), [1, 0]);
recipes[RecipeEnum.yakitori] = scr_define_recipe(RecipeEnum.yakitori, ItemEnum.yakitori, ComponentEnum.oven, array_sort([ItemEnum.onion, ItemEnum.chicken, -1, -1]), [0, 0]);
recipes[RecipeEnum.flan] = scr_define_recipe(RecipeEnum.flan, ItemEnum.flan, ComponentEnum.oven, array_sort([ItemEnum.eggs, ItemEnum.milk, -1, -1]), [0, 0]);
recipes[RecipeEnum.milk_bread] = scr_define_recipe(RecipeEnum.milk_bread, ItemEnum.milk_bread, ComponentEnum.oven, array_sort([ItemEnum.dough, ItemEnum.milk, -1, -1]), [1, 0]);
recipes[RecipeEnum.castella] = scr_define_recipe(RecipeEnum.castella, ItemEnum.castella, ComponentEnum.oven, array_sort([ItemEnum.dough, ItemEnum.sugar, -1, -1]), [1, 0]);
recipes[RecipeEnum.katsudon] = scr_define_recipe(RecipeEnum.katsudon, ItemEnum.katsudon, ComponentEnum.deep_fryer, array_sort([ItemEnum.batter, ItemEnum.batter, ItemEnum.pork, -1]), [1, 1, 0]);
recipes[RecipeEnum.w_katsudon] = scr_define_recipe(RecipeEnum.w_katsudon, ItemEnum.w_katsudon, ComponentEnum.deep_fryer, array_sort([ItemEnum.batter, ItemEnum.batter, ItemEnum.watermelon, -1]), [1, 1, 0]);
recipes[RecipeEnum.toriten] = scr_define_recipe(RecipeEnum.toriten, ItemEnum.toriten, ComponentEnum.deep_fryer, array_sort([ItemEnum.batter, ItemEnum.chicken, ItemEnum.ginger, -1]), [1, 0, 0]);
recipes[RecipeEnum.katsu_sando] = scr_define_recipe(RecipeEnum.katsu_sando, ItemEnum.katsu_sando, ComponentEnum.sandwich_maker, array_sort([ItemEnum.milk_bread, ItemEnum.katsudon, -1, -1]), [1, 1]);
recipes[RecipeEnum.w_katsu_sando] = scr_define_recipe(RecipeEnum.w_katsu_sando, ItemEnum.w_katsu_sando, ComponentEnum.sandwich_maker, array_sort([ItemEnum.milk_bread, ItemEnum.w_katsudon, -1, -1]), [1, 1]);
recipes[RecipeEnum.strawberry_sando] = scr_define_recipe(RecipeEnum.strawberry_sando, ItemEnum.strawberry_sando, ComponentEnum.sandwich_maker, array_sort([ItemEnum.milk_bread, ItemEnum.strawberries, -1, -1]), [1, 0]);
recipes[RecipeEnum.mochi_ice_cream] = scr_define_recipe(RecipeEnum.mochi_ice_cream, ItemEnum.mochi_ice_cream, ComponentEnum.freezer, array_sort([ItemEnum.mochi, ItemEnum.ice_cream, -1, -1]), [1, 1]);

return recipes;
