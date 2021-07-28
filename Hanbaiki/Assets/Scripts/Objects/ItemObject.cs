using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemObject", order = 3)]
	public class ItemObject : ScriptableObject
    {
		public string title;
		public Sprite spr;
		public int cost;
		public ItemColorEnum color;
		public ItemTempEnum temp;
		public ItemFlavorEnum flavor;
		public ItemPrepEnum prep;
		public string description;
		public List<string> special;
	}
}