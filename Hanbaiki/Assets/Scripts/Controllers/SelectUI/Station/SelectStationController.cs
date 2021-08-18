using Assets.Scripts.Objects;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectStationController : MonoBehaviour
    {
        public UnityEngine.UI.Image image;
        public TMPro.TMP_Text text;

        public void Set(StationObject data, Sprite spr)
        {
            image.sprite = spr;
            text.text = data.title;
        }

        public void SetHighlight(bool highlight)
        {
            GetComponent<UnityEngine.UI.Image>().color = highlight ? new Color(100, 100, 0) : new Color(255, 255, 255);
        }
    }
}