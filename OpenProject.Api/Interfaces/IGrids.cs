namespace OpenProject.Api.Interfaces;
public interface IGrids
{
	[Get("/grids")]
	public Task<OpenProjectItemSet<Grid>> GetAllAsync(CancellationToken cancellationToken);

	[Get("/grids/{id}")]
	public Task<OpenProjectItemSet<Grid>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
