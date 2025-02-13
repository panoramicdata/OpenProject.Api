using System.Net.Http.Headers;
using System.Text;

namespace OpenProject.Api;

public class AuthenticatedHttpClientHandler : HttpClientHandler
{
	private readonly OpenProjectClientOptions _options;

	private readonly ILogger? _logger;

	public AuthenticatedHttpClientHandler(
		OpenProjectClientOptions options)
	{
		options.Validate();
		_options = options;
		_logger = options.Logger;
	}

	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		// Set basic auth header
		request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"apikey:{_options.ApiKey}")));

		// Get a GUID to uniquely identify the request
		var guid = Guid.NewGuid();
		_logger?.LogDebug("{Guid}:{RequestMethod}:{RequestUri}\nHeaders:{Headers}\nBody:{Body}",
			guid.ToString(),
			request.Method,
			request.RequestUri,
			request.Headers,
			request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
			);

		HttpResponseMessage response;
		try
		{
			response = await base
				.SendAsync(request, cancellationToken)
				.ConfigureAwait(false);
		}
		catch (ApiException ex)
		{
			LogApiException(ex);
			throw;
		}

		_logger?.LogDebug("{Guid}:{ResponseStatusCode}:{Body}",
			guid.ToString(),
			response.StatusCode,
			request.Content is null ? null : await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));

		return response;
	}

	/// <summary>
	/// Log details of an ApiException (as enabled in options)
	/// </summary>
	/// <param name="ex">The exception whose details are to be logged</param>
	private void LogApiException(ApiException ex)
	{
		if (ex.Content is null)
		{
			return;
		}

		if (_options.LogExceptionContent)
		{
			_logger?.LogError(ex, "Error from Refit; response content is: {Content}", ex.Content);
		}
	}
}
