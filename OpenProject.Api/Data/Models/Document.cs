namespace OpenProject.Api.Data.Models;
/// <summary>
/// A Document is a file containing a list of attachments
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/documents/'/></para>
/// </summary>
public class Document : IdentifiedItem<int>
{
	/// <summary>
	/// The title of the Document
	/// </summary>
	[StringLength(60)]
	public string Title { get; set; } = string.Empty;

	/// <summary>
	/// A text describing the document
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// The time the document was created at
	/// </summary>
	public DateTime CreatedAt { get; set; }
}
