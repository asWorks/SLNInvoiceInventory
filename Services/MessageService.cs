using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class MessageToUIService
    {
       // IMessageUI _Message;
       public static void Message(IMessageUI Message)
        {
            Message.MessageShow();
        }

    }
}
