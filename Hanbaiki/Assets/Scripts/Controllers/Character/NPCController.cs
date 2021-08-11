using Assets.Scripts.Inventory;
using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class NPCController : CharacterMovementController
    {
        public NPCSelectController selectable;
        public CharacterObject character;

        private void Start()
        {
            selectable.character = character;
            anim.anim.runtimeAnimatorController = character.animator;
        }
    }
}