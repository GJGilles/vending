
enum ComponentEnum {
	pipe = 0,
	steeper = 1,
	water_in = 2,
	g_tea_leaves_in = 3,
	elbow = 4
}

enum IOEnum {
	none = 0,
	input = 1, 
	output = 2
}


var component_array = array_create(0);
component_array[ComponentEnum.pipe] = scr_define_component("Pipe", ComponentEnum.pipe, 300, scr_process_pipe, scr_draw_pipe, [IOEnum.input, IOEnum.none, IOEnum.output, IOEnum.none], [4, 0, 4, 0]);
component_array[ComponentEnum.steeper] = scr_define_component("Steeper", ComponentEnum.steeper, 300, scr_process_steeper, scr_draw_steeper, [IOEnum.input, IOEnum.none, IOEnum.input, IOEnum.output], [4, 0, 4, 4]);
component_array[ComponentEnum.water_in] = scr_define_component("Water In", ComponentEnum.water_in, 300, scr_process_water_in, scr_draw_item_in, [IOEnum.none, IOEnum.none, IOEnum.none, IOEnum.output], [0, 0, 0, 10]);
component_array[ComponentEnum.g_tea_leaves_in] = scr_define_component("Green Tea Leaves In", ComponentEnum.g_tea_leaves_in, 300, scr_process_g_tea_leaves_in, scr_draw_item_in, [IOEnum.none, IOEnum.none, IOEnum.none, IOEnum.output], [0, 0, 0, 10]);
component_array[ComponentEnum.elbow] = scr_define_component("Elbow", ComponentEnum.elbow, 300, scr_process_elbow, scr_draw_elbow, [IOEnum.output, IOEnum.input, IOEnum.none, IOEnum.none], [4, 4, 0, 0]);

return component_array;
