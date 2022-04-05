using AssetManagement.DTO.Common;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Consumer
{
    class Program
    {
        public static async Task<bool> EmailSend(MailBody mailBody)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("betul.ylmmz28@gmail.com", "Betul123.")
                })
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("betul.ylmmz28@gmail.com");
                    mailBody.MailList.ForEach(x => mailMessage.To.Add(x));
                    mailMessage.Subject = "Depoya ürün eklendi!";
                    mailMessage.Body = mailBody.Message;
                    await smtp.SendMailAsync(mailMessage);
                }
                mailBody.MailList.ForEach(x => Console.WriteLine(x + " adresine mail gönderildi."));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata:" + ex.Message);
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Kuyruk dinleniyor...");

            bool result = false;
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

                    var consumer = new EventingBasicConsumer(channel);

                    channel.QueueBind(
                        queue: "AssetAdded",
                        exchange: "asset.exchange",
                        routingKey: "newasset");

                    channel.BasicConsume(
                        queue: "AssetAdded",
                        autoAck: true,
                        consumer: consumer);

                    consumer.Received += (object sender, BasicDeliverEventArgs ea) =>
                    {
                        try
                        {
                            var mail = JsonConvert.DeserializeObject<MailBody>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                            Console.WriteLine("Kuyruktan bir mesaj alındı ve işleniyor");
                            result = EmailSend(mail).Result;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hata: " + ex.Message);
                        }
                        if (result)
                        {
                            Console.WriteLine("Kuyruktaki mesaj başarıyla işlendi...");
                        }
                    };
                    Console.ReadLine();
                }
            }
        }
    }
}
