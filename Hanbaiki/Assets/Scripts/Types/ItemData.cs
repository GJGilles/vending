using System.Collections.Generic;

namespace Assets.Scripts.Types
{
	public enum ItemEnum
    {
		GTeaLeaves,
		Water,
		Flour,
		Onion,
		Milk,
		Rice,
		Watermelon,
		Strawberries,
		Chicken,
		Eggs,
		Sugar,
		Pork,
		Ginger,

		BTeaLeaves,
		Genmai,
		Dough,
		Batter,
		Mochi,

		GTea,
		BTea,
		RoyalMilkTea,
		Genmaicha,
		IceCream,
		Amazake,
		Yoink,
		WParfait,
		SParfait,
		Yakitori,
		Flan,
		MilkBread,
		Castella,
		Katsudon,
		WKatsudon,
		Toriten,
		KatsuSando,
		WKatsuSando,
		StrawberrySando,
		MochiIceCream,
		Dorayaki
    }

	public enum ItemColorEnum
    {
		White,
		Green,
		Black,
		Yellow,
		Red
    }

	public enum ItemTempEnum
    {
		Hot,
		Warm,
		Mild,
		Cool,
		Cold
    }

	public enum ItemFlavorEnum
    {
		Salty,
		Sweet,
		Sour,
		Bitter,
		Umami,
    }

	public enum ItemPrepEnum
    {
		Raw,
		Simmered,
		Fried,
		Steamed,
		Roasted
    }

    public class ItemData
    {
		public string name;
		public ItemEnum id;
		public int cost;
		public ItemColorEnum color;
		public ItemTempEnum temp;
		public ItemFlavorEnum flavor;
		public ItemPrepEnum prep;
		public string description;
		public List<string> special;
    }
}
