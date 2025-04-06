namespace Razdor.Shared.Threading;

public sealed class MutexScope : IMutexScope
{
    private bool _disposed;
    private Mutex _mutex;

    public MutexScope(Mutex mutex)
    {
        _disposed = false;
        _mutex = mutex;
    }

    public Mutex Mutex => _mutex;

    public void Dispose()
    {
        _mutex.ReleaseMutex();
        _disposed = true;
    }
}