using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Service
{
    public enum SceneEnum
    {
        Title,
        Loading,
        Credits,

        One,
        Two,
        Three,
        Four,
        Five,
        Six, 
        Seven, 
        Eight, 
        Nine,
        Ten
    }

    public static class SceneService
    {
        private static SceneEnum current = SceneEnum.Title;
        private static SceneEnum next = SceneEnum.Title;

        public static void SetNext(SceneEnum scene)
        {
            next = scene; 
        }

        public static void Load()
        {
            SceneManager.LoadScene((int)next);
            current = next;
        }

        public static bool IsDiff()
        {
            return current != next;
        }
    }
}