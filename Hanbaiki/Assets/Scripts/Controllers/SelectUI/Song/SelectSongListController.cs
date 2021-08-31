using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.UI;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectSongListController : SelectUIController<SongObject>
    {
        public ScrollListController list;

        private void Start()
        {
            list.Clean();

            var items = SongService.GetCurrent();
            for (int i = 0; i < items.Count; i++)
            {
                var inst = list.Add().GetComponent<SelectSongController>();
                inst.Set(items[i].title, items[i].spr);
            }
            list.GetItem(list.GetSelected()).GetComponent<SelectSongController>().SetHighlight(true);
        }

        protected override void Update()
        {
            base.Update();
            if (coolRemain > 0) return;

            float diff = InputManager.GetVertAxis();
            if (diff != 0)
            {
                list.GetItem(list.GetSelected()).GetComponent<SelectSongController>().SetHighlight(false);
                list.UpdateSelect(Mathf.RoundToInt(diff));
                list.GetItem(list.GetSelected()).GetComponent<SelectSongController>().SetHighlight(true);
                select = SongService.GetCurrent()[list.GetSelected()];

                coolRemain = coolTime;
            }
        }
    }
}