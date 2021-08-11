using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ClockController : MonoBehaviour
    {
        public TMPro.TMP_Text date;
        public TMPro.TMP_Text time;

        private void Update()
        {
            TimeService.Update(Time.deltaTime);
            date.text = TimeService.GetDate();
            time.text = TimeService.GetTime();
        }
    }
}