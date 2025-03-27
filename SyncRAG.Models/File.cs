namespace SyncRAG.Models;

public class File : Entry
{
    public File(string path, string description, string version) : base(System.IO.Path.GetFileName(path), path, System.IO.Path.GetExtension(path), description, version)
    {
    }
}