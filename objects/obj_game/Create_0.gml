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


current_components = array_create(0);
current_recipies = array_create(0);


// test

var length = array_length_1d(all_components);
var idx = 0;
for (var i = 0; i < length; i++) {
	var comp = all_components[i];
	var comp_id = comp[? "id"];
	if (comp_id == ComponentEnum.item_in) { continue; }
	if (comp_id == ComponentEnum.item_out) { continue; }
	
	current_components[idx] = comp;
	idx++;
}

current_recipies[0] = all_items[ItemEnum.g_tea];
current_recipies[1] = all_items[ItemEnum.b_tea];
current_recipies[2] = all_items[ItemEnum.royal_milk_tea];

//room_goto(rm_factory);
room_goto(rm_setup);