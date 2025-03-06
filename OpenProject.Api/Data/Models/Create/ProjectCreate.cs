using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Create;

/// <summary>
/// Represents an object used to create a new Project on the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/projects/'/></para>
/// </summary>
public class ProjectCreate
{
	/// <summary>
	/// The Name of the new Project
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
	/// A description of the new Project
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Formattable? Description { get; set; }

	/// <summary>
	/// A text detailing and explaining why the project has the reported status
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Formattable? StatusExplanation { get; set; }
}
