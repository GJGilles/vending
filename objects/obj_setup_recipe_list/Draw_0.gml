/// @description Insert description here
// You can write your code in this editor

var c1 = c_white;
var c2 = c_maroon;

var head_off = height > sprite_height ? y_off * sprite_height / height : 0;
var head_size = height > sprite_height ? sprite_height * sprite_height / height : sprite_height;

var head_top = max(bbox_top, bbox_top + head_off);
var head_bot = min(bbox_bottom, bbox_top + head_off + head_size);

draw_rectangle_color(bbox_right - 4, bbox_top, bbox_right, bbox_bottom, c1, c1, c1, c1, false);
draw_rectangle_color(bbox_right - 3, head_top, bbox_right - 1, head_bot, c2, c2, c2, c2, false);
