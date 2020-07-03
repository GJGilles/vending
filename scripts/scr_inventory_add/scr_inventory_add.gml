var item = argument0;

if (instance_exists(obj_hand_inventory)) {
	var inv = obj_hand_inventory;
	for (var i = 0; i < inv.max_size; i++) {
		if (inv.items[i] == item && inv.numbers[i] < inv.stack_size) {
			inv.numbers[i]++;
			return true;
		}
	}
			
	if (inv.items[inv.selected] == -1) {
		inv.items[inv.selected] = item;
		inv.numbers[inv.selected] = 1;
		return true;
	} else if (inv.items[inv.selected] == item && inv.numbers[inv.selected] < inv.stack_size) {
		inv.numbers[inv.selected]++;
		return true;
	} else {
		for (var i = 0; i < inv.max_size; i++) {
			if (inv.items[i] == -1) {
				inv.items[i] = item;
				inv.numbers[i] = 1;
				return true;
			}
		}
	}
}

return false;
