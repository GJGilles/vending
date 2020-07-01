/// @description Insert description here
// You can write your code in this editor

event_inherited();

item = -1;

component = obj_game.all_components[ComponentEnum.item_in];
var comp_size = component[? "size"];
var comp_io = component[? "io"];

io[3] = instance_create_layer(x, y - 24, "Components", obj_item_bubble);
io[3].queue = buffer[3];
io[3].size = comp_size[3];
io[3].io = comp_io[3];
