
namespace OpenProject.Api.Data.Models;

/// <summary>
/// Users and groups can become members of a project. Such a membership will also have one or more roles assigned to it. By that, memberships control the permissions a user has within a project.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/memberships/'/></para>
/// </summary>
public class Membership : IdentifiedItem<int>, IHasTimestamps
{
	/// <summary>
	/// Time of creation
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of latest update
	/// </summary>
	public required DateTime UpdatedAt { get; set; }
}
