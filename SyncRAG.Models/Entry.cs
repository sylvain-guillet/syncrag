namespace SyncRAG.Models;

public abstract class Entry
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Version { get; set; }
    
    protected Entry(string name, string path, string type, string description, string version)
    {
        Name = name;
        Path = path;
        Type = type;
        Description = description;
        Version = version;
    }
    
}