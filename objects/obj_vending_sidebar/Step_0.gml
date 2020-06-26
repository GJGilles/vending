/// @description Insert description here
// You can write your code in this editor

event_inherited();

count++;
if (count == freq) {
	count = 0;
	
	var buy_arr = scr_vend_customer(items, 20, 20);
	for (var i = 0; i < array_length_1d(buy_arr); i++) {
		var idx = buy_arr[i];
		numbers[idx]--;
		if (numbers[idx] == 0) {
			items[idx] = -1;
		}
	}
}

