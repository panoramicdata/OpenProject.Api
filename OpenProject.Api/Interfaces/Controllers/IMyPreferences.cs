using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Controller interface for accessing the current user's preferences.
/// </summary>
public interface IMyPreferences
{
	/// <summary>
	/// Get the current user's preferences
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/my_preferences")]
	Task<UserPreferences> GetAsync(CancellationToken cancellationToken);
}
