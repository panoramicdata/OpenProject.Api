namespace OpenProject.Api.Data;
public class Grid : IdentifiedItem<int>
{
	public int RowCount { get; set; }

	public int ColumnCount { get; set; }

	public string? Name { get; set; }

	public Dictionary<string, object> Options { get; set; } = [];

	public IEnumerable<Widget> Widgets { get; set; } = [];
}
