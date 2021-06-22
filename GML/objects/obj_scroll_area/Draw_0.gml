/// @description Insert description here
// You can write your code in this editor


draw_rectangle_color(bbox_left, bbox_top, bbox_left + image_xscale, bbox_top + y_size, c_background, c_background, c_background, c_background, false);

var head_off = y_size > sprite_height ? y_off * sprite_height / y_size : 0;
var head_size = y_size > sprite_height ? sprite_height * sprite_height / y_size : sprite_height;

var head_top = max(bbox_top, bbox_top + head_off);
var head_bot = min(bbox_bottom, bbox_top + head_off + head_size);

draw_rectangle_color(bbox_right - 4, bbox_top, bbox_right, bbox_bottom, c_scrollbar, c_scrollbar, c_scrollbar, c_scrollbar, false);
draw_rectangle_color(bbox_right - 3, head_top, bbox_right - 1, head_bot, c_scrollhead, c_scrollhead, c_scrollhead, c_scrollhead, false);
