/// @description Insert description here
// You can write your code in this editor


if (inst == undefined) { inst = obj_title_load_slot; }


saves = array_create(6);
for (var i = 0; i < 6; i++) {
	saves[i] = instance_create_depth(x + 16, y + (i * 32) + 16, depth - 1, inst);
	saves[i].exists = scr_save_exists(i);
	
	saves[i].idx = i;
	saves[i].script = scr_load_game;
	
	if (saves[i].exists) {
		saves[i].time = scr_load_time(i);
		saves[i].location = scr_load_location(i);
		
		var dt = scr_load_datetime(i);
		saves[i].datetime = get_date_string(dt[0], dt[1], dt[2], dt[3], dt[4]);
	}
}
