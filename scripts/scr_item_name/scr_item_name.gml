function scr_item_name(argument0) {
	var item = argument0;

	var name = item[? "name"];
	var s = item[? "special"];

	var prefix = "";
	for (var i = 0; i < array_length_1d(s); i++) {
		var special = s[i];
		prefix += (i == 0 ? "" : "-") + special[? "pre"];
	}

	return prefix + (string_length(prefix) ? " " : "") + name;



}
