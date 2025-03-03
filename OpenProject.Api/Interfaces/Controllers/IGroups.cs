using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// User groups
/// See https://www.openproject.org/docs/api/endpoints/groups/
/// </summary>
public interface IGroups
{
	/// <summary>
	/// Get all user groups
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/groups")]
	Task<OpenProjectItemSet<Group>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get user group
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/groups/{id}")]
	Task<Group> GetAsync(
		int id,
		CancellationToken cancellationToken);
}