﻿using PotatoTools;
using PotatoTools.Character;
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