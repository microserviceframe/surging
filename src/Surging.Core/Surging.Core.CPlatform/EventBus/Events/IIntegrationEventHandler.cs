using System.Threading.Tasks;

namespace Surging.Core.CPlatform.EventBus.Events
{
    /// <summary>
    /// 集成事件处理器接口
    /// </summary>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    {
        Task Handle(TIntegrationEvent @event);
    }

    /// <summary>
    /// 抽象基础集成事件处理器
    /// </summary>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    public abstract class BaseIntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler<TIntegrationEvent>
    {
        public abstract Task Handle(TIntegrationEvent @event);

        public virtual async Task Handled(EventContext context)
        {
            await Task.CompletedTask;
        }
    }

    /// <summary>
    /// 集成事件处理器接口
    /// </summary>
    public interface IIntegrationEventHandler
    {
    }
}
