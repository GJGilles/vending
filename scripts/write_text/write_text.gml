/// @desc Write out a standard text string
/// @param text String to write
/// @param x X coord to draw at
/// @param y Y coord to draw at
/// @param font Font Enum for the font to use


draw_set_font(global.fonts[argument3]);
draw_set_color(c_white);
draw_text(argument1, argument2, argument0);
