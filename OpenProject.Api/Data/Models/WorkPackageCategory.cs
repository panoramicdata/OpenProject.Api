namespace OpenProject.Api.Data.Models;

/// <summary>
/// In the work package forms you have the default attribute to select work package categories to differentiate work packages, filter, and group by certain attributes.
/// <para>See <a href='https://www.openproject.org/docs/user-guide/projects/project-settings/work-package-categories/'/></para>
/// </summary>
public class WorkPackageCategory : IdentifiedItem<string>, INamed
{
	/// <summary>
	/// Category Name
	/// </summary>
	public required string Name { get; set; }
}
