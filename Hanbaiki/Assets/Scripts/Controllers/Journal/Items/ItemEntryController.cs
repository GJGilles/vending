using Assets.Scripts.Objects;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ItemEntryController : MonoBehaviour
    {
        public TMPro.TMP_Text nameArea;
        public TMPro.TMP_Text descArea;

        public TMPro.TMP_Text costArea;
        public TMPro.TMP_Text colorArea;
        public TMPro.TMP_Text tempArea;
        public TMPro.TMP_Text flavorArea;
        public TMPro.TMP_Text prepArea;

        public void Set(IngredientObject i)
        {
            nameArea.text = i.title;
            descArea.text = i.description;

            if (i is FoodObject)
            {
                FoodObject f = (FoodObject)i;
                costArea.text = "$" + f.sell;
                colorArea.text = f.color.ToString();
                tempArea.text = f.temp.ToString();
                flavorArea.text = f.flavor.ToString();
                prepArea.text = f.prep.ToString();
            }
            else
            {
                costArea.text = "";
                colorArea.text = "";
                tempArea.text = "";
                flavorArea.text = "";
                prepArea.text = "";
            }
        }
    }
}