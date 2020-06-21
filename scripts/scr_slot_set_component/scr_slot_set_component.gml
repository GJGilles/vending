var comp = argument0;
var slot = argument1;


slot.component = comp;

var opposite = [2, 3, 0, 1];
for (var i = 0; i < 4; i++) {
	var idx = i + slot.rotation;
	if (idx > 3) { idx -= 4; }
	
	if (slot.directions[idx] != -1 && slot.directions[idx].component != -1) {
		var prev_slot = slot.directions[idx];
		var prev_io = prev_slot.component[? "io"];
		var prev_idx = opposite[idx] - prev_slot.rotation;
		if (prev_idx < 0) { prev_idx += 4; }
			
		if (prev_io[prev_idx] != IOEnum.none) {
			if (comp == -1) {
				var offset = (prev_slot.sprite_width / 2);
				var x_pos = prev_slot.x + lengthdir_x(offset, 90 * opposite[idx]);
				var y_pos = prev_slot.y + lengthdir_y(offset, 90 * opposite[idx]);
				
				prev_slot.io[prev_idx] = instance_create_layer(x_pos, y_pos, "Components", obj_item_bubble);
				prev_slot.io[prev_idx].queue = prev_slot.buffer[prev_idx];
				prev_slot.io[prev_idx].io = prev_io[prev_idx];
			} else {
				instance_destroy(prev_slot.io[prev_idx]);
				prev_slot.io[prev_idx]  = -1;
			}
		}
	} else if (comp != -1){
		var offset = (slot.sprite_width / 2);
		var x_pos = slot.x + lengthdir_x(offset, 90 * i);
		var y_pos = slot.y + lengthdir_y(offset, 90 * i);
		var io = slot.component[? "io"];
				
		prev_slot.io[idx] = instance_create_layer(x_pos, y_pos, "Components", obj_item_bubble);
		prev_slot.io[idx].queue = prev_slot.buffer[idx];
		prev_slot.io[idx].io = io[idx];
	}
	
	if (comp == -1) {
		instance_destroy(slot.io[idx]);
		slot.io[idx]  = -1;
	}
}

