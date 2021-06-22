// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function scr_define_all_traits(){
	
	enum ItemColorEnum {
		white = 0,
		green = 1,
		black = 2,
		yellow = 3,
		red = 4,
		none = -1
	}
	
	var color_arr = array_create(0);
	color_arr[ItemColorEnum.white] = scr_define_trait("White", ItemColorEnum.white);
	color_arr[ItemColorEnum.green] = scr_define_trait("Green", ItemColorEnum.green);
	color_arr[ItemColorEnum.black] = scr_define_trait("Black", ItemColorEnum.black);
	color_arr[ItemColorEnum.yellow] = scr_define_trait("Yellow", ItemColorEnum.yellow);
	color_arr[ItemColorEnum.red] = scr_define_trait("Red", ItemColorEnum.red);
	

	enum ItemTempEnum {
		hot = 0, // < 0
		warm = 1, // 0 - 20
		room_temp = 2, // 20 - 22
		cool = 3, // 22 - 26
		cold = 4 // > 26
	}
	
	var temp_arr = array_create(0);
	temp_arr[ItemTempEnum.hot] = scr_define_trait("Hot", ItemTempEnum.hot);
	temp_arr[ItemTempEnum.warm] = scr_define_trait("Warm", ItemTempEnum.warm);
	temp_arr[ItemTempEnum.room_temp] = scr_define_trait("Room Temp", ItemTempEnum.room_temp);
	temp_arr[ItemTempEnum.cool] = scr_define_trait("Cool", ItemTempEnum.cool);
	temp_arr[ItemTempEnum.cold] = scr_define_trait("Cold", ItemTempEnum.cold);
	

	enum ItemFlavorEnum {
		salty = 0,
		sweet = 1,
		sour = 2,
		bitter = 3,
		umami = 4,
		none = -1
	}
	
	var flavor_arr = array_create(0);
	flavor_arr[ItemFlavorEnum.salty] = scr_define_trait("Salty", ItemFlavorEnum.salty);
	flavor_arr[ItemFlavorEnum.sweet] = scr_define_trait("Sweet", ItemFlavorEnum.sweet);
	flavor_arr[ItemFlavorEnum.sour] = scr_define_trait("Sour", ItemFlavorEnum.sour);
	flavor_arr[ItemFlavorEnum.bitter] = scr_define_trait("Bitter", ItemFlavorEnum.bitter);
	flavor_arr[ItemFlavorEnum.umami] = scr_define_trait("Umami", ItemFlavorEnum.umami);
	

	enum ItemPrepEnum {
		raw = 0,
		simmered = 1,
		fried = 2,
		steamed = 3,
		roasted = 4
	}
	
	var prep_arr = array_create(0);
	prep_arr[ItemPrepEnum.raw] = scr_define_trait("Raw", ItemPrepEnum.raw);
	prep_arr[ItemPrepEnum.simmered] = scr_define_trait("Simmered", ItemPrepEnum.simmered);
	prep_arr[ItemPrepEnum.fried] = scr_define_trait("Fried", ItemPrepEnum.fried);
	prep_arr[ItemPrepEnum.steamed] = scr_define_trait("Steamed", ItemPrepEnum.steamed);
	prep_arr[ItemPrepEnum.roasted] = scr_define_trait("Roasted", ItemPrepEnum.roasted);
	
	
	return {
		color: color_arr,
		temp: temp_arr,
		flavor: flavor_arr,
		prep: prep_arr
	};
}