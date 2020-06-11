using System.Collections.Generic;

namespace Surging.Core.EventBusKafka.Configurations
{
    public class KafkaOptions
    {
        public string Servers { get; set; } = "localhost:9092";

        public int MaxQueueBuffering { get; set; } = 10;

        public int MaxSocketBlocking { get; set; } = 10;

        public bool EnableAutoCommit { get; set; } = false;

        public bool LogConnectionClose { get; set; } = false;

        public int Timeout { get; set; } = 100;

        public int CommitInterval { get; set; } = 1000;

        public OffsetResetMode OffsetReset { get; set; } = OffsetResetMode.Earliest;

        public int SessionTimeout { get; set; } = 36000;

        public string Acks { get; set; } = "all";

        public int Retries { get; set; }

        public int Linger { get; set; } = 1;

        public string GroupID { get; set; } = "suringdemo";

        public KafkaOptions Value => this;

        public IEnumerable<KeyValuePair<string, string>> GetConsumerConfig()
        {
            var configs = new List<KeyValuePair<string, string>>();
            configs.Add(new KeyValuePair<string, string>("bootstrap.servers", Servers));
            configs.Add(new KeyValuePair<string, string>("queue.buffering.max.ms", MaxQueueBuffering.ToString()));
            configs.Add(new KeyValuePair<string, string>("socket.blocking.max.ms", MaxSocketBlocking.ToString()));
            configs.Add(new KeyValuePair<string, string>("enable.auto.commit", EnableAutoCommit.ToString()));
            configs.Add(new KeyValuePair<string, string>("log.connection.close", LogConnectionClose.ToString()));
            configs.Add(new KeyValuePair<string, string>("auto.commit.interval.ms", CommitInterval.ToString()));
            configs.Add(new KeyValuePair<string, string>("auto.offset.reset", OffsetReset.ToString().ToLower()));
            configs.Add(new KeyValuePair<string, string>("session.timeout.ms", SessionTimeout.ToString()));
            configs.Add(new KeyValuePair<string, string>("group.id", GroupID));
            return configs;
        }

        public IEnumerable<KeyValuePair<string, string>> GetProducerConfig()
        {
            var configs = new List<KeyValuePair<string, string>>();
            configs.Add(new KeyValuePair<string, string>("bootstrap.servers", Servers));
            configs.Add(new KeyValuePair<string, string>("acks", Acks));
            configs.Add(new KeyValuePair<string, string>("retries", Retries.ToString()));
            configs.Add(new KeyValuePair<string, string>("linger.ms", Linger.ToString()));
            return configs;
        }
    }
}
