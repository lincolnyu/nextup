using System;
using System.Reflection;
using NextUp.Helpers;

namespace NextUp.ValueChanges
{
    public class ValueChangeItem : IEquatable<ValueChangeItem>
    {
        public ValueChangeItem(object ownerObject, string propertyName, object space)
        {
            OwnerObject = ownerObject;
            PropertyName = propertyName;
            Space = space;
        }

        public object OwnerObject { get; }

        public string PropertyName { get; }

        public object Space { get; }

        public object Value { get; set; }

        public bool Equals(ValueChangeItem other)
        {
            return OwnerObject == other.OwnerObject && PropertyName == other.PropertyName && Space == other.Space;
        }

        public override bool Equals(object obj)
        {
            return (obj as ValueChangeItem)?.Equals(this) ?? false;
        }

        public override int GetHashCode()
        {
            return HashingHelper.GetHashCodeForItems(OwnerObject, PropertyName, Space);
        }

        public void Execute()
        {
            var prop = OwnerObject.GetType().GetRuntimeProperty(PropertyName);
            prop.SetValue(OwnerObject, Value);
        }
    }
}
