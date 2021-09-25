using PotatoTools;
using PotatoTools.Character;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DoorController : SelectableController
    {
        public BuildingController building;
        public bool inside = true;

        public override void Select()
        {
            if (inside)
            {
                building.Exit();
            }
            else
            {
                building.Enter();
            }
        }
    }
}