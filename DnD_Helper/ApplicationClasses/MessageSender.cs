using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public enum MessageTypes
    {
        AttributeSelected,
        AbilityScoreSelected,
        PageCompleted
    };

    public static class MessageSender
    {
        public static void SendAttributeSelected<TAttribute>(object sender, string selectedValue)
        {
            MessagingCenter.Send(sender, MessageTypes.AttributeSelected.ToString(),
                new Selection(nameof(TAttribute), selectedValue));
        }

        public static void SendAttributeSelected(object sender, string attribute, string selectedValue)
        {
            MessagingCenter.Send(sender, MessageTypes.AttributeSelected.ToString(),
                new Selection(attribute, selectedValue));
        }

        public static void SendPageCompleted<TModel>(BindableObject sender)
        {
            MessagingCenter.Send<BindableObject, string>(sender, MessageTypes.PageCompleted.ToString(),
                typeof(TModel).Name);
        }
    }
}
