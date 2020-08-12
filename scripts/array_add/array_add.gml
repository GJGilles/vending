/// @desc Return two arrays added
/// @param arr1 First Array
/// @param arr2 Second Array


var ret = array_create(0);

array_copy(ret, 0, argument0, 0, array_length_1d(argument0));
for (var i = 0; i < array_length_1d(argument1); i++) {
	ret[array_length_1d(ret)] = argument1[i];
}

return ret;
