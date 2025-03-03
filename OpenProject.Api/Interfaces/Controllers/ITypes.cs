using OpenProject.Api.Data.Models;
using OpenProject.Api.Queries;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Project Category endpoints
/// See https://www.openproject.org/docs/api/endpoints/types/
/// </summary>
public interface ITypes
{
	/// <summary>
	/// Get project status
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/types")]
	Task<OpenProjectItemSet<Data.Models.Type>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get project status
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/types")]
	Task<OpenProjectItemSet<Data.Models.Type>> GetAsync(
		[Query] Filters filters,
		CancellationToken cancellationToken);
}
