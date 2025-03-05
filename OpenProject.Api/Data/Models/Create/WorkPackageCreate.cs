using OpenProject.Api.Data.CustomLinks;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Create;

/// <summary>
/// Represents an object used to create a new User on the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/work-packages/'/></para>
/// </summary>
public class WorkPackageCreate
{
	/// <summary>
	/// Outlines the Subject of the new Work Project
	/// </summary>
	public required string Subject { get; set; }

	/// <inheritdoc cref="WorkPackageCreateLinks"/>
	[JsonPropertyName("_links")]
	public required WorkPackageCreateLinks Links { get; set; }
}
