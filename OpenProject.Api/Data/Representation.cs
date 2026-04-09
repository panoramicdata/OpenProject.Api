namespace OpenProject.Api.Data;

/// <summary>
/// A compact representation of an OpenProject resource reference.
/// </summary>
public class Representation
{
	/// <summary>
	/// The URI of the resource.
	/// </summary>
	public required string Href { get; set; }

	/// <summary>
	/// The unique identifier of the resource.
	/// </summary>
	public required string Identifier { get; set; }

	/// <summary>
	/// The type designation of the resource.
	/// </summary>
	public required string Type { get; set; }

	/// <summary>
	/// The human-readable name of the resource.
	/// </summary>
	public required string Title { get; set; }
}