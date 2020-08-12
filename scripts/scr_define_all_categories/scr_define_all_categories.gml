
enum CategoryEnum {
	full,
	prep,
	drinks,
	snacks,
	meals,
	desserts
}


var recipes = array_create(0);
recipes[CategoryEnum.full] = array_create(0);
recipes[CategoryEnum.prep] = [RecipeEnum.b_tea_leaves, RecipeEnum.genmai, RecipeEnum.dough, RecipeEnum.batter, RecipeEnum.mochi];
recipes[CategoryEnum.drinks] = [RecipeEnum.g_tea, RecipeEnum.b_tea, RecipeEnum.royal_milk_tea, RecipeEnum.genmaicha, RecipeEnum.amazake, RecipeEnum.yoink];
recipes[CategoryEnum.snacks] = [RecipeEnum.yakitori, RecipeEnum.milk_bread, RecipeEnum.toriten];
recipes[CategoryEnum.meals] = [RecipeEnum.katsudon, RecipeEnum.w_katsudon, RecipeEnum.katsu_sando, RecipeEnum.w_katsu_sando];
recipes[CategoryEnum.desserts] = [RecipeEnum.ice_cream, RecipeEnum.w_parfait, RecipeEnum.s_parfait, RecipeEnum.flan, RecipeEnum.castella, RecipeEnum.strawberry_sando, RecipeEnum.mochi_ice_cream];

for (var i = 1; i < array_length_1d(recipes); i++) {
	recipes[CategoryEnum.full] = array_add(recipes[CategoryEnum.full], recipes[i]);
}


var categories = array_create(0);

categories[CategoryEnum.full] = scr_define_category("All", CategoryEnum.full, recipes[CategoryEnum.full]);
categories[CategoryEnum.prep] = scr_define_category("Prep", CategoryEnum.prep, recipes[CategoryEnum.prep]);
categories[CategoryEnum.drinks] = scr_define_category("Drinks", CategoryEnum.drinks, recipes[CategoryEnum.drinks]);
categories[CategoryEnum.snacks] = scr_define_category("Snacks", CategoryEnum.snacks, recipes[CategoryEnum.snacks]);
categories[CategoryEnum.meals] = scr_define_category("Meals", CategoryEnum.meals, recipes[CategoryEnum.meals]);
categories[CategoryEnum.desserts] = scr_define_category("Desserts", CategoryEnum.desserts, recipes[CategoryEnum.desserts]);

return categories;
