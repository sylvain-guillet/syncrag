namespace SyncRAG.Providers.Abstracts;

public interface IRAG   
{
    /// <summary>
    /// Gets the name of the provider.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the type of the provider.
    /// </summary>
    string Type { get; }

    /// <summary>
    /// Gets the version of the provider.
    /// </summary>
    string Version { get; }

    /// <summary>
    /// Gets the description of the provider.
    /// </summary>
    string Description { get; }
}