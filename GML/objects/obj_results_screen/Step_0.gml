/// @description Insert description here
// You can write your code in this editor

if (point_in_rectangle(mouse_x, mouse_y, 0, 0, 480, 32)) { 
	y_origin += 4;
	y_origin = min(y_origin, 0);
} else if (point_in_rectangle(mouse_x, mouse_y, 0, 270 - 32, 480, 270)) { 
	var h = 0;
	if (instance_exists(obj_factory_setup)) { 
		var inst = obj_factory_setup;
		h = 32 * ( 4 + array_length_1d(inst.sold_items));
	}
	
	y_origin -= 4;
	y_origin = max(y_origin, (270 - h));
}
