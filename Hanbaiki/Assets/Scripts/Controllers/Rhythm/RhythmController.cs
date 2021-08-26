using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class RhythmController : MonoBehaviour
    {
        public float oRadius;
        public float iRadius;

        public float range;
        public float tolerance;
        public NoteController noteObject;
        public List<AudioSource> sources = new List<AudioSource>();

        private int mistakes = 0;
        private int index = 0;
        private float time = 0f;

        public UnityEvent<int> OnDone = new UnityEvent<int>();

        private RhythmObject rhythm;
        private List<NoteController> current = new List<NoteController>();

        private void Start()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
            PlayerService.Lock();
        }

        private void OnDestroy()
        {
            PlayerService.Unlock();
        }

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

            if (index >= rhythm.notes.Count && current.Count == 0)
            {
                OnDone.Invoke(100 - (100 * mistakes) / rhythm.notes.Count);
                Destroy(gameObject);
            }

            MoveNotes();
        }

        public void Set(RhythmObject obj)
        {
            index = 0;
            time = -range;
            current = new List<NoteController>();

            rhythm = obj;
            for (int i = 0; i < sources.Count; i++)
            {
                if (i < obj.sounds.Count)
                    sources[i].clip = obj.sounds[i];
                else
                    sources[i].clip = null;
            }
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
                    sources[(int)dir].Play();
                    break;
                }
            }

        }

        private void MoveNotes()
        {
            for (int i = current.Count - 1; i >= 0; i--)
            {
                var n = current[i];
                if (n.GetTime() + tolerance < time)
                {
                    // Missed
                    mistakes++;
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