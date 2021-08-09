using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float damping = 0.125f;
        public int ppu = 32;

        private Vector3 pos;

        private void Start()
        {
            pos = transform.position;
        }

        private void Update()
        {
            pos = Vector3.Lerp(pos, target.position, damping * Time.deltaTime);
            transform.position = new Vector3(RoundToPixel(pos.x), RoundToPixel(pos.y)); ;
        }

        private float RoundToPixel(float num)
        {
            return Mathf.Round(num * ppu) / ppu;
        }

    }
}