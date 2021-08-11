using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class AssetLoader
    {
        public static List<T> LoadObjects<T>() where T : UnityEngine.Object
        {
#if UNITY_EDITOR
            List<T> result = new List<T>();
            string[] guids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).ToString(), new string[] { "Assets/Objects" });
            foreach (string g in guids)
            {
                string path = UnityEditor.AssetDatabase.GUIDToAssetPath(g);
                result.Add((T)UnityEditor.AssetDatabase.LoadAssetAtPath(path, typeof(T)));
            }
            return result;
#else
            return new List<T>(Resources.FindObjectsOfTypeAll<T>());
#endif
        }
    }
}