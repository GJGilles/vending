using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Assets.Scripts
{
    public enum ButtonEnum
    {
        A,
        B,
        X,
        Y,
        Start
    }

    public static class InputManager
    {
        private static float ReadInput(List<ButtonControl> inputs)
        {
            foreach (var input in inputs)
            {
                if (input == null) continue;

                float val = input.ReadValue();
                if (val != 0)
                {
                    return val;
                }
            }

            return 0f;
        }

        private static bool ReadTrigger(List<ButtonControl> inputs)
        {
            foreach (var input in inputs)
            {
                if (input == null) continue;

                bool val = input.wasPressedThisFrame;
                if (val)
                {
                    return val;
                }
            }

            return false;
        }

        private static List<ButtonControl> GetButtons(ButtonEnum id)
        {
            switch (id)
            {
                default:
                case ButtonEnum.A:
                    return new List<ButtonControl>() { 
                        Gamepad.current?.aButton,
                        Keyboard.current?.zKey
                    };
                case ButtonEnum.B:
                    return new List<ButtonControl>() {
                        Gamepad.current?.bButton,
                        Keyboard.current?.xKey,
                        Keyboard.current?.spaceKey
                    };
                case ButtonEnum.X:
                    return new List<ButtonControl>() {
                        Gamepad.current?.xButton,
                        Keyboard.current?.eKey
                    };
                case ButtonEnum.Y:
                    return new List<ButtonControl>() {
                        Gamepad.current?.yButton,
                        Keyboard.current?.qKey
                    };
                case ButtonEnum.Start:
                    return new List<ButtonControl>() { 
                        Gamepad.current?.startButton,
                        Keyboard.current?.escapeKey
                    };
            }
        }


        public static float GetHorzAxis()
        {
            float left = ReadInput(new List<ButtonControl>() {
                Gamepad.current?.leftStick?.left,
                Keyboard.current?.leftArrowKey
            });

            float right = ReadInput(new List<ButtonControl>() { 
                Gamepad.current?.leftStick?.right,
                Keyboard.current?.rightArrowKey
            });

            return right - left;
        }

        public static float GetVertAxis()
        {
            float up = ReadInput(new List<ButtonControl>() {
                Gamepad.current?.leftStick?.up,
                Keyboard.current?.upArrowKey
            });

            float down = ReadInput(new List<ButtonControl>()
            {
                Gamepad.current?.leftStick?.down,
                Keyboard.current?.downArrowKey
            });

            return up - down;
        }

        public static Vector2 GetMovement()
        {
            return new Vector2(GetHorzAxis(), GetVertAxis());
        }

        public static float GetButtonHeld(ButtonEnum button)
        {
            return ReadInput(GetButtons(button));
        }

        public static bool GetButtonTrigger(ButtonEnum button)
        {
            return ReadTrigger(GetButtons(button));
        }
    }
}
