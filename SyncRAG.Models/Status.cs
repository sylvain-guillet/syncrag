namespace SyncRAG.Models;

public enum Status
{
    NotSynchronized,
    Synchronized,
    Synchronizing,
    SynchronizedWithConflict,
    SynchronizedWithWarning,
    SynchronizedWithError,
    SynchronizedWithInfo
}