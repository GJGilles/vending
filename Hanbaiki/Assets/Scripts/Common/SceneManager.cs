using UnityEngine;

namespace Assets.Scripts
{
    public static class SceneManager
    {
        public enum SceneEnum
        {
            None = -1,
            Exit,
            Game,
        }

        private static SceneEnum next = SceneEnum.None;

        public static SceneEnum GetNext()
        {
            return next;
        }

        public static void SetNext(SceneEnum scene)
        {
            next = scene;
        }

        public static void Load(SceneEnum scene = SceneEnum.None)
        {
            if (scene == SceneEnum.None)
                scene = next;

            if (scene == SceneEnum.Exit)
                Application.Quit();
                
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
            next = SceneEnum.None;
        }
    }
}