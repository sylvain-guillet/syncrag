using Xunit;

namespace SyncRAG.Models.Tests;

public class FileTests
{
    [Fact]
    public void FileConstructor_ValidPath_SetsProperties()
    {
        // Arrange
        string path = "C:\\path\\to\\file.txt";
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

    [Fact]
    public void FileConstructor_InvalidPath_ThrowsArgumentException()
    {
        // Arrange
        string path = "invalid_path";
        string description = "Test file";
        string version = "1.0.0";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new SyncRAG.Models.File(path, description, version));
    }
}