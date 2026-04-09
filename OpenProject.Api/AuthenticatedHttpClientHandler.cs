using System.Net.Http.Headers;
using System.Text;

namespace OpenProject.Api;

/// <summary>
/// HTTP client handler that adds OpenProject API key authentication (Basic auth) to all outgoing requests.
/// </summary>
public class AuthenticatedHttpClientHandler : HttpClientHandler
{
	private readonly OpenProjectClientOptions _options;

	private readonly ILogger? _logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="AuthenticatedHttpClientHandler"/> class.
	/// </summary>
	/// <param name="options">The client options containing the API key and other configuration.</param>
	public AuthenticatedHttpClientHandler(
		OpenProjectClientOptions options)
	{
		options.Validate();
		_options = options;
		_logger = options.Logger;
	}

	/// <summary>
	/// Sends an HTTP request with Basic authentication credentials attached.
	/// </summary>
	/// <param name="request">The HTTP request message to send.</param>
	/// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
	/// <returns>The HTTP response message.</returns>
	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		// Set basic auth header
		request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"apikey:{_options.ApiKey}")));

		// Get a GUID to uniquely identify the request
		var guid = Guid.NewGuid();
		if (_logger?.IsEnabled(LogLevel.Debug) == true)
		{
			_logger.LogDebug("{Guid}:{RequestMethod}:{RequestUri}\nHeaders:{Headers}\nBody:{Body}",
				guid.ToString(),
				request.Method,
				request.RequestUri,
				request.Headers,
				request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
				);
		}

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

		if (_logger?.IsEnabled(LogLevel.Debug) == true)
		{
			_logger.LogDebug("{Guid}:{ResponseStatusCode}:{Body}",
				guid.ToString(),
				response.StatusCode,
				request.Content is null ? null : await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
		}

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
