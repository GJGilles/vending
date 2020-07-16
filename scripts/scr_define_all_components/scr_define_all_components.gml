
enum ComponentEnum {
	pipe = 0,
	steeper = 1,
	item_in = 2,
	elbow_ccw = 3,
	elbow_cw = 4,
	soup_pot = 5,
	tea_roaster = 6,
	item_out = 7,
	mochi_maker = 8
}

enum IOEnum {
	none = 0,
	input = 1, 
	output = 2,
	any = 3
}


var io_4_way = [];
var io_3_way_1 = [IOEnum.input, IOEnum.none, IOEnum.input, IOEnum.output];
var io_3_way_2 = [IOEnum.input, IOEnum.input, IOEnum.none, IOEnum.output];
var io_2_way_1 = [IOEnum.input, IOEnum.none, IOEnum.output, IOEnum.none];
var io_2_way_2 = [IOEnum.output, IOEnum.input, IOEnum.none, IOEnum.none];
var io_2_way_3 = [IOEnum.input, IOEnum.output, IOEnum.none, IOEnum.none];


var component_array = array_create(0);
component_array[ComponentEnum.pipe] = scr_define_component("Pipe", ComponentEnum.pipe, 30, -1, spr_pipe, io_2_way_1, 4);
component_array[ComponentEnum.steeper] = scr_define_component("Steeper", ComponentEnum.steeper, 30, [0, 2, 3], spr_steeper, io_3_way_1, 4);
component_array[ComponentEnum.item_in] = scr_define_component("Input", ComponentEnum.item_in, 30, -1, spr_item_in, [IOEnum.none, IOEnum.none, IOEnum.none, IOEnum.output], 10);
component_array[ComponentEnum.elbow_ccw] = scr_define_component("Elbow", ComponentEnum.elbow_ccw, 30, -1, spr_elbow, io_2_way_2, 4);
component_array[ComponentEnum.elbow_cw] = scr_define_component("Elbow", ComponentEnum.elbow_cw, 30, -1, spr_elbow, io_2_way_3, 4);
component_array[ComponentEnum.soup_pot] = scr_define_component("Soup Pot", ComponentEnum.soup_pot, 30, [], spr_soup_pot, io_4_way, 4);
component_array[ComponentEnum.tea_roaster] = scr_define_component("Tea Roaster", ComponentEnum.tea_roaster, 30, [1], spr_tea_roaster, io_2_way_2, 4);
component_array[ComponentEnum.item_out] = scr_define_component("Output", ComponentEnum.item_out, 1, -1, spr_item_out, [IOEnum.input, IOEnum.none, IOEnum.none, IOEnum.output], 4);
component_array[ComponentEnum.mochi_maker] = scr_define_component("Mochi Maker", ComponentEnum.mochi_maker, 30, [], spr_mochi_maker, io_2_way_3, 4);

return component_array;
