using System;
using EasyNetQ;
using MessagesExample;

namespace SubscriberExample {
    class Program {
        static void Main(string[] args) {
            var bus = RabbitHutch.CreateBus("amqp://lplnqgia:AGXzy06s5Pt7Z9zgPJshyNofOqRES5-h@roedeer.rmq.cloudamqp.com/lplnqgia");
            bus.Subscribe<Message>("subscriber01", Handle);
        }

        private static void Handle(Message message) {
            Console.WriteLine($"{message.MessageGuid}: {message.Content}");
        }
    }
}
