using System;

namespace Surging.Core.CPlatform.EventBus.Events
{
    /// <summary>
    /// 集成事件
    /// </summary>
	public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public IntegrationEvent(IntegrationEvent integrationEvent)
        {
            Id = integrationEvent.Id;
            CreationDate = integrationEvent.CreationDate;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
    }
}
