using Services.Contracts;
using System;
using System.Windows;

namespace Services.Implementations
{
    public class MessageBoxMessage : IMessageUI
    {

        public MessageBoxMessage(string _message,string _titel)
        {
            Message = _message;
            Titel = _titel;
        }

        public void MessageShow()
        {
            MessageBox.Show(Message, Titel);
        }

        public string Message { get; set; }
        public string Titel { get; set; }
    }
}
