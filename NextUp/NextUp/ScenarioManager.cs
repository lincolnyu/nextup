using System.Collections.Generic;
using NextUp.ValueChanges;

namespace NextUp
{
    public class ScenarioManager
    {
        private IDictionary<object, ISet<ValueChangeItem>> _scenarioToChanges;

        public IDictionary<object, ISet<ValueChangeItem>> ScenarioToChanges
            => _scenarioToChanges ?? (_scenarioToChanges = new Dictionary<object, ISet<ValueChangeItem>>());

        public void Execute(object scenario)
        {
            ISet<ValueChangeItem> changes;
            if (ScenarioToChanges.TryGetValue(scenario, out changes))
            {
                foreach (var change in changes)
                {
                    change.Execute();
                }
            }
        }
    }
}
