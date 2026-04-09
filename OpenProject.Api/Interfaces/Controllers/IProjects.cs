using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Data.Models.Update;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Projects are containers structuring the information (e.g. work packages, wikis) into smaller groups.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/projects/'/></para>
/// </summary>
public interface IProjects
{
	/// <summary>
	/// Create a Project
	/// </summary>
	/// <exception cref="Refit.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Post("/projects")]
	Task<Project> CreateAsync(
		[Body] ProjectCreate entity,
		CancellationToken cancellationToken);

	/// <summary>
	/// Get a project by ID
	/// </summary>
	/// <exception cref="Refit.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Get("/projects/{id}")]
	Task<Project> GetAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets all projects
	/// </summary>
	/// <exception cref="Refit.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Get("/projects")]
	Task<OpenProjectItemSet<Project>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a project by ID
	/// </summary>
	/// <exception cref="Refit.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task</returns>
	[Delete("/projects/{id}")]
	Task<IApiResponse> DeleteAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Update a Project by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="entity"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Patch("/projects/{id}")]
	Task<Project> UpdateAsync(
		int id,
		[Body] ProjectUpdate entity,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets all project available assignees
	/// </summary>
	/// <exception cref="Refit.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Get("/projects/{id}/available_assignees")]
	Task<OpenProjectItemSet<User>> GetAvailableAssigneesAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets all parent projects
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/projects/available_parent_projects")]
	Task<OpenProjectItemSet<Project>> GetAvailableParentProjectsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Returns the work packages of a project
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/projects/{id}/work_packages")]
	Task<OpenProjectItemSet<WorkPackage>> GetWorkPackagesAsync(
		int id,
		CancellationToken cancellationToken);
}
