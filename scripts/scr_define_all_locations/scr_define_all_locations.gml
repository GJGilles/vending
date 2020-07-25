
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


var locations = array_create(0);

locations[MapLocationEnum.sapporo] = scr_define_location("Sapporo", MapLocationEnum.sapporo, [576, 172], MapRegionEnum.hokkaido, [scr_location_sapporo_a()]);
locations[MapLocationEnum.sendai] = scr_define_location("Sendai", MapLocationEnum.sendai, [550, 308], MapRegionEnum.tohoku, [scr_location_sendai_a()]);
locations[MapLocationEnum.aomori] = scr_define_location("Aomori", MapLocationEnum.aomori, [554, 460], MapRegionEnum.tohoku, [scr_location_aomori_a()]);
locations[MapLocationEnum.tokyo] = scr_define_location("Tokyo", MapLocationEnum.tokyo, [500, 604], MapRegionEnum.kanto, [scr_location_tokyo_a()]);
locations[MapLocationEnum.shizuoka] = scr_define_location("Shizuoka", MapLocationEnum.shizuoka, [438, 640], MapRegionEnum.chubu, [scr_location_hiroshima_a()]);
locations[MapLocationEnum.kyoto] = scr_define_location("Kyoto", MapLocationEnum.kyoto, [318, 644], MapRegionEnum.kansai, [scr_location_kyoto_a()]);
locations[MapLocationEnum.osaka] = scr_define_location("Osaka", MapLocationEnum.osaka, [310, 664], MapRegionEnum.kansai, [scr_location_osaka_a()]);
locations[MapLocationEnum.hiroshima] = scr_define_location("Hiroshima", MapLocationEnum.hiroshima, [174, 678], MapRegionEnum.chugoku, [scr_location_hiroshima_a()]);
locations[MapLocationEnum.okayama] = scr_define_location("Okayama", MapLocationEnum.okayama, [238, 664], MapRegionEnum.chugoku, [scr_location_okayama_a()]);
locations[MapLocationEnum.matsuyama] = scr_define_location("Matsuyama", MapLocationEnum.matsuyama, [182, 718], MapRegionEnum.shikoku, [scr_location_matsuyama_a()]);
locations[MapLocationEnum.kagoshima] = scr_define_location("Kagoshima", MapLocationEnum.kagoshima, [80, 828], MapRegionEnum.kyushu, [scr_location_kagoshima_a()]);
locations[MapLocationEnum.naha] = scr_define_location("Naha", MapLocationEnum.naha, [0, 0], MapRegionEnum.okinawa, [scr_location_naha_a()]);
	
return locations;
