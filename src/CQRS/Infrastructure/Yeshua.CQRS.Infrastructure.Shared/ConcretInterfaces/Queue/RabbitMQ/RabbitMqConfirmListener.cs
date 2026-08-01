using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.ConcretInterfaces.Queue.RabbitMQ
{
    public class RabbitMqConfirmListener
    {
        public RabbitMqConfirmListener(IChannel channel)
        {
            channel.BasicAcksAsync += OnAck;
            channel.BasicNacksAsync += OnNack;
            channel.BasicReturnAsync += OnReturn;
        }

        private Task OnAck(object sender, BasicAckEventArgs e)
        {
            Console.WriteLine($"ACK recebido: {e.DeliveryTag}");
            return Task.CompletedTask;
        }

        private Task OnNack(object sender, BasicNackEventArgs e)
        {
            Console.WriteLine($"NACK recebido: {e.DeliveryTag}");
            return Task.CompletedTask;
        }

        private Task OnReturn(object sender, BasicReturnEventArgs e)
        {
            Console.WriteLine($"Mensagem não roteada!");
            return Task.CompletedTask;
        }
    }
}
