namespace Razdor.Shared.Threading;

public static class MutexExtension
{
    public static IMutexScope WaitScope(this Mutex mutex)
    {
        mutex.WaitOne();
        return new MutexScope(mutex);
    }
}