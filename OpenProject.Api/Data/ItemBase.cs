using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

public abstract class ItemBase
{
	/// <summary>
	/// Outlines the type of this item.
	/// </summary>
	[JsonPropertyName("_type")]
	public required string ItemType { get; set; }

	[JsonPropertyName("_links")]
	public required Links Links { get; set; }
}
