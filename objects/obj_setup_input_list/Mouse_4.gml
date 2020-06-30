/// @description Insert description here
// You can write your code in this editor

for (var i = 0; i < array_length_1d(tokens); i++) {
	var t = tokens[i];
	if (t == -1 && point_in_rectangle(mouse_x, mouse_y, x, y + (16 * i), x + 16, y + (16 * i) + 16)) {
		dragging = i;
		break;
	}
}
