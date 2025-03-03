namespace OpenProject.Api.Data.Models;

/// <summary>
/// News are articles written by users in order to inform other users of important information.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/news/'/></para>
/// </summary>
public class News : IdentifiedItem<int>
{
	/// <summary>
	/// The headline of the news
	/// </summary>
	[MaxLength(60)]
	public required string Title { get; set; }

	/// <summary>
	/// A short summary
	/// </summary>
	[MaxLength(255)]
	public required string Summary { get; set; }

	/// <summary>
	/// The main body of the news with all the details
	/// </summary>
	public required Formattable Description { get; set; }

	/// <summary>
	/// The time the news was created at
	/// </summary>
	public DateTime CreatedAt { get; set; }
}
