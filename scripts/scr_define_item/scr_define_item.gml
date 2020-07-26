/// @desc Create a single item definition
/// @param name Name of the item
/// @param id ID of the item
/// @param cost Cost of the item
/// @param spr Sprite of the item
/// @param traits Array of trait strings of the item
/// @param description desc String describing the food

var traits = argument4;

var item = ds_map_create();

ds_map_add(item, "name", argument0);
ds_map_add(item, "id", argument1);
ds_map_add(item, "cost", argument2);
ds_map_add(item, "sprite", argument3);
ds_map_add(item, "color", traits[0]);
ds_map_add(item, "temp", traits[1]);
ds_map_add(item, "flavor", traits[2]);
ds_map_add(item, "prep", traits[3]);
ds_map_add(item, "description", argument5);
ds_map_add(item, "special", array_create(0));

return item;
