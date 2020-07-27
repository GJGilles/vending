/// @description Insert description here
// You can write your code in this editor

event_inherited();

//draw_sprite(spr_weather, -1, x, y);
//draw_sprite(spr_food_blog_banner, floor(animo_frame / (animo_len / 2)), x, y + 50);
//draw_sprite(spr_vending_view, -1, x, y + 90);
draw_self();

var x_offset = 37;
var y_offset = 53;

for (var i = 0; i < 2; i++) {
	for (var j = 0; j < 3; j++) {
		var idx = 3 * i + j;
		if (items[idx] != -1) {
			var item = items[idx];
			scr_item_draw(item, x + (j * x_offset) + 26, y + (i * y_offset) + 25);
			write_text((numbers[idx] < 10 ? "0" : "") + string(numbers[idx]), x + (j * x_offset) + 31, y + (i * y_offset) + 34, FontEnum.silkscreen);
			
			var cost = string(scr_item_cost(item));
			while (string_length(cost) < 5) { cost = " " + cost; }
			
			if (pressed[idx]) {
				draw_sprite(spr_vending_item_p, -1, x + (j * x_offset) + 10, y + (i * y_offset) + 9);
				
				draw_sprite(spr_vending_button_p, -1, x + (j * x_offset) + 11, y + (i * y_offset) + 46);
				write_text(cost, x + (j * x_offset) + 13, y + (i * y_offset) + 48, FontEnum.vending_p);
			} else {
				write_text(cost, x + (j * x_offset) + 13, y + (i * y_offset) + 47, FontEnum.vending_u);
			}
		}
	}
}

//write_text(string(obj_game.money), x + 10, y + 160, FontEnum.silkscreen);
