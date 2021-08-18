using Assets.Scripts.Service;
using PotatoTools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class QuestAreaController : MonoBehaviour
    {
        public RectTransform questArea;
        public QuestController questObj;

        private bool visible = true;
        private List<QuestController> quests = new List<QuestController>();

        private void Start()
        {
            AddAll();
            QuestService.OnQuestChange.AddListener(UpdateAll);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.R2))
            {
                visible = !visible;
            }

            var pos = GetComponent<RectTransform>();
            if (visible && pos.anchoredPosition.x > 0)
            {
                if (CommonAnimation.DampedMove(pos.anchoredPosition, new Vector2(0, 0), out Vector2 c))
                {
                    pos.anchoredPosition = new Vector2(0, 0);
                }
                else
                {
                    pos.anchoredPosition = c;
                }
            }
            if (!visible && pos.anchoredPosition.x < pos.rect.width)
            {
                if (CommonAnimation.DampedMove(pos.anchoredPosition, new Vector2(pos.rect.width, 0), out Vector2 c))
                {
                    pos.anchoredPosition = new Vector2(pos.rect.width, 0);
                }
                else
                {
                    pos.anchoredPosition = c;
                }
            }

            if (!visible) return;
        }

        private void OnDestroy()
        {
            QuestService.OnQuestChange.RemoveListener(UpdateAll);
        }

        private void UpdateAll()
        {
            RemoveAll();
            AddAll();
        }

        private void RemoveAll()
        {
            foreach (var q in quests)
            {
                Destroy(q.gameObject);
            }
            quests = new List<QuestController>();
        }

        private void AddAll()
        {
            int height = 0;
            var items = QuestService.GetCurrent();
            foreach (var q in items)
            {
                var inst = Instantiate(questObj, questArea);
                inst.Set(q);
                inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height);
                height -= inst.GetHeight();

                quests.Add(inst);
            }
        }
    }
}