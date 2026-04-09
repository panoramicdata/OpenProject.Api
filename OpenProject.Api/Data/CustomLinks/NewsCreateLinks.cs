namespace OpenProject.Api.Data.CustomLinks;

/// <summary>
/// Outlines the Links that are required to create a News Item
/// <para>Contains a Required Link:
/// <list type="bullet">
/// <item>Project - An API endpoint to the Parent Project  e.g. "/api/v3/projects/1"</item>
/// </list>
/// </para>
/// </summary>
/// <remarks>The remaining properties are Optional</remarks>
public class NewsCreateLinks
{
	/// <summary>
	/// An API endpoint to the parent project (e.g., "/api/v3/projects/1").
	/// </summary>
	public required HrefItem Project { get; set; }
}
