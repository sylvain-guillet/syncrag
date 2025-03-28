using Xunit;

namespace SyncRAG.Models.Tests;

public class FileTests
{
    [Fact]
    public void FileConstructor_ValidPath_SetsProperties()
    {
        // Arrange
        string path = "/path/to/file.txt";
        string description = "Test file";
        string version = "1.0.0";

        // Act
        var file = new SyncRAG.Models.File(path, description, version);

        // Assert
        Assert.Equal("file.txt", file.Name);
        Assert.Equal(path, file.Path);
        Assert.Equal(".txt", file.Type);
        Assert.Equal(description, file.Description);
        Assert.Equal(version, file.Version);
    }
}