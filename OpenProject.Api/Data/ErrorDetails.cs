using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class ErrorDetails
{
	[JsonPropertyName("_type")]
	public required string Type { get; set; }
	public required string ErroneousField { get; set; }
}

