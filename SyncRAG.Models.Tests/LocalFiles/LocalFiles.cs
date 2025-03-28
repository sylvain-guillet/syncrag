namespace SyncRAG.Models.Tests.LocalFiles;

public static class LocalFiles
{
    public static string MyFilePath => "LocalFiles/MyFile.txt";
    public static FileInfo MyFileInfo => new FileInfo(MyFilePath);
}