namespace OpenProject.Api.Data.Models;
/// <summary>
/// A Document is a file containing a list of attachments
/// </summary>
public class Document : IdentifiedItem<int>
{
	[StringLength(60)]
	public string Title { get; set; } = string.Empty;

	public string? Description { get; set; }

	public DateTime? CreatedAt { get; set; }
}
