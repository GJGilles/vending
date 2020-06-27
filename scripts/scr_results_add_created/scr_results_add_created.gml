var item = argument0;

if (!instance_exists(obj_factory_stats)) { return; }

var size = array_length_1d(obj_factory_stats.created_items);
for (var i = 0; i < size; i++) {
	if (obj_factory_stats.created_items[i] == item) {
		obj_factory_stats.created_numbers[i]++;
		return;
	}
}

obj_factory_stats.created_items[size] = item;
obj_factory_stats.created_numbers[size] = 1;
