
enum FontEnum {
	silkscreen,
	silkscreen_2w,
	vending_u,
	vending_p,
	temp
}

var map_str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 :~'-?!";
var map_num = "0123456789c-";

global.fonts = array_create(0);
global.fonts[FontEnum.silkscreen] = font_add_sprite_ext(spr_font_silkscreen, map_str, true, 1);
global.fonts[FontEnum.silkscreen_2w] = font_add_sprite_ext(spr_font_silkscreen_2w, map_str, true, 2);
global.fonts[FontEnum.vending_u] = font_add_sprite_ext(spr_font_vending_u, map_num, false, -1);
global.fonts[FontEnum.vending_p] = font_add_sprite_ext(spr_font_vending_p, map_num, false, -1);
global.fonts[FontEnum.temp] = font_add_sprite_ext(spr_font_temp, map_num, false, -3);
