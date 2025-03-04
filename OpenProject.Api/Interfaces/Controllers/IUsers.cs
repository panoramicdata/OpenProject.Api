using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Data.Models.Update;

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

	/// <summary>
	/// Create a new User
	/// </summary>
	/// <param name="user"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Post("/users")]
	Task<User> PostAsync(
		[Body] UserCreate user,
		CancellationToken cancellationToken);

	/// <summary>
	/// Update a User
	/// </summary>
	/// <param name="id"></param>
	/// <param name="user"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Patch("/users/{id}")]
	Task<User> PatchAsync(
		int id,
		[Body] UserUpdate user,
		CancellationToken cancellationToken);

	/// <summary>
	/// Delete a User
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Delete("/users/{id}")]
	Task<string> DeleteAsync(
		int id,
		CancellationToken cancellationToken);
}