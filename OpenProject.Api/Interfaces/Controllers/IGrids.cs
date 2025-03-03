using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// A Grid is a layout for a page or a part of the page of the OpenProject application. It defines the structure (number of rows and number of columns) as well as the contents of the page.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/grids/'/></para>
/// </summary>
public interface IGrids
{
	/// <summary>
	/// Get all Grids
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/grids")]
	public Task<OpenProjectItemSet<Grid>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get Grid by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/grids/{id}")]
	public Task<OpenProjectItemSet<Grid>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
