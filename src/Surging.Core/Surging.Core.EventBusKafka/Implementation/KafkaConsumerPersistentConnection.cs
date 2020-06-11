using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace Surging.Core.EventBusKafka.Implementation
{
    public class KafkaConsumerPersistentConnection : KafkaPersistentConnectionBase
    {
        private readonly ILogger<KafkaConsumerPersistentConnection> _logger;
        private ConcurrentBag<IConsumer<string, string>> _consumerClients;
        private IConsumer<string, string> _consumerClient;
        private readonly IDeserializer<string> _stringDeserializer;
        bool _disposed;

        public KafkaConsumerPersistentConnection(ILogger<KafkaConsumerPersistentConnection> logger) : base(logger, AppConfig.KafkaConsumerConfig)
        {
            _logger = logger;
            _stringDeserializer = Deserializers.Utf8;// new StringDeserializer(Encoding.UTF8);
            _consumerClients = new ConcurrentBag<IConsumer<string, string>>();
        }

        public override bool IsConnected => _consumerClient != null && !_disposed;

        public override Action Connection(IEnumerable<KeyValuePair<string, string>> options)
        {
            return () =>
            {
                var consumerBuilder = new ConsumerBuilder<string, string>(options);
                consumerBuilder.SetLogHandler(OnConsumeError);
                consumerBuilder.SetErrorHandler(OnConnectionException);
                _consumerClient = consumerBuilder.Build();
                //_consumerClient.OnConsumeError += OnConsumeError;
                //_consumerClient.OnError += OnConnectionException;
                _consumerClients.Add(_consumerClient);
            };
        }

        public void Listening(TimeSpan timeout)
        {
            if (!IsConnected)
            {
                TryConnect();
            }
            while (true)
            {
                foreach (var client in _consumerClients)
                {
                    client.Consume(timeout);

                    var consumeResult = client.Consume((int)timeout.TotalMilliseconds);
					if (consumeResult.IsPartitionEOF)
					{
                        continue;
                    }
					if (consumeResult.Offset % 5 == 0)
					{
                        client.Commit(consumeResult);
                        //var committedOffsets = client.Commit();//.CommitAsync(msg).Result;
					}
					//if (!client.Consume(out Message<Null, string> msg, (int)timeout.TotalMilliseconds))
					//{
					//    continue;
					//}
					//if (msg.Offset % 5 == 0)
					//{
					//    var committedOffsets = client.CommitAsync(msg).Result;
					//}
				}
            }
        }

        public override object CreateConnect()
        {
            TryConnect();
            return _consumerClient;
        }

        private void OnConsumeError(object sender, LogMessage e)
        {
            if (_disposed) return;

            if(e.Level == SyslogLevel.Error || e.Level == SyslogLevel.Warning)
            {
                _logger.LogWarning($"An error occurred during consume the message; Name:'{e.Name}'," + $"Message:'{e.Message}', Reason:'{e.Facility}'.");
            }
            //var message = e.Deserialize<Null, string>(null, _stringDeserializer);
            //if (_disposed) return;

            //_logger.LogWarning($"An error occurred during consume the message; Topic:'{e.Topic}'," +
            //    $"Message:'{message.Value}', Reason:'{e.Error}'.");

            TryConnect();
        }

        private void OnConnectionException(object sender, Error error)
        {
            if (_disposed) return;

            _logger.LogWarning($"A Kafka connection throw exception.reason:{error.Reason};info:{error} ,Trying to re-connect...");

            TryConnect();
        }

        public override void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            try
            {
                //Close为新增
                _consumerClient.Close();
                _consumerClient.Dispose();
            }
            catch (IOException ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }
    }
}
