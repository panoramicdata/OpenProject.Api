namespace OpenProject.Api.Data.Models;

/// <summary>
/// A model whose schedule fields are flat in OpenProject's JSON but grouped in <see cref="Schedule"/>.
/// </summary>
public interface IHasSchedule
{
	/// <summary>
	/// The scheduling and estimate fields.
	/// </summary>
	WorkPackageSchedule Schedule { get; set; }
}
