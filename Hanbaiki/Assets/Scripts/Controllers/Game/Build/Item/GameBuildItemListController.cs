using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildItemListController : MonoBehaviour
    {
        public GameBuildController build;
        public ScrollListController list;

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private void Start()
        {
            list.Clean();

            var items = ItemService.GetCurrent();
            for (int i = 0; i < items.Count; i++)
            {
                var inst = list.Add().GetComponent<GameBuildItemController>();
                inst.Set(items[i].name, items[i].spr);
            }
            list.GetItem(list.GetSelected()).GetComponent<GameBuildItemController>().SetHighlight(true);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.Fire1))
            {
                build.DoneItem(ItemService.GetCurrent()[list.GetSelected()]);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.Fire2))
            {
                build.Prev();
                return;
            }

            float diff = InputManager.GetVertAxis();
            coolRemain -= Time.deltaTime;
            if (diff != 0 && coolRemain <= 0)
            {
                list.GetItem(list.GetSelected()).GetComponent<GameBuildItemController>().SetHighlight(false);
                list.UpdateSelect(Mathf.RoundToInt(diff));
                list.GetItem(list.GetSelected()).GetComponent<GameBuildItemController>().SetHighlight(true);

                coolRemain = coolTime;
            }
        }
    }
}