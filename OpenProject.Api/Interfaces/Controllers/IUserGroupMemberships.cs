using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces;

/// <summary>
/// Project Category endpoints
/// See https://www.openproject.org/docs/api/endpoints/memberships/
/// </summary>
public interface IUserGroupMemberships
{
	/// <summary>
	/// Get all user group memberships
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/memberships")]
	Task<OpenProjectItemSet<UserGroupMembership>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get user group membership
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/memberships/{id}")]
	Task<UserGroupMembership> GetAsync(
		int id,
		CancellationToken cancellationToken);
}