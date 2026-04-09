using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

/// <summary>
/// Represents a paginated collection response from the OpenProject API.
/// </summary>
/// <typeparam name="T">The type of items in the collection.</typeparam>
public class OpenProjectItemSet<T> : ItemBase
	where T : ItemBase
{
	/// <summary>
	/// The total number of items matching the query.
	/// </summary>
	public int Total { get; set; }

	/// <summary>
	/// The number of items in the current page.
	/// </summary>
	public int Count { get; set; }

	/// <summary>
	/// The maximum number of items per page.
	/// </summary>
	public int PageSize { get; set; }

	/// <summary>
	/// The starting position (1-based) for this page of results.
	/// </summary>
	public int Offset { get; set; }

	/// <summary>
	/// The embedded resources containing the collection elements.
	/// </summary>
	[JsonPropertyName("_embedded")]
	public Embedded<T>? Embedded { get; set; }
}
