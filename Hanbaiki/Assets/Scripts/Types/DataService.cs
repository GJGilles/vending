using System;
using System.Collections;
using UnityEngine;
using System.IO;
using Apex.Serialization;

namespace Assets.Scripts.Types
{
    public class DataService
    {
        public string name;
        public Action<string> Save;
        public Action<string> Load;
    }

    public abstract class DataService<T>
    {
        protected abstract string name { get; }
        protected abstract T GetData();
        protected abstract void SetData(T data);

        protected void Save(string path)
        {
            var fs = File.OpenWrite(path);
            var bs = Binary.Create(new Settings());
            bs.Write(GetData(), fs);
        }

        protected void Load(string path)
        {
            var fs = File.OpenRead(path);
            var bs = Binary.Create(new Settings());
            SetData(bs.Read<T>(fs));
        }

        public DataService GetService()
        {
            return new DataService() { name = name, Save = Save, Load = Load };
        }
    }
}