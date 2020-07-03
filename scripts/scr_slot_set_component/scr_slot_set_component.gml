var slot = argument0;
var comp = argument1;
var rot = argument2;


slot.component = comp;
slot.rotation = rot;


var tile_id = layer_tilemap_get_id(layer_get_id("collision"));
for (var i = -4; i <= 4; i += 8) {
	for (var j = -4; j <= 4; j += 8) {
		if (comp == -1) {
			tilemap_set_at_pixel(tile_id, 0, slot.x + i, slot.y + j);
		} else {
			tilemap_set_at_pixel(tile_id, 1, slot.x + i, slot.y + j);
		}
	}
}


if (comp == -1) {
	for (var i = 0; i < 4; i++) {
		var buff = slot.buffer[i];
		while(!ds_queue_empty(buff)) { ds_queue_dequeue(buff); }
	}
	
	wait = 0;
	result = -1;
}


var opposite = [2, 3, 0, 1];
for (var i = 0; i < 4; i++) {
	var idx = i + slot.rotation;
	if (idx > 3) { idx -= 4; }
	
	var prev_slot = slot.directions[idx];
	if (prev_slot != -1 && prev_slot.component != -1) {
		var prev_io = prev_slot.component[? "io"];
		var prev_idx = opposite[idx] - prev_slot.rotation;
		if (prev_idx < 0) { prev_idx += 4; }
			
		if (prev_io[prev_idx] != IOEnum.none) {
			if (comp == -1) {
				var offset = (prev_slot.sprite_width / 2);
				var x_pos = prev_slot.x + lengthdir_x(offset, 90 * opposite[idx]);
				var y_pos = prev_slot.y + lengthdir_y(offset, 90 * opposite[idx]);
				
				if (prev_slot.component[? "id"] == ComponentEnum.item_in) { y_pos = prev_slot.y - 24; }
				
				var size = prev_slot.component[? "size"];
				
				prev_slot.io[prev_idx] = instance_create_layer(x_pos, y_pos, "Components", obj_item_bubble);
				prev_slot.io[prev_idx].queue = prev_slot.buffer[prev_idx];
				prev_slot.io[prev_idx].size = size[prev_idx];
				prev_slot.io[prev_idx].io = prev_io[prev_idx];
			} else {
				instance_destroy(prev_slot.io[prev_idx]);
				prev_slot.io[prev_idx]  = -1;
			}
		}
	} else if (comp != -1) {
		var io = slot.component[? "io"];
		if (io[i] != IOEnum.none) {
			var offset = (slot.sprite_width / 2);
			var x_pos = slot.x + lengthdir_x(offset, 90 * idx);
			var y_pos = slot.y + lengthdir_y(offset, 90 * idx);
				
			var size = slot.component[? "size"];
			
			slot.io[i] = instance_create_layer(x_pos, y_pos, "Components", obj_item_bubble);
			slot.io[i].queue = slot.buffer[i];
			slot.io[i].size = size[i];
			slot.io[i].io = io[i];
		}
	}
	
	if (comp == -1 && slot.io[i] != -1) {
		instance_destroy(slot.io[i]);
		slot.io[i]  = -1;
	}
}

