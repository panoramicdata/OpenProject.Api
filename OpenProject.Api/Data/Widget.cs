using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;
public class Widget
{
	[JsonPropertyName("_type")]
	public required string Type { get; set; }

	public int Id { get; set; }

	public required string Identifier { get; set; }

	public int StartRow { get; set; }

	public int EndRow { get; set; }

	public int StartColumn { get; set; }

	public int EndColumn { get; set; }

	public Dictionary<string, object> Options { get; set; } = [];
}
