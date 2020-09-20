function scr_define_all_special() {


	var special_array = array_create(0);

	special_array[ItemEnum.junk] = -1;
	special_array[ItemEnum.g_tea_leaves] = scr_define_special("Uji", ItemEnum.g_tea_leaves, MapRegionEnum.kansai, [1, 1, 0, 0, 0, 0, 0, 0], 2);
	special_array[ItemEnum.water] = -1;
	special_array[ItemEnum.flour] = -1;
	special_array[ItemEnum.onion] = -1;
	special_array[ItemEnum.milk] = scr_define_special("Hokkaido", ItemEnum.milk, MapRegionEnum.hokkaido, [0, 0, 1, 1, 0, 0, 0, 0], 2);
	special_array[ItemEnum.rice] = scr_define_special("Uonuma", ItemEnum.rice, MapRegionEnum.chubu, [1, 1, 0, 0, 1, 1, 0, 0], 2);
	special_array[ItemEnum.watermelon] = scr_define_special("Kurayoshi", ItemEnum.watermelon, MapRegionEnum.chugoku, [0, 0, 1, 1, 0, 0, 0, 0], 2);
	special_array[ItemEnum.strawberries] = scr_define_special("Tochi Otome", ItemEnum.strawberries, MapRegionEnum.kanto, [0, 0, 1, 1, 0, 0, 0, 0], 2);
	special_array[ItemEnum.chicken] = scr_define_special("Satsuma", ItemEnum.chicken, MapRegionEnum.kyushu, [0, 0, 0, 0, 1, 1, 1, 0], 2);
	special_array[ItemEnum.eggs] = scr_define_special("Kochin", ItemEnum.eggs, MapRegionEnum.chubu, [0, 0, 1, 1, 0, 0, 0, 0], 2);
	special_array[ItemEnum.sugar] = scr_define_special("Wasanbon", ItemEnum.sugar, MapRegionEnum.shikoku, [0, 0, 0, 0, 0, 0, 1, 1], 2);
	special_array[ItemEnum.pork] = scr_define_special("Agu", ItemEnum.pork, MapRegionEnum.okinawa, [0, 0, 0, 0, 1, 1, 1, 0], 2);
	special_array[ItemEnum.ginger] = scr_define_special("Shimanto", ItemEnum.ginger, MapRegionEnum.shikoku, [0, 0, 0, 0, 1, 1, 1, 1], 2);

	return special_array;



}
