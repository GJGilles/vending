using Assets.Scripts.Objects;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectPurchaseController : MonoBehaviour
    {
        public UnityEngine.UI.Image image;
        public TMPro.TMP_Text title;
        public TMPro.TMP_Text cost;
        public TMPro.TMP_Text number;
        public TMPro.TMP_Text total;

        private IngredientObject obj;

        public IngredientObject Get()
        {
            return obj;
        }

        public void Set(IngredientObject i)
        {
            obj = i;

            image.sprite = i.spr;
            title.text = i.name;
            cost.text = "$" + i.buy.ToString();
            number.text = "0";
        }

        public void Set(int num)
        {
            number.text = "x" + num.ToString();
            total.text = "$" + (num * obj.buy).ToString();
        }

        public void SetHighlight(bool highlight)
        {
            GetComponent<UnityEngine.UI.Image>().color = highlight ? new Color(100, 100, 0) : new Color(255, 255, 255);
        }
    }
}