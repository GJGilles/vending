using Assets.Scripts.Types;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Scripts.Service
{
    [Serializable]
    public class JSONData
    {
    }

    public static class FileService
    {
        [DllImport("__Internal")]
        private static extern void Save(string str);

        [DllImport("__Internal")]
        private static extern string Load();


        public static void SaveData()
        {
            JSONData data = new JSONData()
            {
            };
            try
            {
                Save(JsonUtility.ToJson(data));
            }
            catch (Exception) { }
        }

        public static void LoadData()
        {
            JSONData data = JsonUtility.FromJson<JSONData>(Load());
        }

        public static void DeleteData()
        {
            Save("");
        }

        public static bool IsData()
        {
            try
            {
                JsonUtility.FromJson<JSONData>(Load());
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}