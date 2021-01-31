using System;
using System.Collections.Generic;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Infrastructure;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Diagnostics
{
    public abstract class OrderDiagnosticObserver : DiagnosticObserverBase
    {
        protected OrderDiagnosticObserver() : base(OrderDiagnosticListener.ListenerName)
        {
        }

        protected override void OnNext(string eventName, object payload)
        {
            if (_methods.TryGetValue(eventName, out var method) == false)
                return;
            method(this, (CreateOrderPayload)payload);
        }

        private readonly Dictionary<string, Action<OrderDiagnosticObserver, CreateOrderPayload>> _methods =
            new Dictionary<string, Action<OrderDiagnosticObserver, CreateOrderPayload>>
            {
                { OrderDiagnosticListener.EventNames.Creating, (observer, value) => observer.OnCreating(value) },
                { OrderDiagnosticListener.EventNames.Created, (observer, value) => observer.OnCreated(value) },
                { OrderDiagnosticListener.EventNames.CreationError, (observer, value) => observer.OnCreationError(value) }
            };

        protected virtual void OnCreating(CreateOrderPayload payload) { }

        protected virtual void OnCreated(CreateOrderPayload payload) { }

        protected virtual void OnCreationError(CreateOrderPayload payload) { }
    }
}