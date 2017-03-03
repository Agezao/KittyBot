using MyBot.MessageHandlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Connector;
using System.Xml;

namespace MyBot.MessageHandlers.Implementations
{
    public class CatMessageHandler : IMessageHandler
    {
        public Activity Handle(Activity message)
        {
            string source = "http://thecatapi.com/api/images/get?format=xml&results_per_page=1&type=gif";
            XmlDocument catsXml = new XmlDocument();
            catsXml.Load(source);
            var randomCatUrl = catsXml.GetElementsByTagName("url")[0].InnerText;

            // The ~Attachment~ way
            /*message.Attachments = new List<Attachment>();
            message.Attachments.Add(new Attachment
            {
                ContentType = "image/gif",
                ContentUrl = randomCatUrl,
                Name = "Gato Aleatório",
                ThumbnailUrl = randomCatUrl
            });

            message.Text = $"![cat]({randomCatUrl})"; */

            // The ~Plain Text~ way
            return message.CreateReply($"{randomCatUrl}", "pt-br");
        }
    }
}