
enum ComponentEnum {
	pipe = 0,
	steeper = 1,
	item_in = 2,
	elbow = 3,
	soup_pot = 4,
	tea_roaster = 5,
	item_out = 6
}

enum IOEnum {
	none = 0,
	input = 1, 
	output = 2
}


var component_array = array_create(0);
component_array[ComponentEnum.pipe] = scr_define_component("Pipe", ComponentEnum.pipe, 300, scr_process_pipe, scr_draw_pipe, [IOEnum.input, IOEnum.none, IOEnum.output, IOEnum.none], [4, 0, 4, 0]);
component_array[ComponentEnum.steeper] = scr_define_component("Steeper", ComponentEnum.steeper, 300, scr_process_steeper, scr_draw_steeper, [IOEnum.input, IOEnum.none, IOEnum.input, IOEnum.output], [4, 0, 4, 4]);
component_array[ComponentEnum.item_in] = scr_define_component("Input", ComponentEnum.item_in, 300, scr_process_item_in, scr_draw_item_in, [IOEnum.none, IOEnum.none, IOEnum.none, IOEnum.output], [0, 0, 0, 10]);
component_array[ComponentEnum.elbow] = scr_define_component("Elbow", ComponentEnum.elbow, 300, scr_process_elbow, scr_draw_elbow, [IOEnum.output, IOEnum.input, IOEnum.none, IOEnum.none], [4, 4, 0, 0]);
component_array[ComponentEnum.soup_pot] = scr_define_component("Soup Pot", ComponentEnum.soup_pot, 300, scr_process_soup_pot, scr_draw_soup_pot, [IOEnum.input, IOEnum.input, IOEnum.input, IOEnum.output], [4, 4, 4, 4]);
component_array[ComponentEnum.tea_roaster] = scr_define_component("Tea Roaster", ComponentEnum.tea_roaster, 300, scr_process_tea_roaster, scr_draw_tea_roaster, [IOEnum.input, IOEnum.none, IOEnum.none, IOEnum.output], [4, 0, 0, 4]);
component_array[ComponentEnum.item_out] = scr_define_component("Output", ComponentEnum.item_out, 300, scr_process_item_out, scr_draw_item_out, [IOEnum.none, IOEnum.none, IOEnum.input, IOEnum.none], [0, 0, 10, 0]);

return component_array;
