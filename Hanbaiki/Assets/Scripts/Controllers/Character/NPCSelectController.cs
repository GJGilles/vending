using Assets.Scripts.Dialog;
using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class NPCSelectController : SelectableController
    {
        [NonSerialized] public CharacterObject character;
        public DialogController dialog;

        public override void Select(PlayerController player)
        {
            var inst = Instantiate(dialog);
            inst.dialog = character.dialogs[character.state];
            inst.OnClose.AddListener(() => player.isLocked = false);
            player.isLocked = true;
        }
    }
}