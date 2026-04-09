namespace OpenProject.Api.Data;

/// <summary>
/// Represents a cryptographic digest (hash) of content.
/// </summary>
public class Digest
{
	/// <summary>
	/// The hashing algorithm used (e.g., "SHA-256").
	/// </summary>
	public required string Algorithm { get; set; }

	/// <summary>
	/// The computed hash value.
	/// </summary>
	public required string Hash { get; set; }
}
