using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public class CollectionModel<T> where T : ItemModel
{
	[JsonPropertyName("_type")]
	public string Type { get; set; }

	public int Total { get; set; }

	public int Count { get; set; }

	public int PageSize { get; set; }

	public int Offset { get; set; }

	[JsonPropertyName("_embedded")]
	public Embedded<T> Embedded { get; set; }

	[JsonPropertyName("_links")]
	public Links Links { get; set; }
}
