var item = argument0;

var cost = item[? "cost"];
var s = item[? "special"];

for (var i = 0; i < array_length_1d(s); i++) {
	var special = obj_game.all_special[s[i]];
	cost *= special[? "multi"];
}

return cost;
