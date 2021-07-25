using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildItemController : MonoBehaviour
    {
        public UnityEngine.UI.Image image;
        public TMPro.TMP_Text text;

        public void Set(StationData data, Sprite spr)
        {
            image.sprite = spr;
            text.text = data.name;
        }

        public void SetHighlight(bool highlight)
        {
            GetComponent<UnityEngine.UI.Image>().color = highlight ? new Color(100, 100, 0) : new Color(0, 0, 0);
        }
    }
}