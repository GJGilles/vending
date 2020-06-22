/// @description Insert description here
// You can write your code in this editor

mouse = -1;

max_mana = 100;

all_components = scr_define_all_components();
all_items = scr_define_all_items();


current_components = array_create(0);


// test

var length = array_length_1d(all_components);
var idx = 0;
for (var i = 0; i < length; i++) {
	var comp = all_components[i];
	if (comp[? "id"] == ComponentEnum.item_in) { continue; }
	
	current_components[idx] = all_components[i];
	idx++;
}

room_goto(rm_factory);
