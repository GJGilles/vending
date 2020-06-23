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
