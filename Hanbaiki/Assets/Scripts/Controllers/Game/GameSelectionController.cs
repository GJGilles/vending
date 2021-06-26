using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameSelectionController : MonoBehaviour
    {
        public GameMapController map;

        private int location = 0;
        private bool selected = false;

        private void Update()
        {
            if (InputManager.GetFireA())
            {
                if (selected)
                    Deselect();
                else
                    Select();
            }
        }

        public bool IsSelected() { return selected; }

        private void Select()
        {
            selected = true;
            map.Select(location);
        }

        private void Deselect()
        {
            selected = false;
            map.Deselect(location);
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