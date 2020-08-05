
enum ComponentEnum {
	item_in,
	item_out,
	
	pipe,
	elbow_ccw,
	elbow_cw,
	
	blender,
	mochi_maker,
	noodle_puller,
	tea_roaster,
	wrapper_press,
	
	big_oven,
	deep_fryer,
	fermenter,
	freezer,
	fry_top,
	oven,
	salad_maker,
	sandwich_maker,
	soup_pot,
	sushi_maker,
	steeper,
}

enum IOEnum {
	none = 0,
	input = 1, 
	output = 2,
	any = 3
}


var io_4_way = [IOEnum.input, IOEnum.input, IOEnum.input, IOEnum.output];
var io_3_way_1 = [IOEnum.input, IOEnum.none, IOEnum.input, IOEnum.output];
var io_3_way_2 = [IOEnum.input, IOEnum.input, IOEnum.none, IOEnum.output];
var io_2_way_1 = [IOEnum.input, IOEnum.none, IOEnum.output, IOEnum.none];
var io_2_way_2 = [IOEnum.output, IOEnum.input, IOEnum.none, IOEnum.none];
var io_2_way_3 = [IOEnum.input, IOEnum.output, IOEnum.none, IOEnum.none];


var component_array = array_create(0);

component_array[ComponentEnum.item_in] = scr_define_component("Input", ComponentEnum.item_in, 30, -1, spr_item_in, [IOEnum.none, IOEnum.none, IOEnum.none, IOEnum.output], 10);
component_array[ComponentEnum.item_out] = scr_define_component("Output", ComponentEnum.item_out, 1, -1, spr_item_out, [IOEnum.input, IOEnum.none, IOEnum.none, IOEnum.output], 4);

component_array[ComponentEnum.pipe] = scr_define_component("Pipe", ComponentEnum.pipe, 30, -1, spr_pipe, io_2_way_1, 4);
component_array[ComponentEnum.elbow_ccw] = scr_define_component("Elbow", ComponentEnum.elbow_ccw, 30, -1, spr_elbow, io_2_way_2, 4);
component_array[ComponentEnum.elbow_cw] = scr_define_component("Elbow", ComponentEnum.elbow_cw, 30, -1, spr_elbow, io_2_way_3, 4);

component_array[ComponentEnum.blender] = scr_define_component("Blender", ComponentEnum.blender, 30, [RecipeEnum.dough, RecipeEnum.batter], spr_blender, io_4_way, 4);
component_array[ComponentEnum.mochi_maker] = scr_define_component("Mochi Maker", ComponentEnum.mochi_maker, 30, [RecipeEnum.mochi], spr_mochi_maker, io_2_way_3, 4);
component_array[ComponentEnum.noodle_puller] = scr_define_component("Noodle Puller", ComponentEnum.noodle_puller, 30, [], spr_noodle_puller, io_3_way_2, 4);
component_array[ComponentEnum.tea_roaster] = scr_define_component("Tea Roaster", ComponentEnum.tea_roaster, 30, [RecipeEnum.b_tea_leaves, RecipeEnum.genmai], spr_tea_roaster, io_2_way_2, 4);
component_array[ComponentEnum.wrapper_press] = scr_define_component("Wrapper Press", ComponentEnum.wrapper_press, 30, [], spr_wrapper_press, io_2_way_1, 4);

component_array[ComponentEnum.big_oven] = scr_define_component("Big Oven", ComponentEnum.big_oven, 30, [], spr_big_oven, io_4_way, 4);
component_array[ComponentEnum.deep_fryer] = scr_define_component("Deep Fryer", ComponentEnum.deep_fryer, 30, [], spr_deep_fryer, io_4_way, 4);
component_array[ComponentEnum.fermenter] = scr_define_component("Fermenter", ComponentEnum.fermenter, 30, [RecipeEnum.amazake, RecipeEnum.yoink], spr_fermenter, io_3_way_2, 4);
component_array[ComponentEnum.freezer] = scr_define_component("Freezer", ComponentEnum.freezer, 30, [RecipeEnum.ice_cream], spr_freezer, io_3_way_1, 4);
component_array[ComponentEnum.fry_top] = scr_define_component("Fry Top", ComponentEnum.fry_top, 30, [], spr_fry_top, io_4_way, 4);
component_array[ComponentEnum.oven] = scr_define_component("Oven", ComponentEnum.oven, 30, [], spr_oven, io_3_way_1, 4);
component_array[ComponentEnum.salad_maker] = scr_define_component("Salad Maker", ComponentEnum.salad_maker, 30, [], spr_salad_maker, io_4_way, 4);
component_array[ComponentEnum.sandwich_maker] = scr_define_component("Sandwich Maker", ComponentEnum.sandwich_maker, 30, [], spr_sandwich_maker, io_3_way_1, 4);
component_array[ComponentEnum.soup_pot] = scr_define_component("Soup Pot", ComponentEnum.soup_pot, 30, [], spr_soup_pot, io_4_way, 4);
component_array[ComponentEnum.sushi_maker] = scr_define_component("Sushi Maker", ComponentEnum.sushi_maker, 30, [], spr_sushi_maker, io_4_way, 4);
component_array[ComponentEnum.steeper] = scr_define_component("Steeper", ComponentEnum.steeper, 30, [RecipeEnum.g_tea, RecipeEnum.b_tea, RecipeEnum.royal_milk_tea, RecipeEnum.genmaicha], spr_steeper, io_3_way_1, 4);

return component_array;
