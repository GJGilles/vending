using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SongPointController : SelectableController
    {
        public SelectSongListController select;

        public LocationObject location;
        public RhythmController rObject;

        private SongObject song;

        public override void Select()
        {
            select.gameObject.SetActive(true);

            PlayerService.Lock();
            select.OnCancel = () => PlayerService.Unlock();
            select.OnDone = OnSelect;
        }

        private void OnSelect(SongObject s)
        {
            song = s;
            select.gameObject.SetActive(false);

            var inst = Instantiate(rObject);
            inst.Set(s);
            inst.OnDone.AddListener(Done);
        }

        private void Done(int success)
        {
            int amount = (20 * success) / 100;
            location.popularity.UpdateFlavor(song.flavor, amount);
            location.popularity.UpdatePrep(song.prep, amount);
            select.gameObject.SetActive(true);
        }
    }
}