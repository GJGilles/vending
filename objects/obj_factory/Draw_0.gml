/// @description Insert description here
// You can write your code in this editor

for (var i = 1; i < slot_width; i++) {
	for (var j = 1; j < slot_height; j++) {
		draw_sprite(spr_grid, -1, i * sprite_get_width(spr_grid) / 2,  j * sprite_get_height(spr_grid) / 2)
	}
}
