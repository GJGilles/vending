/// @description Insert description here
// You can write your code in this editor

mouse = -1;

money = 0;
max_mana = 100;

year = 1;
month = 1;
day = 0;

all_regions = scr_define_all_regions();
current_region = MapRegionEnum.chugoku;
current_location = 0;

all_components = scr_define_all_components();
all_items = scr_define_all_items();
all_recipes = scr_define_all_recipes();


current_components = array_create(0);
current_recipies = array_create(0);


popular = [irandom(4), irandom(4)];

scr_define_all_fonts();
