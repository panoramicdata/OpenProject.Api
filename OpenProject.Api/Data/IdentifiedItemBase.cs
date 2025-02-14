using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public abstract class IdentifiedItemBase
{
	[JsonPropertyName("_type")]
	public required string Type { get; set; }

	public DateTime? CreatedAt { get; set; }

	public DateTime? UpdatedAt { get; set; }

	[JsonPropertyName("_links")]
	public required Links Links { get; set; }
}
