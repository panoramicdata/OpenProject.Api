using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class OpenProjectItemSet<T> : ItemBase
	where T : ItemBase
{
	public int Total { get; set; }

	public int Count { get; set; }

	public int PageSize { get; set; }

	public int Offset { get; set; }

	[JsonPropertyName("_embedded")]
	public Embedded<T>? Embedded { get; set; }
}
