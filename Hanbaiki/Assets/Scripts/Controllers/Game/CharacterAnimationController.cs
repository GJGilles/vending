using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private enum CharacterAnimEnum
        {
            IsWalk,
            Direction
        }

        private Animator Animator() { return GetComponent<Animator>(); }

        public void SetWalk(bool walking)
        {
            Animator().SetBool(CharacterAnimEnum.IsWalk.ToString(), walking);
        }

        public void SetDirection(int direction)
        {
            Animator().SetInteger(CharacterAnimEnum.Direction.ToString(), direction);
        } 
    }
}