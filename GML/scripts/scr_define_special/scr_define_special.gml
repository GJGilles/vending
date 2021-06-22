/// @desc Create a single item specialization definition
/// @param pre Prefix of the special
/// @param id ID of the special
/// @param region Enum representing the region of the special
/// @param months Array of booleans specifying the availabilty during each month
/// @param multi Number represnting the cost multiplier of the special
function scr_define_special(argument0, argument1, argument2, argument3, argument4) {

	var special = ds_map_create();

	ds_map_add(special, "pre", argument0);
	ds_map_add(special, "id", argument1);
	ds_map_add(special, "region", argument2);
	ds_map_add(special, "months", argument3);
	ds_map_add(special, "multi", argument4);

	return special;



}
