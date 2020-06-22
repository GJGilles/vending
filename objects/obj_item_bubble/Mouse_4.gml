/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id && distance_to_object(obj_player) < 50) { 
	if (instance_exists(obj_hand_inventory)) {
		var inv = obj_hand_inventory;
		if (io == IOEnum.output) {
			var item = ds_queue_head(queue);
			for (var i = 0; i < inv.max_size; i++) {
				if (inv.items[i] == item && inv.numbers[i] < inv.stack_size) {
					ds_queue_dequeue(queue);
					inv.numbers[i]++;
					return;
				}
			}
			
			if (inv.items[inv.selected] == -1) {
				inv.items[inv.selected] = ds_queue_dequeue(queue);
				inv.numbers[inv.selected] = 1;
			} else if (inv.items[inv.selected] == item && inv.numbers[inv.selected] < inv.stack_size) {
				ds_queue_dequeue(queue);
				inv.numbers[inv.selected]++;
			} else {
				for (var i = 0; i < inv.max_size; i++) {
					if (inv.items[i] == -1) {
						inv.items[i] = ds_queue_dequeue(queue);
						inv.numbers[i] = 1;
						break;
					}
				}
			}
		} else if (io == IOEnum.input) {
			if (inv.items[inv.selected] != -1 && ds_queue_size(queue) < size) {
				ds_queue_enqueue(queue, inv.items[inv.selected]);
				inv.numbers[inv.selected]--;
				if (inv.numbers[inv.selected] <= 0) {
					inv.items[inv.selected] = -1;
				}
			}
		}
	}
}
