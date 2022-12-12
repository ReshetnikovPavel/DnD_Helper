using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public enum Messages
    {
        AttributeSelected,
        AbilityScoreSelected,
        PageCompleted
    };

    public static class MessageSender
    {
        public static void SendAttributeSelected<TAttribute>(object sender, string selectedName)
        {
            MessagingCenter.Send(sender, Messages.AttributeSelected.ToString(),
                new Selection(nameof(TAttribute), selectedName));
        }

        public static void SendPageCompleted<TModel>(BindableObject sender)
        {
            MessagingCenter.Send<BindableObject, string>(sender, Messages.PageCompleted.ToString(),
                nameof(TModel));
        }
    }
}
