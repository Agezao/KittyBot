using Microsoft.Bot.Connector;

namespace MyBot.MessageHandlers.Interfaces
{
    public interface IMessageHandler
    {
        Activity Handle(Activity message);
    }
}
