using NextUp.Helpers;
using System.Collections.Generic;

namespace NextUp.MultiScenario
{
    public class XpScenario
    {
        public XpScenario Parent { get; set; }

        public IList<XpScenario> Children { get; } = new List<XpScenario>();

        public void AddChild(XpScenario child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public void RemoveChild(XpScenario child)
        {
            Children.Remove(child);
            child.Parent = null;
        }

        public void SetValue(ScenarioManager sm, object owner, string property, object value)
        {
            owner.SetValue(sm, property, value);
            Propagate(sm);
        }

        public bool TryGetValue<T>(ScenarioManager sm, object owner, string property, out T value)
        {
            var sc = this;
            var succ = false;
            value = default(T);
            for (; sc != null && !(succ = owner.TryGetValue(sm, sc, property, out value)); sc = sc.Parent) ;
            return succ;
        }

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
