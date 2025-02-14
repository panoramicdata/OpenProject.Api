using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class ProjectModel : NamedItemModel
{
	public required string Identifier { get; set; }

	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	[JsonPropertyName("_public")]
	public bool IsPublic { get; set; }

	public required Formattable Description { get; set; }

	public required Formattable StatusExplanation { get; set; }
}