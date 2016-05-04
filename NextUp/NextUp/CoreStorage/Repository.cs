using System.Collections.Generic;

namespace NextUp.CoreStorage
{
    public class Repository
    {
        public IDictionary<object, ISet<ValueHolder>> ScenarioToValues { get; } = new Dictionary<object, ISet<ValueHolder>>();

        public IDictionary<ValueHolder, ValueHolder> Values { get; } = new Dictionary<ValueHolder, ValueHolder>();

        public void AddValueHolder(ValueHolder valueHolder)
        {
            Values[valueHolder] = valueHolder;
            ISet<ValueHolder> values;
            if (!ScenarioToValues.TryGetValue(valueHolder.Scenario, out values))
            {
                values = new HashSet<ValueHolder>();
                ScenarioToValues[valueHolder.Scenario] = values;
            }
            values.Add(valueHolder);
        }

        public void RemoveValueHolder(ValueHolder valueHolder)
        {
            Values.Remove(valueHolder);
            var values = ScenarioToValues[valueHolder.Scenario];
            values.Remove(valueHolder);
            if (values.Count == 0)
            {
                ScenarioToValues.Remove(valueHolder.Scenario);
            }
        }

        public void RemoveValueHolders(object scenario)
        {
            ISet<ValueHolder> vals;
            if (ScenarioToValues.TryGetValue(scenario, out vals))
            {
                foreach (var val in vals)
                {
                    Values.Remove(val);
                }
                ScenarioToValues.Remove(scenario);
            }
        }

        public ValueHolder GetValueHolder(object owner, string property, object scenario)
        {
            var query = new ValueHolder(owner, property, scenario);
            ValueHolder result;
            if (!Values.TryGetValue(query, out result)) return null;
            return result;
        }

        public void Execute(object scenario)
        {
            ISet<ValueHolder> valueHolders;
            if (ScenarioToValues.TryGetValue(scenario, out valueHolders))
            {
                foreach (var valueHolder in valueHolders)
                {
                    valueHolder.Execute();
                }
            }
        }
    }
}
