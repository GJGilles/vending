using PotatoTools;
using PotatoTools.Character;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectBuildController : SelectUIController<int>
    {
        public PlayerController player;
        public List<UnityEngine.UI.Image> options = new List<UnityEngine.UI.Image>();

        public BuildStationController bsCtrl;
        public BuildCrateController bcCtrl;
        public BuildOutputController boCtrl;
        public BuildFunnelController bfCtrl;
        public BuildEraseController beCtrl;

        private List<GameObject> choices = new List<GameObject>();

        private void OnEnable()
        {
            PlayerService.Lock();
        }

        private void Start()
        {
            select = 0;
            options[select].color = Color.yellow;

            choices.Add(bsCtrl.gameObject);
            choices.Add(bcCtrl.gameObject);
            choices.Add(boCtrl.gameObject);
            choices.Add(bfCtrl.gameObject);
            choices.Add(beCtrl.gameObject);

            OnCancel = () =>
            {
                PlayerService.Unlock();
                gameObject.SetActive(false);
            };

            OnDone = (int i) =>
            {
                PlayerService.Unlock();
                gameObject.SetActive(false);

                choices[i].SetActive(true);
            };
        }

        protected override void Update()
        {
            base.Update();
            if (coolRemain > 0) return;

            float diff = InputManager.GetVertAxis();
            if (diff != 0)
            {
                options[select].color = Color.white;

                select -= Mathf.RoundToInt(diff);
                if (select < 0) select += options.Count;
                if (select >= options.Count) select -= options.Count;

                options[select].color = Color.yellow;

                coolRemain = coolTime;
            }
        }
    }
}