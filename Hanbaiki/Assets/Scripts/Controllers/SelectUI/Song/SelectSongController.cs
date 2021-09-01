using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectSongController : MonoBehaviour
    {
        public UnityEngine.UI.Image image;
        public TMPro.TMP_Text textbox;

        public void Set(string text, Sprite spr)
        {
            // image.sprite = spr;
            textbox.text = text;
        }

        public void SetHighlight(bool highlight)
        {
            GetComponent<UnityEngine.UI.Image>().color = highlight ? new Color(100, 100, 0) : new Color(255, 255, 255);
        }
    }
}