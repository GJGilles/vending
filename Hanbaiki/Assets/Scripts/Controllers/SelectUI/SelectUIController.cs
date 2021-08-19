using PotatoTools;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public abstract class SelectUIController<T> : MonoBehaviour
    {
        [NonSerialized] public Action<T> OnDone = _ => { };
        [NonSerialized] public Action OnCancel = () => { };

        protected T select = default(T);

        public float coolTime = 0.3f;
        protected float coolRemain = 0;

        protected virtual void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                gameObject.SetActive(false);
                OnDone.Invoke(select);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                gameObject.SetActive(false);
                OnCancel.Invoke();
                return;
            }

            coolRemain -= Time.deltaTime;
        }
    }
}