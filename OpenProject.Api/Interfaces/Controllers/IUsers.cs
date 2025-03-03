using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces;

/// <summary>
/// Users
/// See https://www.openproject.org/docs/api/endpoints/users/
/// </summary>
public interface IUsers
{
	/// <summary>
	/// Get all users
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/users")]
	Task<OpenProjectItemSet<User>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get user
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/users/{id}")]
	Task<User> GetAsync(
		int id,
		CancellationToken cancellationToken);
}