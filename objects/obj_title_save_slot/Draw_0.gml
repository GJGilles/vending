/// @description Insert description here
// You can write your code in this editor

draw_self();

if (exists) {
	write_text(location[0] + ", " + location[1], x + 8, y + 8, FontEnum.silkscreen);
	write_text(datetime, x + 8, y + 16, FontEnum.silkscreen);
	
	write_text("Y: " + string(time[0]) + "\nM: " + string(time[1]) + "\nD: " + string(time[2]), x + 100, y + 8, FontEnum.silkscreen);
} else {
	write_text("NO DATA", x + 8, y + 8, FontEnum.silkscreen);
}

