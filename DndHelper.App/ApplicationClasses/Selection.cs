namespace DndHelper.App.ApplicationClasses
{
    internal class Selection
    {
        public string Property { get; }
        public object Value { get; }

        public Selection(string property, object value)
        {
            Property = property;
            Value = value;
        }
    }
}
