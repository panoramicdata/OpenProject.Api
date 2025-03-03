using OpenProject.Api.Data.Models;

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
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/groups")]
	Task<OpenProjectItemSet<Group>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get Group by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/groups/{id}")]
	Task<Group> GetAsync(
		int id,
		CancellationToken cancellationToken);
}