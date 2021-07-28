﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildRecipeListController : MonoBehaviour
    {
        public GameBuildController build;
        public ScrollListController list;

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private void Start()
        {
            var recipes = build.GetStation().recipes;
            for (int i = 0; i < recipes.Count; i++)
            {
                var inst = list.Add().GetComponent<GameBuildRecipeController>();
                inst.Set(recipes[i]);
            }
            list.GetItem(list.GetSelected()).GetComponent<GameBuildRecipeController>().SetHighlight(true);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.Fire1))
            {
                build.DoneRecipe(list.GetSelected());
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.Fire2))
            {
                build.Prev();
                return;
            }

            float diff = InputManager.GetVertAxis();
            coolRemain -= Time.deltaTime;
            if (diff != 0 && coolRemain <= 0)
            {
                list.GetItem(list.GetSelected()).GetComponent<GameBuildRecipeController>().SetHighlight(false);
                list.UpdateSelect(Mathf.RoundToInt(diff));
                list.GetItem(list.GetSelected()).GetComponent<GameBuildRecipeController>().SetHighlight(true);

                coolRemain = coolTime;
            }
        }
    }
}