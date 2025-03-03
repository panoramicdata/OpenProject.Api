using Action = OpenProject.Api.Data.Models.Action;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// An action is a change one can trigger within the OpenProject instance. This could be creating a work package, exporting work packages or updating a user.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/actions-capabilities/'/> </para>
/// </summary>
public interface IActions
{
	/// <summary>
	/// Get all actions
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of Actions</returns>
	[Get("/actions")]
	public Task<OpenProjectItemSet<Action>> GetAllAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Get action
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of Action</returns>
	[Get("/actions/{id}")]
	public Task<OpenProjectItemSet<Action>> GetAsync(
		string id,
		CancellationToken cancellationToken);
}
