using Assets.Scripts.Controllers.Character;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public abstract class SelectableController : MonoBehaviour
    {
        public abstract void Select(PlayerController player);
    }
}