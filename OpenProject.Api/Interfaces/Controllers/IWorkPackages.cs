using OpenProject.Api.Data.Models;
using OpenProject.Api.Queries;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Work packages
/// See https://www.openproject.org/docs/api/endpoints/work_packages/
/// </summary>
public interface IWorkPackages
{
	/// <summary>
	/// Get all work packages
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/work_packages")]
	Task<OpenProjectItemSet<WorkPackage>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get work packages filtered
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/work_packages/{id}")]
	Task<OpenProjectItemSet<WorkPackage>> GetAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Get work packages filtered
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/work_packages")]
	Task<OpenProjectItemSet<WorkPackage>> GetAsync(
		Filters? filters,
		int? pageSize,
		SortBy? sortBy,
		CancellationToken cancellationToken);
}
