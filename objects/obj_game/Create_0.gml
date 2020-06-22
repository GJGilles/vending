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
	var comp_id = comp[? "id"];
	if (comp_id == ComponentEnum.item_in) { continue; }
	if (comp_id == ComponentEnum.item_out) { continue; }
	
	current_components[idx] = comp;
	idx++;
}

room_goto(rm_factory);
