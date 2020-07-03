/// @description Insert description here
// You can write your code in this editor

event_inherited();

var region = obj_game.all_regions[obj_game.current_region];
var weather = ds_queue_head(region[? "weather"]);
var locs = region[? "locs"];
var location = locs[obj_game.current_location];

var name = location[? "name"];
var temp = weather[0];
var percip = weather[1];

var spr = spr_weather_sunny;
switch (percip) {
	case MapWeatherEnum.snow:
		spr = spr_weather_snowy;
		break;
	case MapWeatherEnum.rain:
		spr = spr_weather_rainy;
		break;
	case MapWeatherEnum.overcast:
		spr = spr_weather_cloudy;
		break;
	case MapWeatherEnum.clear:
		spr = spr_weather_sunny;
		break;
	case MapWeatherEnum.heat_wave:
		spr = spr_weather_hotty;
		break;
}

draw_self();
write_text("Kagoshima", x + 4, y + 2, FontEnum.silkscreen_2w);
draw_sprite(spr, floor(animo_frame / (animo_len / 4)), x + 1, y + 16);
write_text(string(temp) + "c", bbox_right - 40, y + 30, FontEnum.temp);

draw_sprite(spr_vending_border, -1, x, y);
