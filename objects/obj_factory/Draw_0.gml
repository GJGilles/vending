/// @description Insert description here
// You can write your code in this editor

for (var i = 1; i < slot_width - 2; i++) {
	for (var j = 1; j < slot_height - 2; j++) {
		draw_sprite(spr_grid, -1, x + i * sprite_get_width(spr_grid) / 2,  y + j * sprite_get_height(spr_grid) / 2)
	}
}
