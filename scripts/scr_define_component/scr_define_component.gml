/// @desc Create a single component definition
/// @param name Name of the component
/// @param id ID of the component
/// @param time Processing time of the component
/// @param process Processing method of the component
/// @param draw Drawing method of the component
/// @param io A 4 member array of the IO of the component
/// @param size A 4 member array of the buffer sizes of the component

var component = ds_map_create();

ds_map_add(component, "name", argument0);
ds_map_add(component, "id", argument1);
ds_map_add(component, "time", argument2);
ds_map_add(component, "process", argument3);
ds_map_add(component, "draw", argument4);
ds_map_add(component, "io", argument5);
ds_map_add(component, "size", argument6);

return component;
