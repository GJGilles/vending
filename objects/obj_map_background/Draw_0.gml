/// @description Insert description here
// You can write your code in this editor

var spr = spr_map_waves;
var w = sprite_get_width(spr);
var h = sprite_get_height(spr);
var f = sprite_get_number(spr);

for (var i = 0; i < ceil(2 * sprite_height / h) + 2; i++) {
	var y_pos = (i * h / 2) + (animo_frame * h / animo_len) - (3 * h / 2);
	
	for (var j = 0; j < ceil(sprite_width / w) + 3; j++) {
		var x_pos = (j * w) + (animo_frame * w / animo_len) - (w / 2) * (i % 2) - w;
		
		draw_sprite(spr, floor(animo_frame * f / animo_len), x_pos, y_pos);
	}
}

animo_frame++;
if (animo_frame == animo_len) {
	animo_frame = 0;
}

draw_self();
