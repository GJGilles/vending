using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ResourceController : SelectableController
    {
        public ItemObject item;
        public int count = 10;
        public int spread;
        public RhythmObject rhythm;

        public RhythmController rObject;
        public ItemController iObject;

        public override void Select(PlayerController player)
        {
            var inst = Instantiate(rObject);
            inst.Set(rhythm);
            inst.OnDone.AddListener(Done);
        }

        private void Done(int success)
        {
            int num = (count * success) / 100;
            for (int i = 0; i < num; i++)
            {
                var inst = Instantiate(iObject, transform.position, new Quaternion());
                inst.Set(item);
                inst.rb.AddForce(spread * (Quaternion.Euler(0, 0, Random.Range(0, 180)) * Vector2.right));
            }
        }
    }
}