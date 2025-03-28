// ReSharper disable ConvertToPrimaryConstructor
namespace SyncRAG.Models;

public abstract class Entry
{
    public string Name { get; }
    public string Path { get; }
    public string Type { get; }
    public string Description { get; }
    public string Version { get; }
    
    protected Entry(string name, string path, string type, string description, string version)
    {
        Name = name;
        Path = path;
        Type = type;
        Description = description;
        Version = version;
    }
    
}