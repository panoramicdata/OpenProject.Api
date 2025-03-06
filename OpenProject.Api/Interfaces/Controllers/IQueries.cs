using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// A query defines how work packages can be filtered and displayed. Clients can define a query once, store it, and use it later on to load the same set of filters and display options.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/queries/'/></para>
/// </summary>
public interface IQueries
{
	/// <summary>
	/// Get all Queries
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/queries")]
	public Task<OpenProjectItemSet<Query>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new Query and returns a Query (with the writable and readonly properties)
	/// </summary>
	/// <param name="query"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Post("/queries")]
	public Task<Query> CreateAsync(
		[Body] QueryCreate query,
		CancellationToken cancellationToken);

	/// <summary>
	/// Delete a Query by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Delete("/queries/{id}")]
	public Task<IApiResponse> DeleteAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Query by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/queries/{id}")]
	public Task<OpenProjectItemSet<Query>> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
