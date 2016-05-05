using System;
using System.Reflection;
using NextUp.Helpers;

namespace NextUp.CoreStorage
{
    public class ValueHolder : IEquatable<ValueHolder>
    {
        public ValueHolder(object ownerObject, string propertyName, object scenario)
        {
            OwnerObject = ownerObject;
            PropertyName = propertyName;
            Scenario = scenario;
        }

        public object OwnerObject { get; }

        public string PropertyName { get; }

        public object Scenario { get; }

        public object Value { get; set; }

        public bool Equals(ValueHolder other)
        {
            return OwnerObject == other.OwnerObject && PropertyName == other.PropertyName && Scenario == other.Scenario;
        }

        public override bool Equals(object obj)
        {
            return (obj as ValueHolder)?.Equals(this) ?? false;
        }

        public override int GetHashCode()
        {
            return HashingHelper.GetHashCodeForItems(OwnerObject, PropertyName, Scenario);
        }

        /// <summary>
        ///  Apply this value item
        /// </summary>
        /// <remarks>
        ///  With lazy loading and caching, this is not used
        /// </remarks>
        public void Apply()
        {
            var prop = OwnerObject.GetType().GetRuntimeProperty(PropertyName);
            prop.SetValue(OwnerObject, Value);
        }
    }
}
