using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class VendingSlotController : MonoBehaviour
    {
        public SpriteRenderer spr;
        public TMPro.TMP_Text textbox;

        public void Set(Sprite s, string text)
        {
            spr.sprite = s;
            textbox.text = text;
        }
    }
}