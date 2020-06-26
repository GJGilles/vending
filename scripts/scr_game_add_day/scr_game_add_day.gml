
day++;
if (day > 28) {
	month++;
	day = 1;
	if (month > 8) {
		year++;
		month = 1;
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
	var min_temp = temp[next_season, 0];
	var max_temp = temp[next_season, 1];
	
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
