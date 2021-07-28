using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameSelectionController : MonoBehaviour
    {
        public GameBuildController build;
        public GameMapController map;

        private int location = 0;
        private bool selected = false;
        private ItemObject held;

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.Fire1) && !selected)
            {
                Select();
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.Fire2) && selected)
            {
                Deselect();
            }
        }

        public bool IsSelected() { return selected; }

        public void Select()
        {
            selected = true;
            map.Select(this, location);
        }

        public void Deselect()
        {
            selected = false;
            map.Deselect(location);
        }

        public bool IsHolding() { return held != null; }

        public ItemObject Give()
        {
            var item = held;
            held = null;
            return item;
        }

        public void Take(ItemObject item)
        {

        }

        public void UpdateSelection(int player, CharacterDirectionEnum direction)
        {
            int width = map.GetMap().width;
            int next = player + GetDiff(direction);

            if (player / width != next / width && player % width != next % width)
            {
                location = player;
            }
            else
            {
                location = next;
            }
        }

        private int GetDiff(CharacterDirectionEnum direction)
        {
            switch (direction)
            {
                case CharacterDirectionEnum.Down:
                    return map.GetMap().width;

                case CharacterDirectionEnum.Up:
                    return -map.GetMap().width;

                case CharacterDirectionEnum.Left:
                    return -1;

                case CharacterDirectionEnum.Right:
                    return 1;

                default:
                    return 0;
            }
        }
    }
}