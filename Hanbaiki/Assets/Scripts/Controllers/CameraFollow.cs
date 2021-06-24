using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float damping = 0.125f;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position, damping * Time.deltaTime);
        }

    }
}