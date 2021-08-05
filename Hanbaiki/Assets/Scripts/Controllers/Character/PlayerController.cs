using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class PlayerController : CharacterController
    {
        public CharacterInventoryController inventory;

        protected void Update()
        {
            Vector2 input = InputManager.GetMovement();
            SetMove(Mathf.RoundToInt(input.x));
        }
    }
}