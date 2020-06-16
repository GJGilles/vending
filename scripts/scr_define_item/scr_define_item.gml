/// @desc Create a single item definition
/// @param name Name of the item
/// @param id ID of the item
/// @param spr Sprite of the item

var item = ds_map_create();

ds_map_add(item, "name", argument0);
ds_map_add(item, "id", argument1);
ds_map_add(item, "sprite", argument2);

return item;
