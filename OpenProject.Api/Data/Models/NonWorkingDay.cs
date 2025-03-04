namespace OpenProject.Api.Data.Models;

/// <summary>
/// Represents a day which is not a working day such as holidays. Does represent non working weekdays such as Saturday and Sunday.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/work-schedule/'/></para>
/// </summary>
public class NonWorkingDay : ItemBase
{
	/// <summary>
	/// The date in ISO8601 format (YYYY-MM-DD)	
	/// </summary>
	public required DateTime Date { get; set; }

	/// <summary>
	/// The name of the non-working day day	
	/// </summary>
	public required string Name { get; set; }
}
