using AssetManagement.DTO.Common;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DAL.Publisher
{
    public class PublisherManager : IPublisherManager
    {
        private readonly ICommunicationDAL _communicationDAL;
        public PublisherManager(ICommunicationDAL communicationDAL)
        {
            _communicationDAL = communicationDAL;

        }
  
        public async Task Publish(string value)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://gzzyngys:YOCYQUGDuyvrrHEbgiJ-gw-CYH_tib88@shrimp.rmq.cloudamqp.com/gzzyngys");
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "AssetAdded", 
                        durable: true,   
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    channel.ExchangeDeclare(
                        exchange: "asset.exchange",
                        type: ExchangeType.Direct,
                        durable: true,
                        autoDelete: false,
                        arguments: null);
                    channel.QueueBind("AssetAdded", "asset.exchange", "newasset");
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    MailBody mailBody = new MailBody() { MailList = new List<string>() };
                    mailBody.Message = $"{value} ürün depoya eklendi!";

                    var users = _communicationDAL.GetAll();

                    users.ForEach(user => mailBody.MailList.Add(user.Description));

                    var byteBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailBody));

                    channel.BasicPublish(
                        exchange: "asset.exchange",
                        routingKey: "newasset",
                        basicProperties: properties,
                        body: byteBody);
                }
            }
        }
    }
}
