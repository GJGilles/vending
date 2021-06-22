/// @description Insert description here
// You can write your code in this editor

event_inherited();

draw_self();

var flavor = "";
switch (obj_game.popular[0]) {
	case ItemFlavorEnum.salty:
		flavor = "Salty";
		break;
	case ItemFlavorEnum.sweet:
		flavor = "Sweet";
		break;
	case ItemFlavorEnum.sour:
		flavor = "Sour";
		break;
	case ItemFlavorEnum.bitter:
		flavor = "Bitter";
		break;
	case ItemFlavorEnum.umami:
		flavor = "Umami";
		break;
}

var prep = "";
switch (obj_game.popular[1]) {
	case ItemPrepEnum.raw:
		prep = "Raw";
		break;
	case ItemPrepEnum.simmered:
		prep = "Simmered";
		break;
	case ItemPrepEnum.fried:
		prep = "Fried";
		break;
	case ItemPrepEnum.steamed:
		prep = "Steamed";
		break;
	case ItemPrepEnum.roasted:
		prep = "Roasted";
		break;
}

write_text("What's hot:", x + 44, y + 15, FontEnum.silkscreen);
write_text("-" + flavor, x + 49, y + 22, FontEnum.silkscreen);
write_text("-" + prep, x + 49, y + 29, FontEnum.silkscreen);
