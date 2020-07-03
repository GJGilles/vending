/// @description Insert description here
// You can write your code in this editor

event_inherited();

item = -1;

component = obj_game.all_components[ComponentEnum.item_out];
var comp_size = component[? "size"];
var comp_io = component[? "io"];

io[2] = instance_create_layer(x, y, "Components", obj_item_bubble);
io[2].queue = buffer[2];
io[2].size = comp_size[2];
io[2].io = comp_io[2];


var tile_id = layer_tilemap_get_id(layer_get_id("collision"));
for (var i = -4; i <= 4; i += 8) {
	for (var j = -4; j <= 4; j += 8) {
		tilemap_set_at_pixel(tile_id, 1, x + i, y + j);
	}
}
