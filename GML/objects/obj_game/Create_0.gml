/// @description Insert description here
// You can write your code in this editor

mouse = -1;

money = 0;
max_mana = 100;

year = 0;
month = 0;
day = 0;


all_regions = scr_define_all_regions();
all_locations = scr_define_all_locations();
all_components = scr_define_all_components();
all_traits = scr_define_all_traits();
all_items = scr_define_all_items();
all_special = scr_define_all_special();
all_recipes = scr_define_all_recipes();
all_messages = scr_define_all_messages();
all_quests = scr_define_all_quests();
all_categories = scr_define_all_categories();


current_region = MapRegionEnum.chugoku;
current_locations = [MapLocationEnum.hiroshima, MapLocationEnum.kyoto];
current_location = MapLocationEnum.hiroshima;
current_components = all_components; //[all_components[ComponentEnum.steeper]];
current_ingredients = all_items; //[all_items[ItemEnum.g_tea_leaves], all_items[ItemEnum.water]];
// current_recipies = array_create(0);
current_quests = [all_quests[0]];


popular = [irandom(4), irandom(4)];


var size = array_length_1d(all_items);
item_stats = ds_grid_create(size, 4); // Day/Week/Month/Year
ds_grid_set_region(item_stats, 0, 0, size - 1, 3, 0);


scr_define_all_fonts();
