/// @description Insert description here
// You can write your code in this editor

obj_setup_filter_list.filters[obj_setup_filter_list.sel_tab] = idx;

with obj_setup_recipe_list {
	scr_set_scroll_items(scr_create_recipe_list());
}
