/// array_sort(array)

var array = argument0;

var list = ds_list_create();
var count = array_length_1d(array);

for (var i=0; i<count; i++) { 
	list[| i] = array[i];
}

ds_list_sort(list, true);

for (i = 0; i < count; i++) {
	array[i] = list[| i];
}

ds_list_destroy(list);
return array;