﻿namespace OpenProject.Api.Interfaces;

/// <summary>
/// Project Category endpoints
/// See https://www.openproject.org/docs/api/endpoints/types/
/// </summary>
public interface IWorkPackageTypes
{
	/// <summary>
	/// Get project status
	/// </summary>
	/// <exception cref="Exceptions.ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ProjectStatusModel</returns>
	[Get("/types")]
	Task<OpenProjectItemSet<WorkPackageType>> GetAllAsync(
		CancellationToken cancellationToken);
}
