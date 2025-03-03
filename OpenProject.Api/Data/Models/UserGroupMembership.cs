
namespace OpenProject.Api.Data.Models;

/// <summary>
/// User Group Membership
/// </summary>
public class UserGroupMembership : IdentifiedItem<int>, IHasTimestamps
{
	public DateTime CreatedAt { get; set; }

	public DateTime UpdatedAt { get; set; }
}
