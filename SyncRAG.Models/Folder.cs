namespace SyncRAG.Models;

public class Directory : Entry
{
    public Directory(string path, string description = "", string version = "") : base(
        System.IO.Path.GetDirectoryName(path) ?? throw new ArgumentException($"Invalid directory path : {path}"), path, "Directory", description, version)
    {
    }
}