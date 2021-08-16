using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FoodObject", order = 8)]
	public class FoodObject : IngredientObject
    {
		public int cost;
		public ItemColorEnum color;
		public ItemTempEnum temp;
		public ItemFlavorEnum flavor;
		public ItemPrepEnum prep;
	}
}