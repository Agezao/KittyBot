using Microsoft.Bot.Connector;
using MyBot.MessageHandlers.Implementations;
using MyBot.MessageHandlers.Interfaces;
using System.Linq;

namespace MyBot.Business
{
    public class MessageHandleBusiness
    {
        public MessageHandleBusiness() {}

        public Activity Handle(Activity receivedAction)
        {
            IMessageHandler handler;

            if (receivedAction.Text.Split(' ').Where(s => new string[] { "cat", "gato", "gatos", "kitty", "gatinho" }.Contains(s.ToLower())).Count() > 0)
                handler = new CatMessageHandler();
            else
                handler = new DefaultMessageHandler();

            return handler.Handle(receivedAction);
        }
    }
}