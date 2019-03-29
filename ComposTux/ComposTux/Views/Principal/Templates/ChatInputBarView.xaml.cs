using System;
using System.Collections.Generic;
using ComposTux.ViewModels.Principal;
using Xamarin.Forms;

namespace ComposTux.Views.Principal.Templates
{
    public partial class ChatInputBarView : ContentView
    {
        public ChatInputBarView()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.SetBinding(HeightRequestProperty, new Binding("Height", BindingMode.OneWay, null, null, null, chatTextInput));
            }
        }
        public void Handle_Completed(object sender, EventArgs e)
        {
            //chatTextInput.Focus();
            (this.Parent.Parent.BindingContext as ChatPageViewModel).OnSendCommand.Execute(null);
            if(chatTextInput.Focus())
            {
                chatTextInput.Focus();
            }
            else
            {
                chatTextInput.Unfocus();
            }
        }

        public void UnFocusEntry()
        {
            chatTextInput?.Unfocus();
        }
    }
}
