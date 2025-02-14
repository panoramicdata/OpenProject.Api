namespace OpenProject.Api.Data;

/// <summary>
/// In most cases, the API will return a dictionary of Link.
/// However, in some cases, the API will return other objects
/// </summary>
public class Links : Dictionary<string, object>;