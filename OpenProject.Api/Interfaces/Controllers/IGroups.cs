using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Groups are collections of users. They support assigning/unassigning multiple users to/from a project in one operation.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/groups/'/></para>
/// </summary>
public interface IGroups
{
	/// <summary>
	/// Get all Groups
	/// </summary>
	/// <exception cref="Refit.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/groups")]
	Task<OpenProjectItemSet<Group>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Createa a new Group
	/// </summary>
	/// <param name="groupCreate"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Post("/groups")]
	Task<Group> CreateAsync(
		[Body] GroupCreate groupCreate,
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Group by ID
	/// </summary>
	/// <exception cref="Refit.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/groups/{id}")]
	Task<Group> GetAsync(
		int id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a Group by ID
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Delete("/groups/{id}")]
	Task<IApiResponse> DeleteAsync(
		int id,
		CancellationToken cancellationToken);
}