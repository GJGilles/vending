/// @description Animate slide out
// You can write your code in this editor

var x_diff = (3 - 4 * animo_frame / (animo_len - 1)) * (168 / animo_len);

x_origin += x_diff;

if (animo_frame == animo_len) {
	for (var i = 0; i < array_length_1d(components); i++) {
		instance_destroy(components[i]);
	}

	instance_destroy(x_btn);
	instance_destroy(eraser);
} else if (animo_frame = 1) { 
	instance_destroy(id);
} 

animo_frame--;
alarm[1] = 1;
