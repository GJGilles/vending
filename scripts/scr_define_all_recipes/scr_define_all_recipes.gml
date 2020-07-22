
enum RecipeEnum {
	b_tea_leaves,
	genmai,
	basic_dough,
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
	milk_tea,
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

recipes[0] = scr_define_recipe(0, ItemEnum.g_tea, ComponentEnum.steeper, array_sort([ItemEnum.g_tea_leaves, ItemEnum.water, -1, -1]), [0, 0]);
recipes[1] = scr_define_recipe(1, ItemEnum.b_tea_leaves, ComponentEnum.tea_roaster, array_sort([ItemEnum.g_tea_leaves, -1, -1, -1]), [0]);
recipes[2] = scr_define_recipe(2, ItemEnum.b_tea, ComponentEnum.steeper, array_sort([ItemEnum.b_tea_leaves, ItemEnum.water, -1, -1, -1]), [1, 0]);
recipes[3] = scr_define_recipe(3, ItemEnum.royal_milk_tea, ComponentEnum.steeper, array_sort([ItemEnum.b_tea_leaves, ItemEnum.milk, -1, -1]), [1, 0]);

return recipes;
