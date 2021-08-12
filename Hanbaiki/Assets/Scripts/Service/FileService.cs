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

        private static string GetPath(string slot, string name)
        {
            return Application.persistentDataPath + "/" + slot + "/" + name;
        }

        public static bool Save()
        {
            foreach (var s in services)
            {
                s.Save(GetPath(slot.ToString(), s.name));
            }

            return true;
        }

        public static bool Load()
        {
            if (!File.Exists(GetPath(slot.ToString(), "")))
            {
                return false;
            }

            foreach (var s in services)
            {
                s.Load(GetPath(slot.ToString(), s.name));
            }

            return true;
        }
    }
}