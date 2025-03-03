namespace OpenProject.Api.Data;
public class NewsItem : IdentifiedItem<int>
{
	public required string Title { get; set; }

	public required string Summary { get; set; }

	public required Formattable Description { get; set; }

	public DateTime? CreatedAt { get; set; }
}
