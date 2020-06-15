/// @description Insert description here
// You can write your code in this editor

for (var i = 0; i < slot_width - 1; i++) {
	for (var j = 0; j < slot_height - 1; j++) {
		draw_sprite(spr_grid, -1, x + i * sprite_get_width(spr_grid) / 2,  y + j * sprite_get_height(spr_grid) / 2)
	}
}
