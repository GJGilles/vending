var inputs = argument0;
var result = array_create(4, -1);

if ((inputs[0].iid == 0 && inputs[1].iid == 1) || (inputs[0].iid == 1 && inputs[1].iid == 0)) {
	result[2] = instance_create_layer(x, y, "Instances", obj_g_tea);
} else {
	result[2] = instance_create_layer(x, y, "Instances", obj_junk);
}

result[2].quality = median(inputs[0].quality, inputs[1].quality);
instance_destroy(inputs[0]);
instance_destroy(inputs[1]);

return result;
