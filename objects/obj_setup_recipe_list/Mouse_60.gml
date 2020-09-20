/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id) {
	if (height < sprite_height) { return; }
	
	var diff = max(y_off - 10, 0) - y_off;
	y_off += diff;
	for (var i = 0; i < array_length(recipes); i++) {
		recipes[i].y -= diff;
		recipes[i].visible = place_meeting(x, y, recipes[i]);
	}
}
