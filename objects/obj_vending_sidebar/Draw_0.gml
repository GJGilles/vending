/// @description Insert description here
// You can write your code in this editor

event_inherited();

draw_sprite(spr_weather, -1, x, y);
draw_sprite(spr_trending, -1, x, y + 50);
draw_sprite(spr_daily_bonus, -1, x, y + 70);
draw_sprite(spr_vending_view, -1, x, y + 90);

for (var i = 0; i < 2; i++) {
	for (var j = 0; j < 3; j++) {
		var idx = 3 * i + j;
		if (items[idx] != -1) {
			var item = items[idx];
			draw_sprite_ext(item[? "sprite"], -1, x + (j * 46) + 35, y + (i * 74) + 125, 2, 2, 0, c_white, 1);
			
			draw_set_font(fnt_ken_mini_8);
			draw_set_color(c_black);
			draw_text(x + (j * 46) + 42, y + (i * 74) + 135, (numbers[idx] < 10 ? "0" : "") + string(numbers[idx]));
		}
	}
}

draw_set_font(fnt_ken_mini_8);
draw_set_color(c_black);
draw_text(x + 10, y + 250 , string(obj_game.money));
