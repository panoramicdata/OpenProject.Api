namespace OpenProject.Api.Data.Models;

/// <summary>
/// User Group
/// </summary>
public class UserGroup : IdentifiedItem<int>, INamed, IHasTimestamps
{
	public required string Name { get; set; }

	public DateTime? CreatedAt { get; set; }

	public DateTime? UpdatedAt { get; set; }
}
