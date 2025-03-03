namespace OpenProject.Api.Interfaces;
public interface IHasTimestamps
{
	/// <summary>
	/// The date and time the resource was created
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The date and time the resource was last updated
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
