using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Project Category endpoints
/// See https://www.openproject.org/docs/api/endpoints/memberships/
/// </summary>
public interface IMemberships
{
	/// <summary>
	/// Get all memberships
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroups</returns>
	[Get("/memberships")]
	Task<OpenProjectItemSet<Membership>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get membership by ID
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of UserGroup</returns>
	[Get("/memberships/{id}")]
	Task<Membership> GetAsync(
		int id,
		CancellationToken cancellationToken);
}