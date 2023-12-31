using System;
using VContainer.Unity;

namespace Roguelike_EventBus
{
    public abstract class BaseHandler<T> : IInitializable, IDisposable
    {
        protected EventBus EventBus { get; }

        protected BaseHandler(EventBus eventBus)
        {
            EventBus = eventBus;
        }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<T>(HandleEvent);
        }

        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<T>(HandleEvent);
        }

        protected abstract void HandleEvent(T evt);
    }
}