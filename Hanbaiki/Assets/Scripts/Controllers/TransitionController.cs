using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class TransitionController : MonoBehaviour
    {
        public float entryTime = 0.5f;
        public float exitTime = 0.5f;

        protected float currentTime = 0f;

        private void Start()
        {
            currentTime = entryTime;
        }

        private void Update()
        {
            if (SceneService.IsDiff())
            {
                if (currentTime >= exitTime)
                {
                    SceneService.Load();
                }

                currentTime += Time.unscaledDeltaTime;
            }
            else if (currentTime >= 0)
            {
                currentTime -= Time.unscaledDeltaTime;
            }
        }
    }
}