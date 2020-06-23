var inputs = array_sort(argument0);
var result = array_create(4, -1);

var item = inputs[3];
var vend = obj_vending_sidebar;

for (var i = 0; i < array_length_1d(vend.items); i++) {
	if (vend.items[i] == item && vend.numbers[i] < vend.stack_size) {
		vend.numbers[i]++;
		return result;
	}
}
for (var i = 0; i < array_length_1d(vend.items); i++) {
	if (vend.items[i] == -1) {
		vend.items[i] = item;
		vend.numbers[i] = 1;
		return result;
	}
}

// Failed to place item: spit it out?
result[0] = item;
return result;
