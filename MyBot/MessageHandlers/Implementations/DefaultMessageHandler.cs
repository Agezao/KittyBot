using MyBot.MessageHandlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Connector;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using System.Configuration;
using Newtonsoft.Json;

namespace MyBot.MessageHandlers.Implementations
{
    public class DefaultMessageHandler : IMessageHandler
    {
        public Activity Handle(Activity message)
        {
            string sResponse = "Não entendi. Por que não tenta: 'gato', 'kitty'...";

            using (var wb = new WebClient())
            {
                var data = new { query = message.Text, lang = "pt-br", sessionId = Guid.NewGuid().ToString() };

                wb.Headers.Add("Authorization", ConfigurationManager.AppSettings["ApiAiToken"]);
                wb.Headers[HttpRequestHeader.ContentType] = "application/json";

                var response = wb.UploadString(ConfigurationManager.AppSettings["ApiAiUrl"], "POST", JsonConvert.SerializeObject(data));
                var parsedResponse = (dynamic)JsonConvert.DeserializeObject(response);

                sResponse = parsedResponse.result.speech;
            }

            return message.CreateReply(sResponse, "pt-br");
        }
    }
}