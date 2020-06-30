/// @description Insert description here
// You can write your code in this editor

event_inherited();

count++;
if (count == freq) {
	count = 0;
	
	var buy_arr = scr_vend_customer(items, 10, 10);
	for (var i = 0; i < array_length_1d(buy_arr); i++) {
		var idx = buy_arr[i];
		pressed[idx] = 1;
	}
} else if (count == press) {
	for (var i = 0; i < array_length_1d(pressed); i++) {
		if (pressed[i]) {
			var item = items[i];
			scr_results_add_sold(item);
			obj_game.money += item[? "cost"];
		
			numbers[i]--;
			if (numbers[i] == 0) {
				items[i] = -1;
			}
		}
	}
	
	pressed = array_create(6, 0);
}

animo_frame++;
if (animo_frame == animo_len) { animo_frame = 0; }
