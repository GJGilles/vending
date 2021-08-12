using Assets.Scripts.Common;
using Assets.Scripts.Service;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers
{
    public class PauseController : ActionList
    {
        [NonSerialized] public UnityEvent OnClose = new UnityEvent();

        protected override void Start()
        {
            base.Start();

            GetComponent<Canvas>().worldCamera = Camera.current;

            Time.timeScale = 0;

            actions.Add(Save);
            actions.Add(Title);
            actions.Add(Exit);
        }

        protected override void Update()
        {
            base.Update();

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            Time.timeScale = 1;
            OnClose.Invoke();
        }

        private void Save()
        {
            FileService.Save();
        }

        private void Title()
        {
            SceneService.SetNext(SceneEnum.Title);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}