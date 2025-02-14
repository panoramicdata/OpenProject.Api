using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class Project : NamedIdentifiedItem<int>
{
	public required string Identifier { get; set; }

	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	[JsonPropertyName("_public")]
	public bool IsPublic { get; set; }

	public required Formattable Description { get; set; }

	public required Formattable StatusExplanation { get; set; }
}