/// @description Insert description here
// You can write your code in this editor

components = array_create(0);
amounts = array_create(0);

// test

components[0] = instance_create_layer(x, y, "GUI", obj_pipe);
amounts[0] = 99;

components[1] = instance_create_layer(x, y, "GUI", obj_steeper);
amounts[1] = 2;

