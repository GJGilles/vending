using Assets.Scripts.Types;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class PlayerService
    {
        private static int money = 0;

        public static void AddMoney(int amount)
        {
            money += amount;
        }
    }
}