/// @description Insert description here
// You can write your code in this editor

event_inherited();

saves = array_create(6, -1);
for (var i = 0; i < 6; i++) {
	buttons[i + 1] = [16, (32 * i) + 16, spr_save_slot];
	
	var exists = scr_save_exists(i);
	if (exists) {
		var time = scr_load_time(i);
		var location = scr_load_location(i);
		
		var dt = scr_load_datetime(i);
		var datetime = get_date_string(dt[0], dt[1], dt[2], dt[3], dt[4]);
		
		saves[i] = [time, location, datetime];
	}
}

