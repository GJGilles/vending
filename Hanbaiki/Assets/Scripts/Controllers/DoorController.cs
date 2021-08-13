using Assets.Scripts.Controllers.Character;
using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DoorController : SelectableController
    {
        public GameObject room;

        public override void Select(PlayerController player)
        {
            room.SetActive(!room.activeSelf);
        }
    }
}