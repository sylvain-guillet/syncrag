using Xunit;

namespace SyncRAG.Models.Tests;

public class SynchronizedItemTests
{
    [Fact]
    public void SynchronizedItemConstructor_ValidParameters_SetsProperties()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var status = Status.Synchronized;
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;

        // Act
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Assert
        Assert.Equal(fileInfo, item.LocalItem);
        Assert.Equal(fileItem, item.RemoteItem);
        Assert.Equal(Status.NotSynchronized, item.Status);
    }
    
    [Fact]
    public void SynchronizedItemConstructor_StatusDefine_SetsProperties()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var status = Status.Synchronized;
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;

        // Act
        var item = new SynchronizedItem(fileInfo, fileItem,Status.Synchronized);

        // Assert
        Assert.Equal(fileInfo, item.LocalItem);
        Assert.Equal(fileItem, item.RemoteItem);
        Assert.Equal(Status.Synchronized, item.Status);
    }
    
    [Fact]
    public void AddChild_ValidChild_AddsChild()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);
        var childItem = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.AddChild(childItem);

        // Assert
        Assert.True(item.ContainsChild(childItem));
    }
    
    [Fact]
    public void RemoveChild_ValidChild_RemovesChild()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);
        var childItem = new SynchronizedItem(fileInfo, fileItem);
        item.AddChild(childItem);

        // Act
        item.RemoveChild(childItem);

        // Assert
        Assert.False(item.ContainsChild(childItem));
    }
    
    [Fact]
    public void ClearChildren_ChildrenExist_ClearsChildren()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);
        var childItem1 = new SynchronizedItem(fileInfo, fileItem);
        var childItem2 = new SynchronizedItem(fileInfo, fileItem);
        item.AddChild(childItem1, childItem2);

        // Act
        item.ClearChildren();

        // Assert
        Assert.False(item.ContainsChild(childItem1));
        Assert.False(item.ContainsChild(childItem2));
    }
    
    [Fact]
    public void Synchronized_ChangesStatusToSynchronized()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.Synchronized();

        // Assert
        Assert.Equal(Status.Synchronized, item.Status);
    }
    
    [Fact]
    public void SynchronizedWithConflict_ChangesStatusToSynchronizing()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.Synchronizing();

        // Assert
        Assert.Equal(Status.Synchronizing, item.Status);
    }
    
    [Fact]
    public void SynchronizedWithWarning_ChangesStatusToSynchronizedWithWarning()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.SynchronizedWithWarning();

        // Assert
        Assert.Equal(Status.SynchronizedWithWarning, item.Status);
    }
    
    [Fact]
    public void SynchronizedWithError_ChangesStatusToSynchronizedWithError()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.SynchronizedWithError();

        // Assert
        Assert.Equal(Status.SynchronizedWithError, item.Status);
    }
    
    [Fact]
    public void SynchronizedWithInfo_ChangesStatusToSynchronizedWithInfo()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.SynchronizedWithInfo();

        // Assert
        Assert.Equal(Status.SynchronizedWithInfo, item.Status);
    }
    
    [Fact]
    public void NotSynchronized_ChangesStatusToNotSynchronized()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.NotSynchronized();

        // Assert
        Assert.Equal(Status.NotSynchronized, item.Status);
    }
    
    [Fact]
    public void SetStatus_ValidStatus_SetsStatus()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);

        // Act
        item.SetStatus(Status.Synchronized);

        // Assert
        Assert.Equal(Status.Synchronized, item.Status);
    }
    
    [Fact]
    public void SetStatus_ValidStatus_ChangesStatusOfChildren()
    {
        // Arrange
        string remotePath = "/remotePath/to/item";
        string description = "Test item";
        string version = "1.0.0";
        var fileItem = new File(remotePath, description, version);
        FileInfo fileInfo = LocalFiles.LocalFiles.MyFileInfo;
        var item = new SynchronizedItem(fileInfo, fileItem);
        var childItem = new SynchronizedItem(fileInfo, fileItem);
        item.AddChild(childItem);

        // Act
        item.SetStatus(Status.Synchronized);

        // Assert
        Assert.Equal(Status.Synchronized, childItem.Status);
    }
    
}