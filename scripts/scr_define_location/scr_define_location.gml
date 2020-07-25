/// @desc Create a single location definition
/// @param name Name of the location
/// @param id ID of the location
/// @param coords Array containing the x, y coords of the location
/// @param region An enum value representing the region to which the location belongs
/// @param layout Array containing the layouts for different levels of the location room

var location = ds_map_create();

ds_map_add(location, "name", argument0);
ds_map_add(location, "id", argument1);
ds_map_add(location, "coords", argument2);
ds_map_add(location, "region", argument3);
ds_map_add(location, "layouts", argument4);

return location;
