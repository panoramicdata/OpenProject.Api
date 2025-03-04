using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// Time entries are classified by an activity which is one item of a set of user defined activities (e.g. Design, Specification, Development).
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/time-entry-activities/'/></para>
/// </summary>
public interface ITimeEntries
{
	/// <summary>
	/// Get all Time Entries
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/time_entries")]
	Task<OpenProjectItemSet<TimeEntry>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get TimeEntry by Id
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/time_entries/{id}")]
	Task<TimeEntry> GetAsync(int id, CancellationToken cancellationToken);
}
