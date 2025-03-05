namespace OpenProject.Api.Data.CustomLinks;

/// <summary>
/// Outlines the Links that are required to create a WorkProject
/// <para>Contains two Required Links:
/// <list type="bullet">
/// <item>Project - An API endpoint to the Parent Project  e.g. "/api/v3/projects/1"</item>
/// <item>Type - An API endpoint to the type of the Work Project e.g. "/api/v3/types/1"</item>
/// </list>
/// </para>
/// </summary>
public class WorkPackageCreateLinks
{
	/// <summary>
	/// An API endpoint to the Parent Project  e.g. "/api/v3/projects/1"
	/// </summary>
	public required HrefItem Project { get; set; }

	/// <summary>
	/// An API endpoint to the type of the Work Project e.g. "/api/v3/types/1"
	/// </summary>
	public required HrefItem Type { get; set; }
}
