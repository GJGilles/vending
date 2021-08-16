using PotatoTools;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IngredientObject", order = 3)]
	public class IngredientObject : ItemObject
    {
		public string description;
		public bool unlocked = true;
	}
}