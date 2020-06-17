/// @description Insert description here
// You can write your code in this editor

mouse = -1;

max_mana = 100;

all_components = scr_define_all_components();
all_items = scr_define_all_items();


current_components = array_create(0);


// test

var length = array_length_1d(all_components);
array_copy(current_components, 0, all_components, 0, length);

room_goto(rm_factory);
