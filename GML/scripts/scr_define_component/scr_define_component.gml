/// @desc Create a single component definition
/// @param name Name of the component
/// @param id ID of the component
/// @param time Processing time of the component
/// @param recipes Array of recipes that use the component
/// @param sprite Sprite used to draw the component
/// @param io A 4 member array of the IO of the component
/// @param size Buffer size used by all io for the component
function scr_define_component(argument0, argument1, argument2, argument3, argument4, argument5, argument6) {

	var component = ds_map_create();

	ds_map_add(component, "name", argument0);
	ds_map_add(component, "id", argument1);
	ds_map_add(component, "time", argument2);
	ds_map_add(component, "recipes", argument3);
	ds_map_add(component, "sprite", argument4);
	ds_map_add(component, "io", argument5);
	ds_map_add(component, "size", argument6);

	return component;



}
