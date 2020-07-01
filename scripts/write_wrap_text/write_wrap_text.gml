/// @desc Write out a standard text string
/// @param text String to write
/// @param x X coord to draw at
/// @param y Y coord to draw at
/// @param font Font Enum for the font to use
/// @param max_w Max width for a line of text


draw_set_font(global.fonts[argument3]);
draw_set_color(c_white);

var str = wrap_text(argument0, argument4);
draw_text(argument1, argument2, str);
