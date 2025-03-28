namespace SyncRAG.Models;

public class SynchronizedItem
{
    public FileSystemInfo LocalItem { get; }
    public Entry RemoteItem { get; }

    public Status Status { get; private set; }

    private readonly List<SynchronizedItem> _children;
    public IReadOnlyCollection<SynchronizedItem> Children => _children.AsReadOnly();
    
    public bool IsSynchronized => Status == Status.Synchronized && _children.All(c => c.Status == Status.Synchronized);

    protected SynchronizedItem(FileSystemInfo localItem, Entry remoteItem, Status status = Status.NotSynchronized,
        IEnumerable<SynchronizedItem>? children = null)
    {
        _children = children?.ToList() ?? new List<SynchronizedItem>();
        LocalItem = localItem;
        RemoteItem = remoteItem;
        Status = status;
    }

    public SynchronizedItem(FileInfo localFile, File remoteItem, Status status = Status.NotSynchronized) : this(localFile, (Entry)remoteItem, status)
    {
    }

    public SynchronizedItem(DirectoryInfo localDirectory, Directory remoteItem, Status status = Status.NotSynchronized) : this(localDirectory, (Entry)remoteItem, status)
    {
    }
    
    public void AddChild(params SynchronizedItem[] children)
    {
        if (children == null) throw new ArgumentNullException(nameof(children));
        foreach (var child in children)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            _children.Add(child);
        }
    }
    public void RemoveChild(params SynchronizedItem[] children)
    {
        if (children == null) throw new ArgumentNullException(nameof(children));
        foreach (var child in children)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            _children.Remove(child);
        }
    }
    
    public void ClearChildren()
    {
        _children.Clear();
    }
    public bool ContainsChild(SynchronizedItem child)
    {
        if (child == null) throw new ArgumentNullException(nameof(child));
        return _children.Contains(child);
    }
    
    public void Synchronized()
    {
        Status = Status.Synchronized;
        foreach (var child in _children)
        {
            child.Synchronized();
        }
    }
    
    public void SynchronizedWithConflict()
    {
        Status = Status.SynchronizedWithConflict;
        foreach (var child in _children)
        {
            child.SynchronizedWithConflict();
        }
    }
    public void SynchronizedWithWarning()
    {
        Status = Status.SynchronizedWithWarning;
        foreach (var child in _children)
        {
            child.SynchronizedWithWarning();
        }
    }
    public void SynchronizedWithError()
    {
        Status = Status.SynchronizedWithError;
        foreach (var child in _children)
        {
            child.SynchronizedWithError();
        }
    }
    public void SynchronizedWithInfo()
    {
        Status = Status.SynchronizedWithInfo;
        foreach (var child in _children)
        {
            child.SynchronizedWithInfo();
        }
    }
    public void NotSynchronized()
    {
        Status = Status.NotSynchronized;
        foreach (var child in _children)
        {
            child.NotSynchronized();
        }
    }
    public void SetStatus(Status status)
    {
        Status = status;
        foreach (var child in _children)
        {
            child.SetStatus(status);
        }
    }
    public void Synchronizing()
    {
        Status = Status.Synchronizing;
        foreach (var child in _children)
        {
            child.Synchronizing();
        }
    }
    
}