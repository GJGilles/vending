
var quest_arr = array_create(0);

quest_arr[0] = scr_define_quest(0, [[ItemEnum.g_tea, 0, 10]], true, [1], [], [ComponentEnum.tea_roaster], [ItemEnum.b_tea_leaves], [], []);
quest_arr[1] = scr_define_quest(1, [[ItemEnum.b_tea, 0, 10]], true, [2], [], [], [ItemEnum.milk], [], []);
quest_arr[2] = scr_define_quest(2, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);

return quest_arr;
