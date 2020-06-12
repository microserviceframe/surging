namespace Surging.Core.CPlatform.EventBus.Events
{
    /// <summary>
    /// 事件上下文
    /// </summary>
    public class EventContext : IntegrationEvent
    {
        public object Content { get; set; }

        public long Count { get; set; }

        public string Type { get; set; }
    }
}
