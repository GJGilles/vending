using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class CreditsController : MonoBehaviour
    {
        void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                SceneService.SetNext(SceneEnum.Title);
            }
        }
    }
}