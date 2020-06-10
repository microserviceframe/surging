using System;
using System.Collections.Generic;
using System.IO;
using Confluent.Kafka;

using Microsoft.Extensions.Logging;

namespace Surging.Core.EventBusKafka.Implementation
{
    public class KafkaProducerPersistentConnection : KafkaPersistentConnectionBase
    {
        private IProducer<string, string> _connection;
        private readonly ILogger<KafkaProducerPersistentConnection> _logger;
        private readonly ISerializer<string> _stringSerializer;
        bool _disposed;

        public KafkaProducerPersistentConnection(ILogger<KafkaProducerPersistentConnection> logger) : base(logger, AppConfig.KafkaProducerConfig)
        {
            _logger = logger;
            _stringSerializer = Serializers.Utf8;
        }

        public override bool IsConnected => _connection != null && !_disposed;

        public override Action Connection(IEnumerable<KeyValuePair<string, string>> options)
        {
            return () =>
            {
                var producerBuilder = new ProducerBuilder<string, string>(options);
                producerBuilder.SetErrorHandler(OnConnectionException);
                _connection = producerBuilder.Build();
                //_connection = new ProducerBuilder<Null, string>(options);
                //_connection.OnError += OnConnectionException;
            };
        }

        public override object CreateConnect()
        {
            TryConnect();
            return _connection;
        }

		public override void Dispose()
		{
			if (_disposed) return;

			_disposed = true;

			try
			{
				_connection.Dispose();
			}
			catch (IOException ex)
			{
				_logger.LogCritical(ex.ToString());
			}
		}

		private void OnConnectionException(object sender, Error error)
        {
            if (_disposed) return;

            _logger.LogWarning($"A Kafka connection throw exception.info:{error} ,Trying to re-connect...");

            TryConnect();
        }
    }
}
