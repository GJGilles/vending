/// @desc Create a single region definition
/// @param name Name of the region
/// @param id ID of the region
/// @param temp 2D Array containing (Spring, Summer, Autumn, Winter) rows and (min, max temp) columns 
/// @param percip Array containing the average percipitation for each season
/// @param locs Array containing all of the locations for the region

var region = ds_map_create();

ds_map_add(region, "name", argument0);
ds_map_add(region, "id", argument1);
ds_map_add(region, "temp", argument2);
ds_map_add(region, "percip", argument3);
ds_map_add(region, "locs", argument4);
ds_map_add(region, "weather", ds_queue_create());


// Test?
for (var i = 0; i < 7; i++) {
	ds_queue_enqueue(region[? "weather"], [-44, MapWeatherEnum.snow]);
}

return region;
