/// @description Insert description here
// You can write your code in this editor

if (obj_setup_recipe_list.sel_tab == component) {
	// TODO: draw selected background
} else {
	draw_self();
}

if (component == -1) { 
	write_text("All", x, y, FontEnum.silkscreen);
} else if (component == -2) { // Etc
	write_text("ETC", x, y, FontEnum.silkscreen);
} else {
	write_text(component[? "name"], x, y, FontEnum.silkscreen);
}

