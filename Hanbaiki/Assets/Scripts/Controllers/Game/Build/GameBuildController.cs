using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildController : MonoBehaviour
    {
        public CameraFollow cam;
        public GameMapController map;
        public GameSelectionController selecter;
        public GameBuildListController list;

        private int location = 0;
        private StationEnum station;

        private void Update()
        {
            if (list.isActiveAndEnabled)
            {
                if (InputManager.GetFireA())
                {
                    station = list.GetSelected();
                    list.gameObject.SetActive(false);
                    return;
                }

                if (InputManager.GetFireB())
                {
                    list.gameObject.SetActive(false);
                    return;
                }

                float diff = InputManager.GetVertAxis();
                if (diff != 0)
                {
                    list.UpdateSelect(Mathf.RoundToInt(diff));
                }
            }
            else
            {
                if (InputManager.GetFireA())
                {
                    map.SetTile(location, station);
                    return;
                }

                if (InputManager.GetFireB())
                {

                    gameObject.SetActive(false);
                    selecter.Deselect();
                    cam.target = selecter.transform;
                    return;
                }

                Vector2 input = InputManager.GetMovement();
                int width = map.GetMap().width;
                int size = width * map.GetMap().height;
                if (input.x != 0)
                {
                    int next = location + Mathf.RoundToInt(input.x);
                    UpdateSelected(location / width + next % width);
                }
                else if (input.y != 0)
                {
                    int next = location + Mathf.RoundToInt(input.y) * map.GetMap().width;
                    if (next < 0) next += size;
                    if (next >= size) next -= size;
                    UpdateSelected(next);
                }
            }
        }

        private void UpdateSelected(int loc)
        {
            location = loc;
            cam.target = map.GetTile(loc).transform;
        }
    }
}