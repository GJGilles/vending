using Assets.Scripts.Common;
using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Title
{
    public class TitleController : ActionList
    {
        protected override void Start()
        {
            base.Start();
            actions.Add(NewGame);
            actions.Add(LoadGame);
            actions.Add(Credits);
        }

        private void NewGame()
        {
            SceneService.SetNext(SceneEnum.One);
        }

        private void LoadGame()
        {
            FileService.Load();
            SceneService.SetNext(SceneEnum.One);
        }

        private void Credits()
        {
            SceneService.SetNext(SceneEnum.Credits);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}