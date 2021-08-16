using PotatoTools;
using PotatoTools.Character;

namespace Assets.Scripts.Controllers
{
    public class BuildDeskController : SelectableController
    {
        public BuildController build;

        public override void Select(PlayerController player)
        {
            build.gameObject.SetActive(true);
        }
    }
}