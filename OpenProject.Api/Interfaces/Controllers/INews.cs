using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// News 
/// See https://www.openproject.org/docs/api/endpoints/news/
/// </summary>
public interface INews
{
	[Get("/news")]
	public Task<OpenProjectItemSet<News>> GetAllAsync(CancellationToken cancellationToken);

	[Get("/news/{id}")]
	public Task<OpenProjectItemSet<News>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
