using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class Link
{
	public required string? Href { get; set; }

	public string? Title { get; set; }

	[JsonPropertyName("templated")]
	public bool IsTemplated { get; set; }

	public string? Method { get; set; }

	public string? Payload { get; set; }

	public string? Identifier { get; set; }
}
