using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildTypeController : MonoBehaviour
    {
        public GameBuildController build;

        public void SelectStation()
        {
            build.DoneType(TileTypeEnum.Station);
        }
        public void SelectInput()
        {
            build.DoneType(TileTypeEnum.Input);
        }
        public void SelectOutput()
        {
            build.DoneType(TileTypeEnum.Output);
        }
    }
}