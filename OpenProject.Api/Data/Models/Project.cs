using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// Projects are containers structuring the information (e.g. work packages, wikis) into smaller groups. They can be used in a classic project management approach but also when structuring work by departments.
/// <para>As containers, they also control behaviour of the elements within them. One of the most important aspects of this is that projects limit permissions by having members with a certain permission set (roles) assigned to them.</para>
///<para>See  <a href='https://www.openproject.org/docs/api/endpoints/projects/'/></para>
/// </summary>
public class Project : IdentifiedItem<int>, INamed, IHasTimestamps
{
	/// <summary>
	/// The identifier of the project
	/// </summary>
	public required string Identifier { get; set; }

	/// <summary>
	/// The name of the project
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Indicates whether the project is currently active or already archived
	/// </summary>
	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	/// <summary>
	/// A text detailing and explaining why the project has the reported status	
	/// </summary>
	public required Formattable StatusExplanation { get; set; }

	/// <summary>
	/// Indicates whether the project is accessible for everybody
	/// </summary>
	[JsonPropertyName("_public")]
	public bool IsPublic { get; set; }

	/// <summary>
	/// A text describing the project
	/// </summary>
	public required Formattable Description { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of the most recent change to the project
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
