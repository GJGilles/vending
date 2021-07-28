using System.Collections.Generic;
using UnityEditor;

namespace Assets.Scripts
{
    public static class AssetLoader
    {
        public static List<T> LoadObjects<T>() where T : UnityEngine.Object
        {
            List<T> result = new List<T>();

            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).ToString(), new string[] { "Assets/Objects" });
            foreach (string g in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(g);
                result.Add((T)AssetDatabase.LoadAssetAtPath(path, typeof(T)));
            }

            return result;
        }
    }
}