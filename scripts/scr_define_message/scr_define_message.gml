/// @desc Create a single message definition
/// @param id ID of the message
/// @param player Boolean true if it is the players message, false otherwise
/// @param text String content of the message
function scr_define_message(argument0, argument1, argument2) {


	var message = ds_map_create();

	ds_map_add(message, "id", argument0);
	ds_map_add(message, "player", argument1);
	ds_map_add(message, "text", argument2);

	return message;


}
