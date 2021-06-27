using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ItemSpriteLoader : MonoBehaviour
    {
        [System.Serializable]
        public class ItemSprite
        {
            public ItemEnum id;
            public Sprite spr;
        }

        public List<ItemSprite> sprites = new List<ItemSprite>(); 
        
        public Sprite GetSprite(ItemEnum id)
        {
            foreach (var obj in sprites)
            {
                if (obj.id == id)
                    return obj.spr;
            }
            return null;
        }
    }
}