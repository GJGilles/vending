/// @description Insert description here
// You can write your code in this editor

var fl = obj_setup_filter_list;

fl.sel_tab = idx;

for (var i = 1; i < array_length(fl.radios); i++) {
	fl.radios[i].name = fl.traits[idx][i - 1].name;
}
