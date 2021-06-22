// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information


function scr_update_scroll_items() {
	var y_pos = y - y_off;
	
	for (var i = 0; i < array_length(items); i++) {
		var h = items[i].sprite_height;
		
		items[i].x = x;
		items[i].y = min(max(y, y_pos), y + sprite_height);
		items[i].top = min(max(0, (y - y_pos)), h);
		items[i].bot = min(max(0, (y_pos + h - y - sprite_height)), h);
		items[i].right = min(max(0, (items[i].sprite_width - sprite_width)), sprite_width);
		
		y_pos += items[i].sprite_height;
	}
}

function scr_set_scroll_items(new_items) {
	items = new_items;
	y_off = 0;
	y_size = 0;
	for (var i = 0; i < array_length(items); i++) {
		y_size += items[i].sprite_height;
	}
	
	scr_update_scroll_items();
}
