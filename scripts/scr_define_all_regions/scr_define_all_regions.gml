
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
	hiroshima
}

enum MapWeatherEnum {
	snow = 0,
	rain = 1,
	overcast = 2,
	clear = 3,
	heat_wave = 4
}


var regions = array_create(0);

regions[MapRegionEnum.hokkaido] = scr_define_region("Hokkaido", MapRegionEnum.hokkaido, [[-8, 15], [11, 23], [-2, 18], [-11, -3]], [0.6, 0.5, 0.6, 0.8,], []);
regions[MapRegionEnum.tohoku] = scr_define_region("Tohoku", MapRegionEnum.tohoku, [[-1, 19], [15, 27], [4, 23], [-4, 3]], [0.55, 0.55, 0.55, 0.7,], []);
regions[MapRegionEnum.kanto] = scr_define_region("Kanto", MapRegionEnum.kanto, [[4, 22], [18, 30], [9, 26], [1, 10]], [0.4, 0.4, 0.4, 0.3,], []);
regions[MapRegionEnum.chubu] = scr_define_region("Chubu", MapRegionEnum.chubu, [[1, 20], [16, 27], [5, 24], [-3, 6]], [0.5, 0.7, 0.5, 0.5,], []);
regions[MapRegionEnum.kansai] = scr_define_region("Kansai", MapRegionEnum.kansai, [[5, 23], [19, 31], [9, 27], [2, 10]], [0.4, 0.45, 0.4, 0.3,], []);


var chugoku = [
	scr_define_location("Hiroshima", MapLocationEnum.hiroshima, [0, 0], [scr_location_hiroshima_a()])
];
regions[MapRegionEnum.chugoku] = scr_define_region("Chugoku", MapRegionEnum.chugoku, [[4, 23], [18, 30], [8, 27], [2, 11]], [0.4, 0.5, 0.4, 0.3,], chugoku);


regions[MapRegionEnum.shikoku] = scr_define_region("Shikoku", MapRegionEnum.shikoku, [[4, 22], [18, 28], [8, 26], [1, 11]], [0.35, 0.55, 0.4, 0.3,], []);
regions[MapRegionEnum.kyushu] = scr_define_region("Kyushu", MapRegionEnum.kyushu, [[7, 25], [21, 31], [11, 28], [4, 13]], [0.4, 0.6, 0.4, 0.3,], []);
regions[MapRegionEnum.okinawa] = scr_define_region("Okinawa", MapRegionEnum.okinawa, [[17, 23], [25, 28], [22, 27], [16, 19]], [0.45, 0.5, 0.4, 0.4,], []);

return regions;
