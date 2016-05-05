using NextUp.CoreStorage;
using NextUp.MultiScenario;

namespace NextUp.Helpers
{
    public static class PropertyHelper
    {
        public static void SetValue(this object owner, ScenarioManager sm, string property, object value)
        {
            var query = new ValueHolder(owner, property, sm.CurrentScenario);
            ValueHolder valueHolder;
            if (!sm.Values.TryGetValue(query, out valueHolder))
            {
                valueHolder = query;
                sm.AddValueHolder(valueHolder);
            }
            valueHolder.Value = value;
        }

        public static bool TryGetValue<T>(this object owner, ScenarioManager sm, string property, out T value)
        {
            return owner.TryGetValue(sm, sm.CurrentScenario, property, out value);
        }

        public static bool TryGetValue<T>(this object owner, ScenarioManager sm, 
            object scenario, string property, out T value)
        {
            var query = new ValueHolder(owner, property, scenario);
            ValueHolder valueHolder;
            if (!sm.Values.TryGetValue(query, out valueHolder))
            {
                value = default(T);
                return false;
            }
            value = (T)valueHolder.Value;
            return true;
        }
    }
}
