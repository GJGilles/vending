/// @description Insert description here
// You can write your code in this editor


saves = array_create(6, -1);
for (var i = 0; i < 6; i++) {
	var exists = scr_save_exists(i);
	
	if (exists) {
		var time = scr_load_time(i);
		var location = scr_load_location(i);
		
		var dt = scr_load_datetime(i);
		var datetime = get_date_string(dt[0], dt[1], dt[2], dt[3], dt[4]);
		
		saves[i] = [time, location, datetime];
	}
}


hovered = -1;
selected = -1;
