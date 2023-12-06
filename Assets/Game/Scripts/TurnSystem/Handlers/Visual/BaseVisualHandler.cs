using System;
using Roguelike_EventBus;
using VContainer.Unity;

namespace Roguelike_EventBus
{
    public abstract class BaseVisualHandler<T> : IInitializable, IDisposable
    {
        protected readonly EventBus _eventBus;
        protected readonly VisualPipeline _visualPipeline;
        protected readonly VisualValueService _valueService;

        protected BaseVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, VisualValueService valueService)
        {
            _eventBus = eventBus;
            _visualPipeline = visualPipeline;
            _valueService = valueService;
        }


        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<T>(HandleEvent);
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<T>(HandleEvent);
        }

        protected abstract void HandleEvent(T evt);
    }
}