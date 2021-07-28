using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildTileController : MonoBehaviour
    {
        public CameraFollow cam;
        public GameMapController map;
        public GameSelectionController selecter;

        private int location = 0;

        private void Update()
        {
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

        private void UpdateSelected(int loc)
        {
            location = loc;
            cam.target = map.GetTile(loc).transform;
        }
    }
}