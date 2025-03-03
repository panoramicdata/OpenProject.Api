using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// News are articles written by users in order to inform other users of important information.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/news/'/></para>
/// </summary>
public interface INews
{
	/// <summary>
	/// Get all News articles
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/news")]
	public Task<OpenProjectItemSet<News>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get News article by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/news/{id}")]
	public Task<OpenProjectItemSet<News>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
