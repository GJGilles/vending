function scr_vend_customer(argument0, argument1, argument2) {
	var items = argument0;
	var stop_chance = argument1; // 0 - 20
	var buy_chance = argument2; // ~20 ?


	var roll_flavor = irandom(19);
	var roll_prep = irandom(19);

	var wanted_flavor = roll_flavor < 15 ? floor(roll_flavor / 3) : obj_game.popular[0];
	var wanted_prep = roll_prep < 15 ? floor(roll_prep / 3) : obj_game.popular[1];

	var region = obj_game.all_regions[obj_game.current_region];
	var weather = ds_queue_head(region[? "weather"]);

	var best_temp = ItemTempEnum.room_temp;
	var best_color = weather[1];

	if (weather[0] < 0)		  { best_temp = ItemTempEnum.hot; }
	else if (weather[0] < 20) { best_temp = ItemTempEnum.warm; }
	else if (weather[0] < 23) { best_temp = ItemTempEnum.room_temp; }
	else if (weather[0] < 26) { best_temp = ItemTempEnum.cool; }
	else 					  { best_temp = ItemTempEnum.cold; }


	var colors = array_create(5, 0);
	var preps = array_create(5, 0);

	for (var i = 0; i < array_length_1d(items); i++) {
		var item = items[i];
		if (item == -1) { continue; }
	
		var color = item[? "color"];
		var prep = item[? "prep"];
	
		if (colors[color] == 0) {
			colors[color] = 1;
			stop_chance += (color == best_color ? 20 : 5);
		}
		if (preps[prep] == 0) {
			preps[prep] = 1;
			stop_chance += (prep == wanted_prep ? 20 : 5);
		}
	}

	if (irandom_range(1, 100) > stop_chance) { return []; } // Never stops at vending machine


	var buy_arr = [];
	var idx = 0
	for (var i = 0; i < array_length_1d(items); i++) {
		var item = items[i];
		if (item == -1) { continue; }
	
		var temp = item[? "temp"];
		var flavor = item[? "flavor"];
	
		var rand = irandom_range(1, 100);
		if (temp == best_temp && flavor == wanted_flavor) {
			buy_arr[idx] = i;
			idx++;
		} else if ((temp == best_temp || flavor == wanted_flavor) && rand <= buy_chance){
			buy_arr[idx] = i;
			idx++;
		} else if (rand < buy_chance * buy_chance ) {
			buy_arr[idx] = i;
			idx++;
		}
	}

	return buy_arr;



}
