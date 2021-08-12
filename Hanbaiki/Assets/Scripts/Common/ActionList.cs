using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Common
{
    public class ActionList : MonoBehaviour
    {
        public List<UnityEngine.UI.Image> buttons = new List<UnityEngine.UI.Image>();

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private int selection = 0;
        protected List<Action> actions = new List<Action>();

        protected virtual void Start()
        {
            ChangeSelect(selection);
        }

        protected virtual void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                actions[selection]();
            }

            var input = InputManager.GetVertAxis();
            int next = selection;
            if (input < 0)
            {
                next++;
                if (next >= actions.Count) next -= actions.Count;
            }
            else if (input > 0)
            {
                next--;
                if (next < 0) next += actions.Count;
            }

            coolRemain -= Time.unscaledDeltaTime;
            if (coolRemain <= 0 && next != selection)
            {
                ChangeSelect(next);
                coolRemain = coolTime;
            }
        }

        private void ChangeSelect(int next)
        {
            buttons[selection].color = Color.white;
            buttons[next].color = Color.yellow;
            selection = next;
        }
    }
}