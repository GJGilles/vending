
enum FontEnum {
	silkscreen = 0,
	vending_u = 1,
	vending_p = 2
}

var map_str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 :~";
var map_num = "0123456789";

global.fonts = array_create(0);
global.fonts[FontEnum.silkscreen] = font_add_sprite_ext(spr_font_silkscreen, map_str, true, 1);
global.fonts[FontEnum.vending_u] = font_add_sprite_ext(spr_font_vending_u, map_num, false, -1);
global.fonts[FontEnum.vending_p] = font_add_sprite_ext(spr_font_vending_p, map_num, false, -1);
