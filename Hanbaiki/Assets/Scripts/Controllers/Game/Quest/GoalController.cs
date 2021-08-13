using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game.Quest
{
    public class GoalController : MonoBehaviour
    {
        public TMPro.TMP_Text text;

        public void Set(QuestGoal goal)
        {
            text.text = $"Sell {goal.number} {goal.item.name} In {goal.location.name}";
        }

        public void Set (CharacterState state)
        {
            text.text = $"Talk to {state.character.name}";
        }
    }
}