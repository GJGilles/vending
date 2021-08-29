using PotatoTools;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogUnlockObject", order = 7)]
    public class DialogUnlockObject : DialogObject
    {
        public UnlockData unlocks = new UnlockData();
    }
}