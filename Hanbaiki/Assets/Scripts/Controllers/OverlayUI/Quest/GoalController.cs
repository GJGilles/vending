using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GoalController : MonoBehaviour
    {
        public TMPro.TMP_Text text;

        public void Set(QuestGoal goal)
        {
            if (goal is QuestSellGoal)
            {
                var g = (QuestSellGoal)goal;
                text.text = $"Sell {g.number} {g.item.title} in {g.location.name}";
            }
            else if (goal is QuestTalkGoal)
            {
                var g = (QuestTalkGoal)goal;
                text.text = $"Talk to {g.character.name}";
            }
            else if (goal is QuestGiveGoal)
            {
                var g = (QuestGiveGoal)goal;
                text.text = $"Give {g.number} {g.item.title} to {g.character.name}";
            }
            else
            {
                text.text = "";
            }
        }
    }
}