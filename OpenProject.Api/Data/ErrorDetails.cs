using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

/// <summary>
/// Details about an API error, identifying the type and the field that caused the error.
/// </summary>
public class ErrorDetails
{
	/// <summary>
	/// The error type designation.
	/// </summary>
	[JsonPropertyName("_type")]
	public required string Type { get; set; }

	/// <summary>
	/// The field that caused the error.
	/// </summary>
	public required string ErroneousField { get; set; }
}

