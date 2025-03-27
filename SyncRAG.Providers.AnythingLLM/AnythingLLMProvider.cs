namespace SyncRAG.Providers.AnythingLLM;

public class AnythingLLMProvider : Abstracts.IRAG
{
    /// <summary>
    /// Gets the name of the provider.
    /// </summary>
    public string Name => "AnythingLLM";

    /// <summary>
    /// Gets the type of the provider.
    /// </summary>
    public string Type => "LLM & RAG proxy";

    /// <summary>
    /// Gets the version of the provider.
    /// </summary>
    public string Version => "1.0.0";

    /// <summary>
    /// Gets the description of the provider.
    /// </summary>
    public string Description => "AnythingLLM is a provider for SyncRAG that allows you to use AnythingLLM as RAG system.";
}
