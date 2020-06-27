/// @desc Create a single location definition
/// @param name Name of the location
/// @param id ID of the location
/// @param coords Array containing the x, y coords of the location
/// @param layout Array containing the layouts for different levels of the location room

var region = ds_map_create();

ds_map_add(region, "name", argument0);
ds_map_add(region, "id", argument1);
ds_map_add(region, "coords", argument2);
ds_map_add(region, "layouts", argument3);

return region;
