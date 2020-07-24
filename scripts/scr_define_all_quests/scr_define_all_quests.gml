
enum QuestEnum {
	Hiro0,
	Hiro1,
	Hiro2,
	Hiro3,
	Hiro4,
	
	HiroA,
	HiroB,
	
	Okay0,
	Okay1,
	Okay2,
	Okay3,
	
	OkayA,
	
	Kyo0,
	Kyo1,
	Kyo2,
	
	KyoA,
	KyoB,
	
	Toky0,
	Toky1,
	Toky2,
	
	TokyA,
	
	Send0,
	Send1,
	Send2,
	Send3,
	
	SendA,
	SendB,
	
}


var quest_arr = array_create(0);

quest_arr[QuestEnum.Hiro0] = scr_define_quest(QuestEnum.Hiro0, [], true, [QuestEnum.Hiro1], [], [], [], [], []);
quest_arr[QuestEnum.Hiro1] = scr_define_quest(QuestEnum.Hiro1, [[ItemEnum.g_tea, 0, 10]], true, [QuestEnum.Hiro2], [], [ComponentEnum.tea_roaster], [ItemEnum.b_tea_leaves], [], []);
quest_arr[QuestEnum.Hiro2] = scr_define_quest(QuestEnum.Hiro2, [[ItemEnum.b_tea, 0, 10]], true, [QuestEnum.Hiro3, QuestEnum.HiroA], [], [], [ItemEnum.milk, ItemEnum.rice], [], []);
quest_arr[QuestEnum.Hiro3] = scr_define_quest(QuestEnum.Hiro3, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [QuestEnum.Hiro4], [], [ComponentEnum.freezer], [], [], []);
quest_arr[QuestEnum.Hiro4] = scr_define_quest(QuestEnum.Hiro4, [[ItemEnum.ice_cream, 0, 10], [ItemEnum.royal_milk_tea, 0, 10], [ItemEnum.genmaicha, 0, 10]], true, [QuestEnum.Okay0], [], [], [], [], []);

quest_arr[QuestEnum.HiroA] = scr_define_quest(QuestEnum.HiroA, [[ItemEnum.b_tea, 0, 10], [ItemEnum.genmaicha, 0, 10]], true, [QuestEnum.HiroB], [], [], [], [], []);
quest_arr[QuestEnum.HiroB] = scr_define_quest(QuestEnum.HiroB, [[ItemEnum.amazake, 0, 10], [ItemEnum.yoink, 0, 10]], true, [], [], [], [], [], []);

quest_arr[QuestEnum.Okay0] = scr_define_quest(QuestEnum.Okay0, [], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Okay1] = scr_define_quest(QuestEnum.Okay1, [[ItemEnum.w_parfait, 0, 10], [ItemEnum.s_parfait, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Okay2] = scr_define_quest(QuestEnum.Okay2, [[ItemEnum.yakitori, 0, 10], [ItemEnum.flan, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Okay3] = scr_define_quest(QuestEnum.Okay3, [[ItemEnum.milk_bread, 0, 10], [ItemEnum.castella, 0, 10], [ItemEnum.flan, 0, 10]], true, [], [], [], [], [], []);

quest_arr[QuestEnum.OkayA] = scr_define_quest(QuestEnum.OkayA, [], true, [], [], [], [], [], []); // Hokkaido Milk Bread

quest_arr[QuestEnum.Kyo0] = scr_define_quest(QuestEnum.Kyo0, [], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Kyo1] = scr_define_quest(QuestEnum.Kyo1, [[ItemEnum.katsudon, 0, 10], [ItemEnum.w_katsudon, 0, 10], [ItemEnum.toriten, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Kyo2] = scr_define_quest(QuestEnum.Kyo2, [[ItemEnum.katsu_sando, 0, 10], [ItemEnum.w_katsu_sando, 0, 10], [ItemEnum.strawberry_sando, 0, 10]], true, [], [], [], [], [], []);

quest_arr[QuestEnum.KyoA] = scr_define_quest(QuestEnum.KyoA, [], true, [], [], [], [], [], []); // Uji Green Tea
quest_arr[QuestEnum.KyoB] = scr_define_quest(QuestEnum.KyoB, [[ItemEnum.mochi_ice_cream, 0, 10], [ItemEnum.dorayaki, 0, 10]], true, [], [], [], [], [], []);

quest_arr[QuestEnum.Toky0] = scr_define_quest(QuestEnum.Toky0, [], true, [], [], [], [], [], []);
/*quest_arr[QuestEnum.Toky1] = scr_define_quest(QuestEnum.Toky1, [[ItemEnum.maki, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Toky2] = scr_define_quest(QuestEnum.Toky2, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);

quest_arr[QuestEnum.TokyA] = scr_define_quest(QuestEnum.TokyA, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);

quest_arr[QuestEnum.Send0] = scr_define_quest(QuestEnum.Send0, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Send1] = scr_define_quest(QuestEnum.Send1, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Send2] = scr_define_quest(QuestEnum.Send2, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.Send3] = scr_define_quest(QuestEnum.Send3, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);

quest_arr[QuestEnum.SendA] = scr_define_quest(QuestEnum.SendA, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);
quest_arr[QuestEnum.SendB] = scr_define_quest(QuestEnum.SendB, [[ItemEnum.g_tea, 0, 10], [ItemEnum.royal_milk_tea, 0, 10]], true, [], [], [], [], [], []);*/

return quest_arr;
