using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;

/// <summary>
/// Abstract base class for all OpenProject API resource items.
/// </summary>
public abstract class ItemBase
{
	/// <summary>
	/// Outlines the type of this item.
	/// </summary>
	[JsonPropertyName("_type")]
	public required string ItemType { get; set; }

	/// <summary>
	/// The HAL links associated with this resource for navigation and related actions.
	/// </summary>
	[JsonPropertyName("_links")]
	public required Links Links { get; set; }
}
