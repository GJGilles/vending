/// @desc Create a single category definition
/// @param name Name of the category
/// @param id ID of the category
/// @param recipes Array of recipes in the category


var category = ds_map_create();

ds_map_add(category, "name", argument0);
ds_map_add(category, "id", argument1);
ds_map_add(category, "recipes", argument2);

return category;