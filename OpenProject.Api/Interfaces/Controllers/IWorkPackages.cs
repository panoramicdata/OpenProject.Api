using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Queries;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// A work package in OpenProject can basically be everything you need to keep track off within your projects. It can be e.g. a task, a feature, a bug, a risk, a milestone or a project phase.
/// <para>See <a href='https://www.openproject.org/docs/getting-started/work-packages-introduction/'/></para>
/// </summary>
public interface IWorkPackages
{
	/// <summary>
	/// Get all Work Packages
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/work_packages")]
	Task<OpenProjectItemSet<WorkPackage>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Work Package by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/work_packages/{id}")]
	Task<OpenProjectItemSet<WorkPackage>> GetAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Work Packages based on Filters
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/work_packages")]
	Task<OpenProjectItemSet<WorkPackage>> GetAsync(
		Filters? filters,
		int? pageSize,
		SortBy? sortBy,
		CancellationToken cancellationToken);


	/// <summary>
	/// Create a Work Package and return the created entity
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Post("/work_packages")]
	Task<WorkPackage> CreateAsync(
		[Body] WorkPackageCreate entity,
		CancellationToken cancellationToken);
}
