using PotatoTools;
using PotatoTools.Character;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectBuildController : MonoBehaviour
    {
        public PlayerController player;
        public List<UnityEngine.UI.Image> options = new List<UnityEngine.UI.Image>();

        public BuildStationController bsCtrl;
        public BuildCrateController bcCtrl;
        public BuildOutputController boCtrl;
        public BuildFunnelController bfCtrl;
        public BuildEraseController beCtrl;

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private List<GameObject> choices = new List<GameObject>();
        private int selection = 0;

        private void Start()
        {
            player.isLocked = true;
            options[selection].color = new Color(100, 100, 0);

            choices.Add(bsCtrl.gameObject);
            choices.Add(bcCtrl.gameObject);
            choices.Add(boCtrl.gameObject);
            choices.Add(bfCtrl.gameObject);
            choices.Add(beCtrl.gameObject);

        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                player.isLocked = false;
                choices[selection].SetActive(true);
                gameObject.SetActive(false);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                player.isLocked = false;
                gameObject.SetActive(false);
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