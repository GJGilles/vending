var slot = string(argument0);

ini_open(slot + "_save.ini");

var dt = ini_read_real("datetime", "write", date_current_datetime());

ini_close();

return [date_get_year(dt), date_get_month(dt), date_get_day(dt), date_get_hour(dt), date_get_minute(dt)];
