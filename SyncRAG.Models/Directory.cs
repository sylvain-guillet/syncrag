// ReSharper disable All

namespace SyncRAG.Models;

public class Directory : Entry
{
    private readonly List<Entry> _children;
    public IReadOnlyCollection<Entry> Children => _children.AsReadOnly();

    public Directory(string path, string description = "", string version = "", IEnumerable<Entry>? entries = null) : base(
        System.IO.Path.GetFileNameWithoutExtension(path) ?? throw new ArgumentException($"Invalid directory path : {path}"), path, "Directory", description, version)
    {
        _children = entries?.ToList() ?? new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        if (entry == null) throw new ArgumentNullException(nameof(entry));
        _children.Add(entry);
    }

    public void RemoveEntry(Entry entry)
    {
        if (entry == null) throw new ArgumentNullException(nameof(entry));
        _children.Remove(entry);
    }

    public void ClearEntries()
    {
        _children.Clear();
    }

    public bool ContainsEntry(Entry entry)
    {
        if (entry == null) throw new ArgumentNullException(nameof(entry));
        return _children.Contains(entry);
    }

    public bool ContainsEntry(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));
        return _children.Any(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Entry? GetEntry(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));
        return _children.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Entry? GetEntry(int index)
    {
        if (index < 0 || index >= _children.Count) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        return _children[index];
    }

    public int Count => _children.Count;
    public bool IsEmpty => _children.Count == 0;
}