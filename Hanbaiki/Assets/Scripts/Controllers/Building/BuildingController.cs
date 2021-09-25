using PotatoTools;
using PotatoTools.Character;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildingController : MonoBehaviour
    {
        public GameObject inside;
        public GameObject outside;

        public int maskLayer;
        private SpriteRenderer mask;

        public void Enter()
        {
            inside.SetActive(true);
            outside.SetActive(false);

            if (mask == null)
            {
                mask = new GameObject().AddComponent<SpriteRenderer>();
                mask.transform.SetParent(Camera.main.transform);
                mask.transform.localPosition = new Vector2(0, 0);
                mask.sprite = Sprite.Create(new Texture2D(640, 360), new Rect(0, 0, 640, 360), new Vector2(0.5f, 0.5f), 32);
                mask.color = Color.black;
                mask.sortingLayerID = maskLayer;
            }
        }

        public void Exit()
        {
            inside.SetActive(false);
            outside.SetActive(true);

            if (mask != null)
            {
                Destroy(mask.gameObject);
            }
        }
    }
}