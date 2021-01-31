using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Infrastructure
{
    public abstract class DiagnosticObserverBase :
        IDiagnosticObserver,
        IObserver<DiagnosticListener>,
        IObserver<KeyValuePair<string, object>>
    {
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();
        private readonly string _listenerName;
        private IDisposable _subscribtion;

        protected DiagnosticObserverBase(string listenerName)
        {
            _listenerName = listenerName;
        }
        
        void IObserver<DiagnosticListener>.OnNext(DiagnosticListener diagnosticListener)
        {
            if (diagnosticListener.Name == _listenerName) _subscriptions.Add(diagnosticListener.Subscribe(this));
        }

        void IObserver<DiagnosticListener>.OnCompleted()
        {
            _subscriptions.ForEach(x => x.Dispose());
            _subscriptions.Clear();
        }

        void IObserver<DiagnosticListener>.OnError(Exception error) { }

        void IObserver<KeyValuePair<string, object>>.OnCompleted() { }

        void IObserver<KeyValuePair<string, object>>.OnError(Exception error) { }

        void IObserver<KeyValuePair<string, object>>.OnNext(KeyValuePair<string, object> value)
        {
            OnNext(value.Key, value.Value);
        }

        protected abstract void OnNext(string eventName, object payload);
        
        public void Start()
        {
           _subscribtion = DiagnosticListener.AllListeners.Subscribe(this);
        }

        public void Stop()
        {
           _subscribtion?.Dispose();
           _subscribtion = null;
        }
    }
}