namespace OpenProject.Api.Interfaces;

/// <summary>
/// Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IProjects
{
	/// <summary>
	/// View project status
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Post("/project_statuses/{id}")]
	Task<ProjectStatusModel> GetStatusAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Create a project
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Post("/projects")]
	Task<ProjectModel> CreateAsync(
		[Body] ProjectModel entity,
		CancellationToken cancellationToken);

	/// <summary>
	/// Patch a project
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Get("/projects/{id}")]
	Task<ProjectModel> GetAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets all projects
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectModel</returns>
	[Get("/projects")]
	Task<CollectionModel<ProjectModel>> GetAllAsync(
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
