using NextUp.CoreStorage;
using System.Collections.Generic;

namespace NextUp.MultiScenario
{
    public class XpScenario
    {
        public XpScenario Parent { get; set; }

        public IList<XpScenario> Children { get; set; }

        public void Propagate(ScenarioManager sm)
        {
            RemoveValueHoldersOfChildren(sm, this);
        }

        private void RemoveValueHoldersOfChildren(ScenarioManager sm, XpScenario sc)
        {
            foreach (var c in sc.Children)
            {
                sm.RemoveValueHolders(c);
                RemoveValueHoldersOfChildren(sm, c);
            }
        }
    }
}
