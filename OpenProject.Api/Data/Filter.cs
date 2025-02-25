using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;
public class Filter
{
	[JsonPropertyName("_type")]
	public required string Type { get; set; }
	public required string Name { get; set; }

	[JsonPropertyName("_links")]
	public required Links Links { get; set; }
}
