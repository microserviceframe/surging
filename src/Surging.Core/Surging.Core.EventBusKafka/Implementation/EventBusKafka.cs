using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.EventBus;
using Surging.Core.CPlatform.EventBus.Events;
using Surging.Core.CPlatform.EventBus.Implementation;
using System;
using System.Threading.Tasks;

namespace Surging.Core.EventBusKafka.Implementation
{
    public class EventBusKafka : IEventBus, IDisposable
    {
        private readonly ILogger<EventBusKafka> _logger;
		private readonly IEventBusSubscriptionsManager _subsManager;
		private readonly IKafkaPersisterConnection _producerConnection;
		private readonly IKafkaPersisterConnection _consumerConnection;

		public event EventHandler OnShutdown;

        public EventBusKafka(ILogger<EventBusKafka> logger, IEventBusSubscriptionsManager subsManager, CPlatformContainer serviceProvider)
        {
            _logger = logger;
			_producerConnection = serviceProvider.GetInstances<IKafkaPersisterConnection>(KafkaConnectionType.Producer.ToString());
			_consumerConnection = serviceProvider.GetInstances<IKafkaPersisterConnection>(KafkaConnectionType.Consumer.ToString());
			_subsManager = subsManager;
            _subsManager.OnEventRemoved += SubsManager_OnEventRemoved;
        }

        private void SubsManager_OnEventRemoved(object sender, ValueTuple<string, string> tuple)
        {
            if (!_consumerConnection.IsConnected)
            {
                _consumerConnection.TryConnect();
            }

            using (var channel = _consumerConnection.CreateConnect() as IConsumer<string, string>)
            {
                channel.Unsubscribe();
                if (_subsManager.IsEmpty)
                {
                    _consumerConnection.Dispose();
                }
            }
        }

        public void Dispose()
        {
            _producerConnection.Dispose();
            _consumerConnection.Dispose();
        }

        public void Publish(IntegrationEvent @event)
        {
            if (!_producerConnection.IsConnected)
            {
                _producerConnection.TryConnect();
            }
            var eventName = @event.GetType().Name;
            var body = JsonConvert.SerializeObject(@event);
            var policy = Policy.Handle<KafkaException>()
               .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
               {
                   _logger.LogWarning(ex.ToString());
               });

            var conn = _producerConnection.CreateConnect() as IProducer<string, string>;
            policy.Execute(() =>
            {
                //ValueTuple<string, Message<Null, string>> msg = (eventName, new Message<Null, string>() { Key = null, Value = body });
                var msg = new Message<string, string>() { Key = eventName, Value = body };
                
                conn.ProduceAsync(eventName, msg).GetAwaiter().GetResult();
            });
        }

        public void Subscribe<T, TH>(Func<TH> handler) where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var containsKey = _subsManager.HasSubscriptionsForEvent<T>();
            if (!containsKey)
            {
                //_subsManager.GetHandlersForEvent(eventName).Append(ConsumerClient_OnMessage);
                //新增
                //_subsManager.AddSubscription<T, TH>(handler, eventName);
                var channel = _consumerConnection.CreateConnect() as IConsumer<string, string>;                
                //channel.MemberId = eventName;
                //channel.OnMessage += ConsumerClient_OnMessage;
                channel.Subscribe(eventName);
            }
            _subsManager.AddSubscription<T, TH>(handler, null);
        }

        public void Unsubscribe<T, TH>() where TH : IIntegrationEventHandler<T>
        {
            _subsManager.RemoveSubscription<T, TH>();
        }

        private void ConsumerClient_OnMessage(object sender, Message<string, string> e)
        {
            ProcessEvent(e.Key, e.Value).Wait();
        }
        //private void ConsumerClient_OnMessage(object sender, Message<Null, string> e)
        //{
        //    ProcessEvent(e.Topic, e.Value).Wait();
        //}

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_subsManager.HasSubscriptionsForEvent(eventName))
            {
                var eventType = _subsManager.GetEventTypeByName(eventName);
                var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                var handlers = _subsManager.GetHandlersForEvent(eventName);

                foreach (var handlerfactory in handlers)
                {
                    try
                    {
                        var handler = handlerfactory.DynamicInvoke();
                        var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
