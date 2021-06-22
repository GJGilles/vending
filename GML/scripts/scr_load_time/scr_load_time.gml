function scr_load_time(argument0) {
	var slot = string(argument0);

	ini_open(slot + "_save.ini");

	var year = ini_read_real("time", "year", 0);
	var month = ini_read_real("time", "month", 0);
	var day = ini_read_real("time", "day", 0);

	ini_close();

	return [year, month, day];



}
