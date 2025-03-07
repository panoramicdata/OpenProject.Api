using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

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
