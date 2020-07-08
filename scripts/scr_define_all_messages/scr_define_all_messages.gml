
enum FriendEnum {
	dad = 0
}


var convos = array_create(0);

convos[FriendEnum.dad] = [
	scr_define_message(0, 0, "Hey sport! How's it hangin?")
];


return convos;
