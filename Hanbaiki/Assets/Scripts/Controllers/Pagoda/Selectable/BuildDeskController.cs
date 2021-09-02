using PotatoTools;
using PotatoTools.Character;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildDeskController : SelectableController
    {
        public SelectBuildController build;

        public override void Select()
        {
            build.gameObject.SetActive(true);
        }
    }
}