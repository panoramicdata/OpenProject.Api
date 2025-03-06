namespace OpenProject.Api.Data.Models.Create
{
	/// <summary>
	/// Represents an object used to create a new Query on the OpenProject Instance
	/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/queries/'/></para>
	/// </summary>
	public class QueryCreate
	{
		/// <summary>
		/// The Name of the new Query
		/// </summary>
		public required string Name { get; set; }
	}
}
