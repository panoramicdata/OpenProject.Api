using System.Text.Json.Serialization;

namespace OpenProject.Api.Data;
/// <summary>
/// A Document is a file containing a list of attachments
/// </summary>
public class Document
{
	[Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
	public int Id { get; set; }

	[StringLength(60)]
	public string Title { get; set; } = string.Empty;

	public string? Description { get; set; }

	public DateTime? CreatedAt { get; set; }

	[JsonPropertyName("_links")]
	public required Links Links { get; set; }
}
