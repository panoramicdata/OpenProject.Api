using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;
public interface IQueries
{
	[Get("/queries")]
	public Task<OpenProjectItemSet<Query>> GetAllAsync(CancellationToken cancellationToken);

	[Get("/queries/{id}")]
	public Task<OpenProjectItemSet<Query>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
