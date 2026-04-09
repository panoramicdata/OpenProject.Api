namespace OpenProject.Api.Interfaces;

/// <summary>
/// Implemented by resources that have a name.
/// </summary>
public interface INamed
{
	/// <summary>
	/// The name of the resource
	/// </summary>
	string Name { get; set; }
}
