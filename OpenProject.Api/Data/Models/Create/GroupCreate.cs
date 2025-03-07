using OpenProject.Api.Data.CustomLinks;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Create;

/// <summary>
/// Represents an object used to create a new Group on the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/news/'/></para>
/// </summary>
public class GroupCreate
{
	/// <summary>
	/// Group’s full name, formatting depends on instance settings	
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Linked properties for Group Creation
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("_links")]
	public GroupCreateLinks? Links { get; set; }
}
