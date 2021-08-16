using PotatoTools;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogObject", order = 7)]
    public class DialogUnlockObject : DialogObject
    {
        public UnlockData unlocks = new UnlockData();
    }
}