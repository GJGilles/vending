using PotatoTools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildTypeController : MonoBehaviour
    {
        public BuildController build;
        public List<UnityEngine.UI.Image> options = new List<UnityEngine.UI.Image>();

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private List<TileTypeEnum> choices = new List<TileTypeEnum>() { TileTypeEnum.Station, TileTypeEnum.Input, TileTypeEnum.Output, TileTypeEnum.None };
        private int selection = 0;

        private void Start()
        {
            options[selection].color = new Color(100, 100, 0);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                build.DoneType(choices[selection]);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                build.Prev();
                return;
            }

            float diff = InputManager.GetVertAxis();
            coolRemain -= Time.deltaTime;
            if (diff != 0 && coolRemain <= 0)
            {
                options[selection].color = new Color(255, 255, 255);

                selection -= Mathf.RoundToInt(diff);
                if (selection < 0) selection += options.Count;
                if (selection >= options.Count) selection -= options.Count;

                options[selection].color = new Color(100, 100, 0);

                coolRemain = coolTime;
            }
        }
    }
}