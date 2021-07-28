using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public enum ButtonEnum
    {
        Jump,
        Fire1,
        Fire2
    }

    public static class InputManager
    {
        public static float GetHorzAxis()
        {
            return Mathf.Round(Input.GetAxisRaw("Horizontal"));
        }

        public static float GetVertAxis()
        {
            return Mathf.Round(Input.GetAxisRaw("Vertical"));
        }

        public static Vector2 GetMovement()
        {
            return new Vector2(GetHorzAxis(), GetVertAxis());
        }

        public static bool GetButtonHeld(ButtonEnum button)
        {
            return Input.GetButton(button.ToString());
        }

        public static bool GetButtonTrigger(ButtonEnum button)
        {
            return Input.GetButtonDown(button.ToString());
        }
    }
}
