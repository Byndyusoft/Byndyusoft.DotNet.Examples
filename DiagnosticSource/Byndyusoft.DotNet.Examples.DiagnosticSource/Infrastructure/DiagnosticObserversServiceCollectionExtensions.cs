using Byndyusoft.DotNet.Examples.DiagnosticSource.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiagnosticObserversServiceCollectionExtensions
    {
        public static IServiceCollection AddDiagnosticObserver<TDiagnosticObserver>(this IServiceCollection services)
            where TDiagnosticObserver : class, IDiagnosticObserver
        {
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IDiagnosticObserver, TDiagnosticObserver>());

            return services;
        }
    }
}