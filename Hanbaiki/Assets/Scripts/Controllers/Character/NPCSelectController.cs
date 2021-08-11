using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class NPCSelectController : SelectableController
    {
        [NonSerialized] public CharacterObject character;

        public override void Select(PlayerController player)
        {
            throw new System.NotImplementedException();
        }
    }
}