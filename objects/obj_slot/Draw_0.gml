/// @description Insert description here
// You can write your code in this editor

draw_self();

if (component != -1) {
	for (var i = 0; i < 4; i++) {
		if (!ds_queue_empty(buffer[i])) {
			var x_pos = x;
			var y_pos = y;
			var offset = (sprite_width / 2) - 8;
		
			var idx = i + component.rotation;
			if (idx > 3) {idx -= 4; }
		
			if (idx == 0) { x_pos += offset; }
			if (idx == 1) { y_pos -= offset; }
			if (idx == 2) { x_pos -= offset; }
			if (idx == 3) { y_pos += offset; }
		
			draw_sprite(ds_queue_head(buffer[i]).sprite_index, -1, x_pos, y_pos);
		}
	}
}
