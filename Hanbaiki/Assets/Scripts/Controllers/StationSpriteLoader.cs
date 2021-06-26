using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class StationSpriteLoader : MonoBehaviour
    {
        [System.Serializable]
        public class StationSprite
        {
            public StationEnum id;
            public Sprite spr;
        }

        public List<StationSprite> sprites = new List<StationSprite>();

        public Sprite GetSprite(StationEnum id)
        {
            foreach(var obj in sprites)
            {
                if (obj.id == id)
                    return obj.spr;
            }
            return null;
        }
    }
}