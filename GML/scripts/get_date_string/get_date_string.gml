function get_date_string(argument0, argument1, argument2, argument3, argument4) {
	var names = ["", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

	var year = argument0;
	var month = argument1;
	var day = argument2;
	var hour = argument3;
	var minute = argument4;


	return string(year) + " " + names[month] + " " + string(day) + " " + string(hour) + ":" + string(minute); 




}
