using Assets.Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers
{
    public class InventorySelectController : MonoBehaviour
    {
        public UnityEvent<int> selected = new UnityEvent<int>();

        public int width = 2;
        public List<SpriteRenderer> slots = new List<SpriteRenderer>();

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private int selection = 0;

        private void Start()
        {
            UpdateSelected(selection);
        }

        public void SetItems(List<ItemObject> it)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (i >= it.Count)
                    slots[i].sprite = null;
                else
                {
                    slots[i].sprite = it[i].spr;
                }
            }

        }

        public void UpdateSelected(int location)
        {
            slots[selection].transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
            slots[location].transform.parent.GetComponent<SpriteRenderer>().color = Color.yellow;
            selection = location;
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.Fire1))
                selected.Invoke(selection); 
            
            if (InputManager.GetButtonTrigger(ButtonEnum.Fire2))
                selected.Invoke(-1);

            Vector2 input = InputManager.GetMovement();
            int next = selection;
            if (input.x != 0)
            {
                next += Mathf.FloorToInt(input.x);
                if (next / width > selection / width) next -= width;
                if (next < 0 || next / width < selection / width) next += width;

            }
            else if (input.y != 0)
            {
                next += Mathf.FloorToInt(input.y) * width;
                if (next >= slots.Count) next -= slots.Count;
                if (next < 0) next += slots.Count;
            }

            coolRemain -= Time.deltaTime;
            if (coolRemain <= 0 && next != selection)
            {
                UpdateSelected(next);
                coolRemain = coolTime;
            }
        }
    }
}