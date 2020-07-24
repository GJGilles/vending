
enum MapRegionEnum {
	hokkaido = 0,
	tohoku = 1,
	kanto = 2,
	chubu = 3, 
	kansai = 4,
	chugoku = 5,
	shikoku = 6,
	kyushu = 7,
	okinawa = 8
}

enum MapLocationEnum {
	hiroshima,
	okayama,
	kyoto,
	tokyo,
	sendai,
	sapporo,
	matsuyama,
	naha,
	aomori,
	shizuoka,
	kagoshima,
	osaka
}

enum MapWeatherEnum {
	snow = 0,
	rain = 1,
	overcast = 2,
	clear = 3,
	heat_wave = 4
}


var regions = array_create(0);

var hokkaido = [
	scr_define_location("Sapporo", MapLocationEnum.sapporo, [0, 0], [scr_location_sapporo_a()])
];
regions[MapRegionEnum.hokkaido] = scr_define_region("Hokkaido", MapRegionEnum.hokkaido, [[-8, 15], [11, 23], [-2, 18], [-11, -3]], [0.6, 0.5, 0.6, 0.8,], hokkaido);

var tohoku = [
	scr_define_location("Sendai", MapLocationEnum.sendai, [0, 0], [scr_location_sendai_a()]),
	scr_define_location("Aomori", MapLocationEnum.aomori, [0, 0], [scr_location_aomori_a()])
];
regions[MapRegionEnum.tohoku] = scr_define_region("Tohoku", MapRegionEnum.tohoku, [[-1, 19], [15, 27], [4, 23], [-4, 3]], [0.55, 0.55, 0.55, 0.7,], tohoku);

var  kanto = [
	scr_define_location("Tokyo", MapLocationEnum.tokyo, [0, 0], [scr_location_tokyo_a()])
];
regions[MapRegionEnum.kanto] = scr_define_region("Kanto", MapRegionEnum.kanto, [[4, 22], [18, 30], [9, 26], [1, 10]], [0.4, 0.4, 0.4, 0.3,], kanto);

var chubu = [
	scr_define_location("Shizuoka", MapLocationEnum.shizuoka, [0, 0], [scr_location_hiroshima_a()])
];
regions[MapRegionEnum.chubu] = scr_define_region("Chubu", MapRegionEnum.chubu, [[1, 20], [16, 27], [5, 24], [-3, 6]], [0.5, 0.7, 0.5, 0.5,], chubu);

var kansai = [
	scr_define_location("Kyoto", MapLocationEnum.kyoto, [0, 0], [scr_location_kyoto_a()]),
	scr_define_location("Osaka", MapLocationEnum.osaka, [0, 0], [scr_location_osaka_a()])
];
regions[MapRegionEnum.kansai] = scr_define_region("Kansai", MapRegionEnum.kansai, [[5, 23], [19, 31], [9, 27], [2, 10]], [0.4, 0.45, 0.4, 0.3,], kansai);

var chugoku = [
	scr_define_location("Hiroshima", MapLocationEnum.hiroshima, [0, 0], [scr_location_hiroshima_a()]),
	scr_define_location("Okayama", MapLocationEnum.okayama, [0, 0], [scr_location_okayama_a()])
];
regions[MapRegionEnum.chugoku] = scr_define_region("Chugoku", MapRegionEnum.chugoku, [[4, 23], [18, 30], [8, 27], [2, 11]], [0.4, 0.5, 0.4, 0.3,], chugoku);

var shikoku = [
	scr_define_location("Matsuyama", MapLocationEnum.matsuyama, [0, 0], [scr_location_matsuyama_a()])
];
regions[MapRegionEnum.shikoku] = scr_define_region("Shikoku", MapRegionEnum.shikoku, [[4, 22], [18, 28], [8, 26], [1, 11]], [0.35, 0.55, 0.4, 0.3,], shikoku);

var kyushu = [
	scr_define_location("Kagoshima", MapLocationEnum.kagoshima, [0, 0], [scr_location_kagoshima_a()])
];
regions[MapRegionEnum.kyushu] = scr_define_region("Kyushu", MapRegionEnum.kyushu, [[7, 25], [21, 31], [11, 28], [4, 13]], [0.4, 0.6, 0.4, 0.3,], kyushu);

var okinawa = [
	scr_define_location("Naha", MapLocationEnum.naha, [0, 0], [scr_location_naha_a()])
];
regions[MapRegionEnum.okinawa] = scr_define_region("Okinawa", MapRegionEnum.okinawa, [[17, 23], [25, 28], [22, 27], [16, 19]], [0.45, 0.5, 0.4, 0.4,], okinawa);

return regions;
