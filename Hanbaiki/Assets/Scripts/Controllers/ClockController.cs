using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ClockController : MonoBehaviour
    {
        private void Update()
        {
            TimeService.Update(Time.deltaTime);
        }
    }
}