using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;

namespace Surging.Core.EventBusKafka.Implementation
{
    public abstract class KafkaPersistentConnectionBase : IKafkaPersisterConnection
    {
        private readonly ILogger<KafkaPersistentConnectionBase> _logger;
        private readonly IEnumerable<KeyValuePair<string, string>> _config;
        object sync_root = new object();

        public KafkaPersistentConnectionBase(ILogger<KafkaPersistentConnectionBase> logger, IEnumerable<KeyValuePair<string, string>> config)
        {
            _logger = logger;
            _config = config;
        }


        public abstract bool IsConnected { get; }

        public bool TryConnect()
        {
            _logger.LogInformation("Kafka Client is trying to connect");

            lock (sync_root)
            {
                var policy = Policy.Handle<KafkaException>()
                    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                        _logger.LogWarning(ex.ToString());
                    }
                );

                policy.Execute(() =>
                {
                    Connection(_config).Invoke();
                });

                if (IsConnected)
                {
                    return true;
                }
                else
                {
                    _logger.LogCritical("FATAL ERROR: Kafka connections could not be created and opened");
                    return false;
                }
            }
        }

        public abstract Action Connection(IEnumerable<KeyValuePair<string, string>> options);
        public abstract object CreateConnect();
        public abstract void Dispose();
    }
}
