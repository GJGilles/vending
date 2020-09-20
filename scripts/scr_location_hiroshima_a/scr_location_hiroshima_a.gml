function scr_location_hiroshima_a() {
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

	elems[3, 0] = [IOEnum.input, 0];
	elems[4, 0] = [IOEnum.input, 0];
	elems[5, 0] = [IOEnum.input, 0];
	elems[6, 0] = [IOEnum.input, 0];


	elems[4, 4] = [IOEnum.output, 3];

	return elems;



}
