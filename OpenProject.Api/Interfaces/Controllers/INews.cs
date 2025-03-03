using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces;

/// <summary>
/// News 
/// See https://www.openproject.org/docs/api/endpoints/news/
/// </summary>
public interface INews
{
	[Get("/news")]
	public Task<OpenProjectItemSet<NewsItem>> GetAllAsync(CancellationToken cancellationToken);

	[Get("/news/{id}")]
	public Task<OpenProjectItemSet<NewsItem>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
