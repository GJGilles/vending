/// @description Insert description here
// You can write your code in this editor

obj_setup_recipe_list.sel_tab = category;

instance_destroy(obj_setup_recipe_item);
with obj_setup_recipe_list { scr_create_recipe_list(); }
