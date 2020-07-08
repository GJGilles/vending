/// @description Insert description here
// You can write your code in this editor

mouse = -1;

money = 0;
max_mana = 100;

year = 0;
month = 0;
day = 0;

all_regions = scr_define_all_regions();
current_region = MapRegionEnum.chugoku;
current_location = 0;

all_components = scr_define_all_components();
all_items = scr_define_all_items();
all_recipes = scr_define_all_recipes();
all_quests = scr_define_all_quests();


current_components = array_create(0);
current_recipies = array_create(0);


popular = [irandom(4), irandom(4)];


var size = array_length_1d(all_items);
item_stats = ds_grid_create(size, 4); // Day/Week/Month/Year
ds_grid_set_region(item_stats, 0, 0, size - 1, 3, 0);


scr_define_all_fonts();
