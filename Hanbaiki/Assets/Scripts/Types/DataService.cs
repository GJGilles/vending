using System;
using System.Collections;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            var bf = new BinaryFormatter();
            bf.Serialize(fs, GetData());
        }

        protected void Load(string path)
        {
            var fs = File.OpenRead(path);
            var bf = new BinaryFormatter();
            SetData((T)bf.Deserialize(fs));
        }

        public DataService GetService()
        {
            return new DataService() { name = name, Save = Save, Load = Load };
        }
    }
}