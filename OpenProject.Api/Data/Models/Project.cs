using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

public class Project : IdentifiedItem<int>, INamed, IHasTimestamps
{
	public required string Identifier { get; set; }

	public required string Name { get; set; }

	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	[JsonPropertyName("_public")]
	public bool IsPublic { get; set; }

	public required Formattable Description { get; set; }

	public required Formattable StatusExplanation { get; set; }

	public DateTime? CreatedAt { get; set; }

	public DateTime? UpdatedAt { get; set; }
}
