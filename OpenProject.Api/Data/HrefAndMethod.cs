using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class HrefAndMethod
{
	public string? Title { get; set; }

	public required string Href { get; set; }

	public string? Method { get; set; }

	[JsonPropertyName("templated")]
	public bool IsTemplated { get; set; }
}
