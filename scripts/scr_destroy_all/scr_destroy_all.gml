var arr = argument0;

for (var i = 0; i < array_length_1d(arr); i++) {
	var elem = arr[i];
	if (ds_map_exists(elem, "weather")) {
		var weather = elem[? "weather"];
		ds_queue_destroy(weather);
	}
	ds_map_destroy(elem);
}
