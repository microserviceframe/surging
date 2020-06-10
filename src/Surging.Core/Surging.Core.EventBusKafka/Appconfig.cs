using Microsoft.Extensions.Configuration;
using Surging.Core.EventBusKafka.Configurations;
using System.Collections.Generic;

namespace Surging.Core.EventBusKafka
{
    public class AppConfig
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static KafkaOptions Options { get; internal set; }

        private static IEnumerable<KeyValuePair<string, string>> _kafkaConsumerConfig;

        private static IEnumerable<KeyValuePair<string, string>> _kafkaProducerConfig;

        public static IEnumerable<KeyValuePair<string, string>> KafkaConsumerConfig
        {
            get
            {
                return _kafkaConsumerConfig;
            }
            internal set
            {
                _kafkaConsumerConfig = value;
            }
        }

        public static IEnumerable<KeyValuePair<string, string>> KafkaProducerConfig
        {
            get
            {
                return _kafkaProducerConfig;
            }
            internal set
            {
                _kafkaProducerConfig = value;
            }
        }
    }
}
