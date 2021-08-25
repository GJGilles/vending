using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class NoteController : MonoBehaviour
    {
        public RectTransform rt;
        public UnityEngine.UI.Image spr;
        public List<Sprite> sprites = new List<Sprite>();

        private RhythmNote note;

        public float GetTime()
        {
            return note.time;
        }

        public MoveDirection GetDirection()
        {
            return note.direction;
        }

        public void Set(RhythmNote n, float dist)
        {
            note = n;
            rt.anchoredPosition = GetVector() * dist;
            spr.sprite = sprites[(int)n.direction];
        }

        public void MoveTo(float dist)
        {
            rt.anchoredPosition = GetVector() * dist;
        }

        private Vector2 GetVector()
        {
            switch (note.direction)
            {
                case MoveDirection.Left:
                    return Vector2.left;
                case MoveDirection.Up:
                    return Vector2.up;
                case MoveDirection.Right:
                    return Vector2.right;
                case MoveDirection.Down:
                    return Vector2.down;
                default:
                    return Vector2.zero;
            }
        }
    }
}