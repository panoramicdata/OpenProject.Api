namespace OpenProject.Api;

public class OpenProjectClientOptions
{
	public required Uri Uri { get; init; }

	public required string ApiKey { get; init; }

	public ILogger? Logger { get; init; }

	public bool LogExceptionContent { get; init; }

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
