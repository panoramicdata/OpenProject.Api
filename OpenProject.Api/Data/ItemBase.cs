using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public abstract class ItemBase
{
	[JsonPropertyName("_type")]
	public required string Type { get; set; }

	[JsonPropertyName("_links")]
	public required Links Links { get; set; }
}
