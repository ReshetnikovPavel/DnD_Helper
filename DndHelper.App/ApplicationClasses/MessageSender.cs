using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public enum MessageTypes
    {
        SelectionMade,
        PageCompleted
    };

    public static class MessageSender
    {
        public static void SendSelectionMade(object sender, string property, object value)
        {
            MessagingCenter.Send(sender, MessageTypes.SelectionMade.ToString(),
                new Selection(property, value));
        }

        public static void SendPageCompleted<TModel>(BindableObject sender)
        {
            MessagingCenter.Send(sender, MessageTypes.PageCompleted.ToString(),
                typeof(TModel).Name);
        }
    }
}
