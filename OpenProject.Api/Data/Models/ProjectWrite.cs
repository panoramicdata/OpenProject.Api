using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// The fields accepted when writing a Project to the OpenProject Instance.
/// <para>Shared by <see cref="Create.ProjectCreate"/> and <see cref="Update.ProjectUpdate"/>,
/// which accept exactly the same fields; the two remain distinct types so that each endpoint
/// keeps its own name at the call site.</para>
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/projects/'/></para>
/// </summary>
public abstract class ProjectWrite
{
	/// <summary>
	/// The Name of the Project
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// The Unique Identifier used to identify the Project
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Identifier { get; set; }

	/// <summary>
	/// Indicates whether the project is currently active or already archived
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("active")]
	public bool? IsActive { get; set; }

	/// <summary>
	/// Whether the project is accessible to everyone
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("public")]
	public bool? IsPublic { get; set; }

	/// <summary>
	/// A description of the Project
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Formattable? Description { get; set; }

	/// <summary>
	/// A text detailing and explaining why the project has the reported status
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Formattable? StatusExplanation { get; set; }
}