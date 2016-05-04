using NextUp.CoreStorage;
using NextUp.MultiScenario;

namespace NextUp.Helpers
{
    public static class PropertyHelper
    {
        public static void SetValue(this ScenarioManager sm, object owner, string property, object value)
        {
            if (sm.IsChangingScenario) return;
            var query = new ValueHolder(owner, property, sm.CurrentScenario);
            ValueHolder valueHolder;
            if (!sm.Values.TryGetValue(query, out valueHolder))
            {
                valueHolder = query;
                sm.AddValueHolder(valueHolder);
            }
            valueHolder.Value = value;
        }
    }
}
