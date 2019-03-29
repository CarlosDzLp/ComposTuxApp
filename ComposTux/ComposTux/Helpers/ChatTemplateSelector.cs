using System;
using ComposTux.Models.Chat;
using ComposTux.Views.Principal.Templates;
using Xamarin.Forms;

namespace ComposTux.Helpers
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
                return null;

            if(messageVm.User==App.User)
            {
                return incomingDataTemplate;
            }
            else
            {
                return outgoingDataTemplate;
            }
            //return (messageVm.User == App.User) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}
