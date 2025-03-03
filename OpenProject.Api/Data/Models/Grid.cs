namespace OpenProject.Api.Data.Models;

/// <summary>
/// A grid is a layout for a page or a part of the page of the OpenProject application. It defines the structure (number of rows and number of columns) as well as the contents of the page.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/grids/'/></para>
/// </summary>
public class Grid : IdentifiedItem<int>, IHasTimestamps
{
	/// <summary>
	/// The number of rows the grid has
	/// </summary>
	[Range(1, int.MaxValue)]
	public int RowCount { get; set; }

	/// <summary>
	/// The number of columns the grid has
	/// </summary>
	[Range(1, int.MaxValue)]
	public int ColumnCount { get; set; }

	/// <summary>
	/// The set of Widgets selected for the grid
	/// </summary>
	public IEnumerable<Widget> Widgets { get; set; } = [];

	/// <summary>
	/// The time the grid was created
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The time the grid was last updated
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
