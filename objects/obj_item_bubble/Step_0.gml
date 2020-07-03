/// @description Insert description here
// You can write your code in this editor

if (io == IOEnum.input || (io == IOEnum.output && !ds_queue_empty(queue))) {
	event_inherited();
} else if (obj_game.mouse == id) {
	obj_game.mouse = -1;
}

if (held_frame >= 0 && mouse_check_button(mb_left)) {
	if (held_frame == held_len) {
		for (var i = 0; i < 8; i++) {
			event_perform(ev_mouse, ev_left_press);
		}
		held_frame = 0;
	} else {
		held_frame++;
	}
} else {
	held_frame = -1;
}
