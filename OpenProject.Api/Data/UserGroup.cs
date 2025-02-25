namespace OpenProject.Api.Data;

/// <summary>
/// User Group
/// </summary>
public class UserGroup : IdentifiedItem<int>, INamed
{
	public required string Name { get; set; }
}
