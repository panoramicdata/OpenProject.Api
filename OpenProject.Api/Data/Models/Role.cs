namespace OpenProject.Api.Data.Models;

/// <summary>
/// Roles regulate access to specific resources by having permissions configured for them.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/roles/'/></para>
/// </summary>
public class Role : IdentifiedItem<int>, INamed
{
	/// <summary>
	/// Role name
	/// </summary>
	public string Name { get; set; } = string.Empty;

}
