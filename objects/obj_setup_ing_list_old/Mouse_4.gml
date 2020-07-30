/// @description Insert description here
// You can write your code in this editor

var inputs = obj_setup_input_list;
var idx = floor((mouse_y - y_origin) / 16);
var count = floor((mouse_x - (bbox_right - 40)) / 8);

var last = -1;
for (var i = 0; i < array_length_1d(inputs.tokens); i++) {
	if (inputs.tokens[i] == idx) {
		last = i;
		if (count <= 0) { break; }
		count--;
	}
}
if(last != -1) {
	inputs.tokens[last] = -1;
	inputs.dragging = last;
}
