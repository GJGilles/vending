using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        private static T ReadInput<T>(List<InputControl<T>> inputs) where T : struct
        {
            foreach (var input in inputs)
            {
                if (input)
            }
        }

        public static float GetHorzAxis()
        {
            if (Gamepad.current != null)
            {
                if (Gamepad.current.leftStick.ReadValue().x != 0)
            }
            else
            {
                return Keyboard.current;
            }
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
