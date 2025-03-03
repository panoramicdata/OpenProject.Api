using OpenProject.Api.Data.Models;

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
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Post("/projects")]
	Task<Project> CreateAsync(
		[Body] Project entity,
		CancellationToken cancellationToken);

	/// <summary>
	/// Get a project by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Get("/projects/{id}")]
	Task<Project> GetAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets all projects
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Get("/projects")]
	Task<OpenProjectItemSet<Project>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a project
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Delete("/projects/{id}")]
	Task DeleteAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets all project available assignees
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
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
}
