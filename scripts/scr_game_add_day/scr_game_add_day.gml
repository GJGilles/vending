
day++;
if (day >= 28) {
	month++;
	day = 0;
	if (month >= 8) {
		year++;
		month = 0;
	}
}

for (var i = 0; i < array_length_1d(all_regions); i++) {
	var region = all_regions[i];
	var weather = region[? "weather"];
	var temp = region[? "temp"];
	var percip = region[? "percip"];
	
	ds_queue_dequeue(weather);
	
	var next_month = month;
	if (day + 6 > 28) { next_month++; }
	if (next_month > 8) { next_month = 0 }
	var next_season = floor(next_month / 2);
	
	var last_weather = ds_queue_tail(weather);
	var season_temps = temp[next_season];
	var min_temp = season_temps[0];
	var max_temp = season_temps[1];
	
	var new_temp = min(max(irandom_range(last_weather[0] - 5, last_weather[0] + 5), min_temp), max_temp);
	var new_weather = MapWeatherEnum.clear;
	
	var is_chance = (irandom_range(1, 100) <= percip[next_season] * 100);
	var was_chance = (last_weather[1] < MapWeatherEnum.clear);
	
	if (is_chance && was_chance) {
		new_weather = new_temp <= 0 ? MapWeatherEnum.snow : MapWeatherEnum.rain;
	} else if (is_chance) {
		new_weather = MapWeatherEnum.overcast;
	} else if (new_temp > 26) {
		new_weather = MapWeatherEnum.heat_wave;
	} else {
		new_weather = MapWeatherEnum.clear;
	}
	
	ds_queue_enqueue(weather, [new_temp, new_weather]);
}


var roll_flavor = irandom(19);
var roll_prep = irandom(19);

popular[0] = roll_flavor < 15 ? floor(roll_flavor / 3) : popular[0];
popular[1] = roll_prep < 15 ? floor(roll_prep / 3) : popular[1];


for (var i = 0; i < array_length_1d(current_quests); i++) {
	var quest = current_quests[i];
	
	var done = true;
	var req = quest[? "req"];
	var cond = quest[? "cond"];
	for (var j = 0; j < array_length_1d(req); j++) {
		var r = req[j];
		var res = item_stats[# r[0], r[1]] >= r[2];
		if (cond) {
			done = done && res;
		} else if (res) {
			done = true;
			break;
		} else {
			done = false;
		}
	}
	
	if (done) {
		var quests = quest[? "quests"];
		//var msgs = quest[? "msgs"];
		var comps = quest[? "comps"];
		var ings = quest[? "ings"];
		//var locs = quest[? "locs"];
		//var bonus = quest[? "bonus"];
		
		for (var j = 0; j < array_length_1d(quests); j++) {
			current_quests[array_length_1d(current_quests)] = all_quests[quests[j]];
		}
		
		for (var j = 0; j < array_length_1d(comps); j++) {
			current_components[array_length_1d(current_components)] = all_components[comps[j]];
		}
		
		for (var j = 0; j < array_length_1d(ings); j++) {
			current_ingredients[array_length_1d(current_ingredients)] = all_items[ings[j]];
		}
		
		// splice
		var temp = [];
		array_copy(temp, 0, current_quests, 0, i);
		for (var j = i; j < array_length_1d(current_quests) - 1; j++) {
			temp[j] = current_quests[j + 1];
		}
		current_quests = temp;
		i--;
	}
}


ds_grid_set_region(item_stats, 0, 0, ds_grid_width(item_stats) - 1, 0, 0);
if (day % 7 == 0) {
	ds_grid_set_region(item_stats, 0, 1, ds_grid_width(item_stats) - 1, 1, 0);
}
if (day == 0) {
	ds_grid_set_region(item_stats, 0, 2, ds_grid_width(item_stats) - 1, 2, 0);
}


scr_set_item_specials();
