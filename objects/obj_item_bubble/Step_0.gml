/// @description Insert description here
// You can write your code in this editor
if (io == IOEnum.input || (io == IOEnum.output && !ds_queue_empty(queue))) {
	event_inherited();
} else if (obj_game.mouse == id) {
	obj_game.mouse = -1;
}
