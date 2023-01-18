namespace DndHelper.App.ApplicationClasses
{
    public enum MessageTypes
    {
        SelectionMade,
        PageCompleted
    };

    public static class MessageSender
    {
        public static void SendSelectionMade(object sender, CharacterAttributes attribute, object value)
        {
            MessagingCenter.Send(sender, MessageTypes.SelectionMade.ToString(),
                new AttributeSelection(attribute, value));
        }

        public static void SendPageCompleted<TModel>(BindableObject sender)
        {
            MessagingCenter.Send(sender, MessageTypes.PageCompleted.ToString(),
                typeof(TModel).Name);
        }
    }
}
