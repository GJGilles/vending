/// @description Insert description here
// You can write your code in this editor

draw_sprite_ext(sprite_index, -1, x, y, 1, 1, 90 * rotation, c_white, 1);

for (var i = 0; i < 4; i++) {
	if (!ds_queue_empty(buffer[i])) {
		var x_pos = x;
		var y_pos = y;
		var offset = (sprite_width / 2) - 8;
		
		var idx = i - rotation;
		if (idx < 0) {idx += 4; }
		
		if (idx == 0) { x_pos += offset; }
		if (idx == 1) { y_pos += offset; }
		if (idx == 2) { x_pos -= offset; }
		if (idx == 3) { y_pos -= offset; }
		
		draw_sprite(ds_queue_head(buffer[i]).sprite_index, -1, x_pos, y_pos);
	}
}
