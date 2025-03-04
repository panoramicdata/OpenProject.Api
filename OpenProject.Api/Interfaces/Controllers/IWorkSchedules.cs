using OpenProject.Api.Data.Models;

namespace OpenProject.Api.Interfaces.Controllers;

/// <summary>
/// The work schedule defines if days are working days or non-working days.
/// <para>A day can be a non-working day if any of these two conditions are met:</para>
/// <list type="bullet">
/// <item>the day is a recurring non-working week day: a weekend day. For instance Sunday is not worked in most countries;</item>
/// <item>the day has been defined as a non-working day: national bank holidays or other days deemed special. For instance the 1st of January is New Year’s day and is a bank holiday in most countries.</item>
/// </list>
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/work-schedule/'/></para>
/// </summary>
public interface IWorkSchedules
{
	/// <summary>
	/// Lists days information for a given date interval.
	/// </summary>
	/// <remarks>All days from the beginning of current month to the end of following month are returned by default.</remarks>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/days")]
	Task<OpenProjectItemSet<Day>> GetAllDays(CancellationToken cancellationToken);

	/// <summary>
	/// View the day information for a given date.
	/// </summary>
	/// <param name="targetDate"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/days/{date}")]
	Task<Day> GetDay([AliasAs("date")] string targetDate, CancellationToken cancellationToken);

	/// <summary>
	/// Lists week days with work schedule information.
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/days/week")]
	Task<OpenProjectItemSet<WeekDay>> GetAllWeekDays(CancellationToken cancellationToken);

	/// <summary>
	/// View a week day and its attributes.
	/// </summary>
	/// <param name="targetDate"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/days/week/{date}")]
	Task<WeekDay> GetWeekDay([AliasAs("date")] int targetDate, CancellationToken cancellationToken);

	/// <summary>
	/// Lists all one-time non working days, such as holidays. It does not lists the non working weekdays, such as each Saturday, Sunday. For listing the weekends, the /api/v3/days endpoint should be used.
	/// </summary>
	/// <remarks>All days from current year are returned by default.</remarks>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/days/non_working")]
	Task<OpenProjectItemSet<NonWorkingDay>> GetAllNonWorkingDays(CancellationToken cancellationToken);

	/// <summary>
	/// Returns the non-working day information for a given date.
	/// </summary>
	/// <param name="targetDate"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/days/non_working/{date}")]
	Task<NonWorkingDay> GetNonWorkingDay([AliasAs("date")] string targetDate, CancellationToken cancellationToken);
}
