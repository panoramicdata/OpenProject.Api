using OpenProject.Api.Data.CustomLinks;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Create;

/// <summary>
/// Represents an object used to create a new News Item on the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/news/'/></para>
/// </summary>
public class NewsCreate
{
	/// <summary>
	/// The headline of the news
	/// </summary>
	public required string Title { get; set; }

	/// <summary>
	/// A short summary	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Summary { get; set; }

	/// <summary>
	/// The main body of the news with all the details	
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Formattable? Description { get; set; }

	[JsonPropertyName("_links")]
	public required NewsCreateLinks Links { get; set; }
}
