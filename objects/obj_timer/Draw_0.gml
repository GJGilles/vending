/// @description Insert description here
// You can write your code in this editor

event_inherited();

draw_self();
if (running) {
	var hours = floor(time / 60);
	var minutes = time % 60;
	
	var hr = string(hours > 6 ? (hours - 6) : (hours + 6));
	var m = minutes < 10 ? "0" + string(minutes) : string(minutes);
	var a = hours >= 6 ? "PM" : "AM";
	
	draw_set_font(fnt_ken_mini_8);
	draw_set_color(c_black);
	draw_text(x + 5, y - 10, string(hr) + ":" + string(m) + " " + a);
} else if (time < day) {
	draw_sprite(spr_start_day, -1, x, y);
}
