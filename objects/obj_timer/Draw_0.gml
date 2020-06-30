/// @description Insert description here
// You can write your code in this editor

event_inherited();

draw_self();
if (running) {
	var hours = floor(time / 60);
	var minutes = time % 60;
	var tens = floor(minutes / 10);
	
	var hr = string(hours > 6 ? (hours - 6) : (hours + 6));
	var m = string(tens) + "0";
	var a = hours >= 6 ? "PM" : "AM";
	
	write_text(string(hr) + ":" + string(m) + " " + a, x + 5, y - 10);
} else if (time < day) {
	draw_sprite(spr_start_day, -1, x, y);
}
