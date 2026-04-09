using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

/// <summary>
/// Represents a HAL (Hypertext Application Language) link object.
/// </summary>
public class Link
{
	/// <summary>
	/// The URL reference for the link.
	/// </summary>
	public required string? Href { get; set; }

	/// <summary>
	/// Human-readable title for the link.
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Whether the href is a URI template.
	/// </summary>
	[JsonPropertyName("templated")]
	public bool IsTemplated { get; set; }

	/// <summary>
	/// The HTTP method for following the link.
	/// </summary>
	public string? Method { get; set; }

	/// <summary>
	/// Optional payload data for the link.
	/// </summary>
	public string? Payload { get; set; }

	/// <summary>
	/// Unique identifier for the link.
	/// </summary>
	public string? Identifier { get; set; }
}
