using Assets.Scripts.Objects;
using PotatoTools;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class RhythmController : MonoBehaviour
    {
        public float oRadius;
        public float iRadius;

        public int range;
        public float speed;
        public float tolerance;
        public NoteController noteObject;

        [NonSerialized] public RhythmObject rhythm;

        private int index = 0;
        private float time = 0f;

        private List<NoteController> current = new List<NoteController>();

        private void Update()
        {
            time += Time.deltaTime;
            while (index < rhythm.notes.Count && rhythm.notes[index].time < time + range)
            {
                AddNote(rhythm.notes[index]);
                index++;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                ProcessButton(MoveDirection.Down);
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                ProcessButton(MoveDirection.Right);
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.X))
            {
                ProcessButton(MoveDirection.Left);
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.Y))
            {
                ProcessButton(MoveDirection.Up);
            }

            MoveNotes();
        }

        private void AddNote(RhythmNote note)
        {
            var inst = Instantiate(noteObject, transform);
            inst.Set(note, oRadius);
            current.Add(inst);
        }

        private void ProcessButton(MoveDirection dir)
        {
            for (int i = 0; i < current.Count; i++)
            {
                if (current[i].GetTime() - tolerance < time && current[i].GetDirection() == dir)
                {
                    // Success
                    Destroy(current[i].gameObject);
                    current.RemoveAt(i);
                    return;
                }
            }
            // Mistake
        }

        private void MoveNotes()
        {
            for (int i = current.Count - 1; i >= 0; i--)
            {
                var n = current[i];
                if (n.GetTime() + tolerance < time)
                {
                    // Missed
                    Destroy(n.gameObject);
                    current.RemoveAt(i);
                }
                else if (n.GetTime() <= time)
                {
                    n.MoveTo(iRadius);
                }
                else
                {
                    n.MoveTo(((n.GetTime() - time) / range) * (oRadius - iRadius) + iRadius);
                }
            }
        }
    }
}