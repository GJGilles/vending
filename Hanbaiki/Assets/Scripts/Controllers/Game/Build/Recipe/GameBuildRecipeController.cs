using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildRecipeController : MonoBehaviour
    {
        public List<UnityEngine.UI.Image> inputs = new List<UnityEngine.UI.Image>();
        public List<UnityEngine.UI.Image> outputs = new List<UnityEngine.UI.Image>();

        public void Set(RecipeObject data)
        {
            for (int i = 0; i < data.input.Count; i++)
            {
                inputs[i].sprite = data.input[i].spr;
            }
            for (int i = 0; i < data.output.Count; i++)
            {
                outputs[i].sprite = data.output[i].spr;
            }
        }

        public void SetHighlight(bool highlight)
        {
            GetComponent<UnityEngine.UI.Image>().color = highlight ? new Color(100, 100, 0) : new Color(255, 255, 255);
        }
    }
}