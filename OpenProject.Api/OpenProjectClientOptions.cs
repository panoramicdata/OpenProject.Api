namespace OpenProject.Api;

/// <summary>
/// Configuration options for the OpenProject API client.
/// </summary>
public class OpenProjectClientOptions
{
	/// <summary>
	/// The base URI of the OpenProject instance (e.g., "https://myinstance.openproject.com").
	/// </summary>
	public required Uri Uri { get; init; }

	/// <summary>
	/// The API key used for authentication.
	/// </summary>
	public required string ApiKey { get; init; }

	/// <summary>
	/// Optional logger for diagnostic output.
	/// </summary>
	public ILogger? Logger { get; init; }

	/// <summary>
	/// Whether to log the content of API exception responses.
	/// </summary>
	public bool LogExceptionContent { get; init; }

	/// <summary>
	/// Validates that the required options are set.
	/// </summary>
	/// <exception cref="ValidationException">Thrown when a required option is missing.</exception>
	public void Validate()
	{
		if (Uri is null)
		{
			throw new ValidationException($"{nameof(Uri)} missing.");
		}

		if (ApiKey is null)
		{
			throw new ValidationException($"{nameof(ApiKey)} missing.");
		}
	}
}
