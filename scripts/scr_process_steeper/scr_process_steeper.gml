var inputs = argument0;
var result = array_create(4, -1);

if ((inputs[0].iid == 0 && inputs[2].iid == 1) || (inputs[0].iid == 1 && inputs[2].iid == 0)) {
	result[3] = instance_create_layer(x, y, "Components", obj_g_tea);
} else {
	result[3] = instance_create_layer(x, y, "Components", obj_junk);
}

result[3].quality = median(inputs[0].quality, inputs[2].quality);
instance_destroy(inputs[0]);
instance_destroy(inputs[2]);

return result;
