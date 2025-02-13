namespace OpenProject.Api.Data;

/// <summary>
/// ProjectStatusModel
/// </summary>
public class ProjectStatusModel
{
	public Links _links { get; set; }
	public string _type { get; set; }
	public string id { get; set; }
	public string name { get; set; }
}

public class CreateWorkPackage
{
	public string href { get; set; }
	public string method { get; set; }
}

public class CreateWorkPackageImmediately
{
	public string href { get; set; }
	public string method { get; set; }
}

public class WorkPackages
{
	public string href { get; set; }
}

public class Categories
{
	public string href { get; set; }
}

public class Versions
{
	public string href { get; set; }
}

public class Memberships
{
	public string href { get; set; }
}

public class Types
{
	public string href { get; set; }
}

public class Update
{
	public string href { get; set; }
	public string method { get; set; }
}

public class UpdateImmediately
{
	public string href { get; set; }
	public string method { get; set; }
}

public class Delete
{
	public string href { get; set; }
	public string method { get; set; }
}

public class Schema
{
	public string href { get; set; }
}

public class Status
{
	public string href { get; set; }
	public string title { get; set; }
}

public class ProjectStorages
{
	public string href { get; set; }
}

public class Self1
{
	public string href { get; set; }
}

public class JumpTo
{
	public string href { get; set; }
	public bool templated { get; set; }
}

public class ChangeSize
{
	public string href { get; set; }
	public bool templated { get; set; }
}

public class Representation
{
	public string href { get; set; }
	public string identifier { get; set; }
	public string type { get; set; }
	public string title { get; set; }
}
