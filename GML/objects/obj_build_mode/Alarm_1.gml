/// @description Animate slide out
// You can write your code in this editor

animo_frame--;

var x_diff = (3 - 4 * animo_frame / (animo_len - 1)) * (168 / animo_len);

x_origin += x_diff;

if (animo_frame == (animo_len - 1)) {
	for (var i = 0; i < array_length_1d(components); i++) {
		instance_destroy(components[i]);
	}

	instance_destroy(x_btn);
	instance_destroy(eraser);
} else if (animo_frame = 0) { 
	instance_destroy(id);
} 

alarm[1] = 1;
