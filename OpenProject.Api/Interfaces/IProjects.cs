namespace OpenProject.Api.Interfaces;

/// <summary>
/// Project endpoints
/// See https://www.openproject.org/docs/api/endpoints/projects/
/// </summary>
public interface IProjects
{
	/// <summary>
	/// Create a project
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Post("/projects")]
	Task<Project> CreateAsync(
		[Body] Project entity,
		CancellationToken cancellationToken);

	/// <summary>
	/// Patch a project
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
}
