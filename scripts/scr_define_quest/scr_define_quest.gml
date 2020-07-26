/// @desc Create a single quest definition
/// @param id ID of the quest
/// @param req 2D Array of requirements, array of [item, day/wk/month, #] OR A single location enum for arrival quests
/// @param cond Bool where true ANDs all req and false ORs all req
/// @param quests Array of quests rewarded by the quest
/// @param msgs Array of messages rewarded by the quest
/// @param comps Array of components rewarded by the quest
/// @param ings Array of ingredients rewarded by the quest
/// @param locs Array of locations rewarded by the quest
/// @param bonus Array of bonus rewarded by the quest


var quest = ds_map_create();

ds_map_add(quest, "id", argument0);
ds_map_add(quest, "req", argument1);
ds_map_add(quest, "cond", argument2);
ds_map_add(quest, "quests", argument3);
ds_map_add(quest, "msgs", argument4);
ds_map_add(quest, "comps", argument5);
ds_map_add(quest, "ings", argument6);
ds_map_add(quest, "locs", argument7);
ds_map_add(quest, "bonus", argument8);

return quest;