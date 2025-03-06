using System.Text.Json.Serialization;

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
/// <remarks>The remaining properties are Optional</remarks>
public class WorkPackageCreateLinks
{
	/// <summary>
	/// The project to which the work package belongs  e.g. "/api/v3/projects/1"
	/// </summary>
	public required HrefItem Project { get; set; }

	/// <summary>
	/// The type of the work package e.g. "/api/v3/types/1"
	/// </summary>
	public required HrefItem Type { get; set; }

	/// <summary>
	/// The category of the work package e.g. "/api/v3/categories/1"
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HrefItem? Category { get; set; }

	/// <summary>
	/// The priority of the work package e.g. "/api/v3/priorities/1"
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HrefItem? Priority { get; set; }

	/// <summary>
	/// The current status of the work package e.g. "/api/v3/statuses/1"
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HrefItem? Status { get; set; }

	/// <summary>
	/// The person that is responsible for the overall outcome	e.g. "/api/v3/users/1"
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HrefItem? Responsible { get; set; }

	/// <summary>
	/// The person that is intended to work on the work package	e.g. "/api/v3/users/1"
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HrefItem? Assignee { get; set; }

	/// <summary>
	/// The version associated to the work package	e.g. "/api/v3/versions/1"
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HrefItem? Version { get; set; }


	/// <summary>
	/// Parent work package	e.g. "/api/v3/work_packages/1"
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public HrefItem? Parent { get; set; }
}
