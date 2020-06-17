/// @description Insert description here
// You can write your code in this editor

draw_self();

if (component != -1) {
	script_execute(component[? "draw"], x, y, rotation, 1);
	
	for (var i = 0; i < 4; i++) {
		if (!ds_queue_empty(buffer[i])) {
			var x_pos = x;
			var y_pos = y;
			var offset = (sprite_width / 2) - 8;
		
			var idx = i + rotation;
			if (idx > 3) {idx -= 4; }
		
			if (idx == 0) { x_pos += offset; }
			if (idx == 1) { y_pos -= offset; }
			if (idx == 2) { x_pos -= offset; }
			if (idx == 3) { y_pos += offset; }
		
			var item = ds_queue_head(buffer[i]);
			draw_sprite(item[? "sprite"], -1, x_pos, y_pos);
		}
	}
} else if (obj_game.mouse == id && obj_factory.selected_component != -1) {
	script_execute(obj_factory.selected_component[? "draw"], x, y, obj_factory.selected_rotation, 0.5);
}
