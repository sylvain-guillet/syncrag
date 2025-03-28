using Xunit;

namespace SyncRAG.Models.Tests;

public class FolderTests
{
    [Fact]
    public void FolderConstructor_ValidPath_SetsProperties()
    {
        // Arrange
        string path = "/path/to/folder";
        string description = "Test folder";
        string version = "1.0.0";

        // Act
        var folder = new SyncRAG.Models.Directory(path, description, version);

        // Assert
        Assert.Equal("folder", folder.Name);
        Assert.Equal(path, folder.Path);
        Assert.Equal("Directory", folder.Type);
        Assert.Equal(description, folder.Description);
        Assert.Equal(version, folder.Version);
    }
    
    [Fact]
    public void AddEntry_ValidEntry_AddsEntry()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file = new SyncRAG.Models.File("/path/to/file.txt", "Test file", "1.0.0");

        // Act
        folder.AddEntry(file);

        // Assert
        Assert.True(folder.ContainsEntry(file));
    }
    
    [Fact]
    public void RemoveEntry_ValidEntry_RemovesEntry()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file = new SyncRAG.Models.File("/path/to/file.txt", "Test file", "1.0.0");
        folder.AddEntry(file);

        // Act
        folder.RemoveEntry(file);

        // Assert
        Assert.False(folder.ContainsEntry(file));
    }
    
    [Fact]
    public void ClearEntries_EntriesExist_ClearsEntries()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file1 = new SyncRAG.Models.File("/path/to/file1.txt", "Test file 1", "1.0.0");
        var file2 = new SyncRAG.Models.File("/path/to/file2.txt", "Test file 2", "1.0.0");
        folder.AddEntry(file1);
        folder.AddEntry(file2);

        // Act
        folder.ClearEntries();

        // Assert
        Assert.True(folder.IsEmpty);
    }
    
    [Fact]
    public void ContainsEntry_EntryExists_ReturnsTrue()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file = new SyncRAG.Models.File("/path/to/file.txt", "Test file", "1.0.0");
        folder.AddEntry(file);

        // Act
        bool contains = folder.ContainsEntry(file);

        // Assert
        Assert.True(contains);
    }
    
    [Fact]
    public void ContainsEntry_EntryDoesNotExist_ReturnsFalse()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file1 = new SyncRAG.Models.File("/path/to/file1.txt", "Test file 1", "1.0.0");
        var file2 = new SyncRAG.Models.File("/path/to/file2.txt", "Test file 2", "1.0.0");
        folder.AddEntry(file1);

        // Act
        bool contains = folder.ContainsEntry(file2);

        // Assert
        Assert.False(contains);
    }
    
    [Fact]
    public void GetEntry_EntryExists_ReturnsEntry()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file = new SyncRAG.Models.File("/path/to/file.txt", "Test file", "1.0.0");
        folder.AddEntry(file);

        // Act
        var entry = folder.GetEntry("file.txt");

        // Assert
        Assert.Equal(file, entry);
    }
    
    [Fact]
    public void GetEntry_EntryDoesNotExist_ReturnsNull()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file = new SyncRAG.Models.File("/path/to/file.txt", "Test file", "1.0.0");
        folder.AddEntry(file);

        // Act
        var entry = folder.GetEntry("nonexistent.txt");

        // Assert
        Assert.Null(entry);
    }
    
    [Fact]
    public void GetEntry_IndexIsValid_ReturnsEntry()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file1 = new SyncRAG.Models.File("/path/to/file1.txt", "Test file 1", "1.0.0");
        var file2 = new SyncRAG.Models.File("/path/to/file2.txt", "Test file 2", "1.0.0");
        folder.AddEntry(file1);
        folder.AddEntry(file2);

        // Act
        var entry = folder.GetEntry(1);

        // Assert
        Assert.Equal(file2, entry);
    }
    
    [Fact]
    public void GetEntry_IndexIsOutOfRange_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file1 = new SyncRAG.Models.File("/path/to/file1.txt", "Test file 1", "1.0.0");
        folder.AddEntry(file1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => folder.GetEntry(2));
    }
    
    [Fact]
    public void Count_EntriesExist_ReturnsCount()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file1 = new SyncRAG.Models.File("/path/to/file1.txt", "Test file 1", "1.0.0");
        var file2 = new SyncRAG.Models.File("/path/to/file2.txt", "Test file 2", "1.0.0");
        folder.AddEntry(file1);
        folder.AddEntry(file2);

        // Act
        int count = folder.Count;

        // Assert
        Assert.Equal(2, count);
    }
    
    [Fact]
    public void IsEmpty_NoEntries_ReturnsTrue()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);

        // Act
        bool isEmpty = folder.IsEmpty;

        // Assert
        Assert.True(isEmpty);
    }
    
    [Fact]
    public void IsEmpty_EntriesExist_ReturnsFalse()
    {
        // Arrange
        string path = "/path/to/folder";
        var folder = new SyncRAG.Models.Directory(path);
        var file = new SyncRAG.Models.File("/path/to/file.txt", "Test file", "1.0.0");
        folder.AddEntry(file);

        // Act
        bool isEmpty = folder.IsEmpty;

        // Assert
        Assert.False(isEmpty);
    }
    
}