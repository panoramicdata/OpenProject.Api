namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Grids 
/// See https://www.openproject.org/docs/api/endpoints/grids/
/// </summary>
/// 
public interface IGrids
{
	[Get("/grids")]
	public Task<OpenProjectItemSet<Grid>> GetAllAsync(CancellationToken cancellationToken);

	[Get("/grids/{id}")]
	public Task<OpenProjectItemSet<Grid>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
