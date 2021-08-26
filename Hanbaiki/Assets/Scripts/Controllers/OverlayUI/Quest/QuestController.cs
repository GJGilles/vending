using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class QuestController : MonoBehaviour
    {
        public TMPro.TMP_Text title;
        public RectTransform goalArea;
        public GoalController goalObj;

        private QuestObject quest;
        private List<GoalController> goals = new List<GoalController>();

        private void OnDestroy()
        {
            QuestService.OnGoalChange.RemoveListener(UpdateAll);
        }

        public void Set(QuestObject q)
        {
            quest = q;
            AddAll();
            QuestService.OnGoalChange.AddListener(UpdateAll);
        }

        public int GetHeight()
        {
            return 0;
        }

        private void UpdateAll(int code)
        {
            if (code != quest.GetHashCode()) return;

            RemoveAll();
            AddAll();
        }

        private void AddAll()
        {
            int height = 0;
            foreach (var g in quest.goals)
            {
                var inst = Instantiate(goalObj, goalArea);

                inst.Set(g);

                var r = inst.GetComponent<RectTransform>();
                r.anchoredPosition = new Vector2(0, height);
                height -= Mathf.RoundToInt(r.rect.height);
                goals.Add(inst);
            }
        }

        private void RemoveAll()
        {
            foreach (var g in goals)
            {
                Destroy(g.gameObject);
            }
            goals = new List<GoalController>();
        }
    }
}