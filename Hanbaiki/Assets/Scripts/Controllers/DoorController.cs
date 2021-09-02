using PotatoTools;
using PotatoTools.Character;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DoorController : SelectableController
    {
        public GameObject room;

        public override void Select()
        {
            room.SetActive(!room.activeSelf);
        }
    }
}