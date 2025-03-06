using OpenProject.Api.Data.Models;
using OpenProject.Api.Queries;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Work package types represented in the system.
/// Types exist globally and are then activated for projects.
/// <para><a href='https://www.openproject.org/docs/api/endpoints/types/'/></para>
/// </summary>
public interface ITypes
{
	/// <summary>
	/// Get All Types of Work Packages
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/types")]
	Task<OpenProjectItemSet<Data.Models.Type>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Types based on Filters
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/types")]
	Task<OpenProjectItemSet<Data.Models.Type>> GetAllAsync(
		[Query] Filters filters,
		CancellationToken cancellationToken);

	/// <summary>
	/// Get a Type by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/types/{id}")]
	Task<Data.Models.Type> GetAsync(
		int id,
		CancellationToken cancellationToken);
}
