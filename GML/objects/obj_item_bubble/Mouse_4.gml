/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && distance_to_object(obj_player) < 50) { 
	if (io == IOEnum.output) {
		var item = ds_queue_head(queue);
		if (!ds_queue_empty(queue) && scr_inventory_add(item)) {
			ds_queue_dequeue(queue);
			held_frame = 0;
		}
	} else if (io == IOEnum.input) {
		var inv = obj_hand_inventory;
		if (instance_exists(inv) && inv.items[inv.selected] != -1 && ds_queue_size(queue) < size) {
			ds_queue_enqueue(queue, inv.items[inv.selected]);
			inv.numbers[inv.selected]--;
			if (inv.numbers[inv.selected] <= 0) {
				inv.items[inv.selected] = -1;
			}
		}
	}
}
