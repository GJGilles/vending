﻿using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class MoneyController : MonoBehaviour
    {
        public TMPro.TMP_Text money;

        void Update()
        {
            money.text = "$" + PlayerService.GetMoney();
        }
    }
}