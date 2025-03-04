
namespace OpenProject.Api.Data.Models;

/// <summary>
/// Work Packages can be assigned to a version. As such, versions serve to group Work Packages into logical units where each group comprises all the work packages that needs to be finished in order for the version to be finished.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/versions/'/></para>
/// </summary>
public class Version : IdentifiedItem<int>, INamed, IHasTimestamps
{
	/// <summary>
	/// Version Name
	/// </summary>
	[MaxLength(60)]
	public required string Name { get; set; }

	/// <summary>
	/// Description of the version
	/// </summary>
	public required Formattable Description { get; set; }

	/// <summary>
	/// Version start Date
	/// </summary>
	public DateTime? StartDate { get; set; }

	/// <summary>
	/// Version end Date
	/// </summary>
	public DateTime? EndDate { get; set; }

	/// <summary>
	/// The current status of the version	
	/// </summary>
	public required string Status { get; set; }

	/// <summary>
	/// The current status of the version	
	/// </summary>
	public required string Sharing { get; set; }

	/// <summary>
	/// Time of creation	
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of the most recent change to the version	
	/// </summary>
	public required DateTime UpdatedAt { get; set; }

}
