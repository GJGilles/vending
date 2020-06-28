var elems = array_create(0);

for (var i = 0; i < 10; i++) {
	for (var j = 0; j < 9; j++) {
		elems[i, j] = [IOEnum.none, 0];
	}
}

for (var i = 1; i < 9; i++) {
	for (var j = 1; j < 8; j++) {
		elems[i, j] = [IOEnum.any, 0];
	}
}

elems[1, 0] = [IOEnum.input, 0];
elems[0, 1] = [IOEnum.input, 1];

return elems;
