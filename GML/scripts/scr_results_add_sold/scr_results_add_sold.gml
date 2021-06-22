function scr_results_add_sold(argument0) {
	var item = argument0;

	var idx = item[? "id"];

	for (var i = 0; i < 4; i++) {
		obj_game.item_stats[# idx, i]++;
	}



}
