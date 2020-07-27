/// @description Insert description here
// You can write your code in this editor

if (io == IOEnum.output) {
	if (!ds_queue_empty(queue)) {
		var item = ds_queue_head(queue);
		var k = 2;
		var diff = height * (1 - (1 / power(2, 2 * k)) * power((4 * (animo_frame / animo_len) - 2), 2 * k));
		draw_sprite(spr_item_bubble, -1, x, y - diff);
		scr_item_draw(item, x, y - diff);
	}
}

if (io == IOEnum.input) {
	draw_sprite(spr_item_bubble, -1, x, y);
	if (!ds_queue_empty(queue)) {
		var item = ds_queue_head(queue);
		scr_item_draw(item, x, y);
	}
}


animo_frame++;
if (animo_frame == animo_len) {
	animo_frame = 0;
}

