using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Users are the people who use the OpenProject instance. They can be assigned to work packages, projects, and groups.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/users/'/></para>
/// </summary>
public interface IUsers
{
	/// <summary>
	/// Get all Users
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/users")]
	Task<OpenProjectItemSet<User>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get User by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/users/{id}")]
	Task<User> GetAsync(
		int id,
		CancellationToken cancellationToken);

	[Post("/users")]
	Task<string> PostAsync(
		[Body] UserCreate user,
		CancellationToken cancellationToken);
}