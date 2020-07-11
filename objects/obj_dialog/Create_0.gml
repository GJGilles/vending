/// @description Insert description here
// You can write your code in this editor

event_inherited();

backdrop = instance_create_layer(0, 0, "Dialogs", obj_popup_background);
backdrop.depth = depth + 1;

pressed = -1;
buttons = [[-24, 8, spr_dialog_exit]];
result = -1;
