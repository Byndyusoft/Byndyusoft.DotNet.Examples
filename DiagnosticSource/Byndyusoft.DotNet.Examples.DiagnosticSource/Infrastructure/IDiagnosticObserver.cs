namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Infrastructure
{
    public interface IDiagnosticObserver
    {
        void Start();
        void Stop();
    }
}