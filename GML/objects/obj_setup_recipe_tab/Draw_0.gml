/// @description Insert description here
// You can write your code in this editor

if (obj_setup_recipe_list.sel_tab == category) {
	image_index = 1;
} else {
	image_index = 0;
}

draw_self();
write_text(category[? "name"], x + 2, y + 2, FontEnum.silkscreen);
