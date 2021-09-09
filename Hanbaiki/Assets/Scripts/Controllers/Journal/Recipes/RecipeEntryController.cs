using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class RecipeEntryController : MonoBehaviour
    {
        public List<UnityEngine.UI.Image> inputs = new List<UnityEngine.UI.Image>();
        public TMPro.TMP_Text time;
        public UnityEngine.UI.Image station;
        public UnityEngine.UI.Image output;

        public void Set(RecipeObject recipe)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                if (i < recipe.input.Count)
                {
                    inputs[i].sprite = recipe.input[i].spr;
                }
                else
                {
                    inputs[i].sprite = null;
                }
            }

            time.text = (Mathf.RoundToInt(recipe.time) + " seconds");
            station.sprite = StationService.GetStation(recipe).spr;
            output.sprite = recipe.output.spr;
        }
    }
}