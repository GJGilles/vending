using Assets.Scripts.Types;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Service
{

    public static class FileService
    {
        private static int slot = 0;
        private static List<DataService> services = new List<DataService>();

        static FileService()
        {
            services.Add(new ItemService.Data().GetService());
            services.Add(new CharacterService.Data().GetService());
        }

        private static string GetPath(string slot)
        {
            return Application.persistentDataPath + "/" + slot + "/";
        }

        public static bool Save()
        {
            Directory.CreateDirectory(GetPath(slot.ToString()));

            foreach (var s in services)
            {
                s.Save(GetPath(slot.ToString()) + s.name);
            }

            return true;
        }

        public static bool Load()
        {
            if (!Directory.Exists(GetPath(slot.ToString())))
            {
                return false;
            }

            foreach (var s in services)
            {
                s.Load(GetPath(slot.ToString()) + s.name);
            }

            return true;
        }
    }
}