using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// A View is a representation of some information. That information might be a query (currently it always is). The view will store the configuration on how to display the information but not the information itself.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/views/'/></para>
/// </summary>
public class View : IdentifiedItem<int>, INamed, IHasTimestamps
{
	/// <summary>
	/// View name
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Can users besides the owner see the view?
	/// </summary>
	[JsonPropertyName("public")]
	public bool IsPublic { get; set; }

	/// <summary>
	/// Should the view be highlighted to the user?	
	/// </summary>
	[JsonPropertyName("starred")]
	public bool IsStarred { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of the most recent change to the view
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
