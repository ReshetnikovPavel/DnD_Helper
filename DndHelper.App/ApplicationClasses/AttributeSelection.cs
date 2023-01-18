namespace DndHelper.App.ApplicationClasses
{
    public class AttributeSelection

    {
        public CharacterAttributes Attribute { get; }
        public object Value { get; }

        public AttributeSelection(CharacterAttributes attribute, object value)
        {
            Attribute = attribute;
            Value = value;
        }
    }
}
