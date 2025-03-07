using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.CustomLinks;

/// <summary>
/// Outlines the Links that are optional to create a Group
/// </summary>
public class GroupCreateLinks
{
	/// <summary>
	/// The list all all the users that are members of the group. e.g. ["/api/v3/users/1", "/api/v3/users/2"]
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public IEnumerable<HrefItem>? Members { get; set; }
}
