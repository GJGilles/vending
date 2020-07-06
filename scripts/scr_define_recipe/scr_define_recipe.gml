/// @desc Create a single recipe definition
/// @param result Result of the recipe
/// @param comp Component used to create the recipe
/// @param ing Array of ingredients consumed in the recipe
/// @param craft Array of which ingredients are craftable

var recipe = ds_map_create();

ds_map_add(recipe, "id", argument0);
ds_map_add(recipe, "result", argument1);
ds_map_add(recipe, "comp", argument2);
ds_map_add(recipe, "ing", argument3);
ds_map_add(recipe, "craft", argument4);

return recipe;
