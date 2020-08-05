/// @description Insert description here
// You can write your code in this editor

if (obj_game.mouse == id) {
	if (height < sprite_height) { return; }
	
	var diff = min(y_off + 10, height - sprite_height) - y_off;
	y_off += diff;
	for (var i = 0; i < array_length_1d(recipes); i++) {
		recipes[i].y -= diff;
		recipes[i].visible = place_meeting(x, y, recipes[i]);
	}
}
