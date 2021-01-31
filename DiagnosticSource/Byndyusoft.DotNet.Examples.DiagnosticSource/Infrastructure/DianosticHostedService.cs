using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Infrastructure
{
    public class DianosticHostedService: IHostedService
    {
        private readonly IEnumerable<IDiagnosticObserver> _observers;

        public DianosticHostedService(IEnumerable<IDiagnosticObserver> observers)
        {
            _observers = observers;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var observer in _observers)
            {
                observer.Start();
            }
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (var observer in _observers)
            {
                observer.Stop();
            }

            return Task.CompletedTask;
        }
    }
}