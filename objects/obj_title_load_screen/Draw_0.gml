/// @description Insert description here
// You can write your code in this editor

event_inherited();

for (var i = 0; i < array_length_1d(saves); i++) {
	var frame = i == hovered ? 1 : 0;
	var x_pos = x + 16;
	var y_pos = y + (32 * i) + 16;
	draw_sprite(spr_save_slot, frame, x_pos, y_pos);
	
	var save = saves[i];
	if (save != -1) {
		var time = save[0];
		var location = save[1];
		var datetime = save[2];
		
		write_text(location[0] + ", " + location[1], x_pos + 8, y_pos + 8, FontEnum.silkscreen);
		write_text(datetime, x_pos + 8, y_pos + 16, FontEnum.silkscreen);
	
		write_text("Y: " + string(time[0]) + "\nM: " + string(time[1]) + "\nD: " + string(time[2]), x_pos + 100, y_pos + 8, FontEnum.silkscreen);
	} else {
		write_text("NO DATA", x_pos + 8, y_pos + 8, FontEnum.silkscreen);
	}
}
