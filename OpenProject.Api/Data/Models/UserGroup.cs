namespace OpenProject.Api.Data.Models;

/// <summary>
/// Groups are collections of users. They support assigning/unassigning multiple users to/from a project in one operation.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/groups/'/></para>
/// </summary>
public class UserGroup : IdentifiedItem<int>, INamed, IHasTimestamps
{
	/// <summary>
	/// Group’s full name, formatting depends on instance settings	
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of the most recent change to the user	
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
