namespace OpenProject.Api.Data.Models;

/// <summary>
/// Principal
/// </summary>
public class Principal : IdentifiedItem<int>, INamed
{
	public required string Name { get; set; }
}
