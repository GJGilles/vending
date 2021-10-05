using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class OrderDeskController : SelectableController
    {
        public ItemController iObject;
        public SelectPurchaseListController purchase;

        public int spread;

        public override void Select()
        {
            purchase.gameObject.SetActive(true);
            purchase.OnDone.AddListener(Done);
        }

        private void Done(Dictionary<IngredientObject, int> numbers)
        {
            foreach (var val in numbers)
            {
                for (int i = 0; i < val.Value; i++)
                {
                    var inst = Instantiate(iObject, transform.position, new Quaternion());
                    inst.Set(val.Key);
                    inst.rb.AddForce(spread * (Quaternion.Euler(0, 0, Random.Range(0, 180)) * Vector2.right));
                }
            }

        }
    }
}