
var recipes = array_create(0);

recipes[0] = scr_define_recipe(ItemEnum.g_tea, ComponentEnum.steeper, [ItemEnum.g_tea_leaves, ItemEnum.water], [0, 0]);
recipes[1] = scr_define_recipe(ItemEnum.b_tea_leaves, ComponentEnum.tea_roaster, [ItemEnum.g_tea_leaves], [0]);
recipes[2] = scr_define_recipe(ItemEnum.b_tea, ComponentEnum.steeper, [ItemEnum.b_tea_leaves, ItemEnum.water], [1, 0]);
recipes[3] = scr_define_recipe(ItemEnum.royal_milk_tea, ComponentEnum.steeper, [ItemEnum.b_tea_leaves, ItemEnum.milk], [1, 0]);

return recipes;
