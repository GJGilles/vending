/// @description Animate slide in
// You can write your code in this editor

var x_diff = (3 - 4 * animo_frame / (animo_len - 1)) * (168 / animo_len);

x_origin -= x_diff;

animo_frame++;
if (animo_frame == animo_len) {
	var num_cols = 3;
	var spacing = 42;
	for (var i = 0; i < array_length_1d(obj_game.current_components); i++) {
		var x_pos = (CAMERA_WIDTH - 20) - spacing * (i % num_cols);
		var y_pos = 66 + spacing * floor(i / num_cols);
		components[i] = instance_create_layer(x_pos, y_pos, BUILD_GUI_LAYER, obj_build_component);
		components[i].component = obj_game.current_components[i];
		components[i].depth -= 2;
	}

	x_btn = instance_create_layer(x_origin, y_origin, BUILD_GUI_LAYER, obj_build_exit);
	eraser = instance_create_layer(CAMERA_WIDTH - 20, y_origin + 28, BUILD_GUI_LAYER, obj_build_eraser);
} else {
	alarm[0] = 1;
}
