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
		if (_options.IsReadOnly && !IsRead(request.Method))
		{
			throw new InvalidOperationException($"The client is read-only; {request.Method} {request.RequestUri?.AbsolutePath} would change the server.");
		}

		request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"apikey:{_options.ApiKey}")));

		var guid = Guid.NewGuid();
		await LogRequestAsync(guid, request, cancellationToken).ConfigureAwait(false);

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

		await LogResponseAsync(guid, request, response, cancellationToken).ConfigureAwait(false);
		return response;
	}

	private static bool IsRead(HttpMethod method)
		=> method == HttpMethod.Get || method == HttpMethod.Head || method == HttpMethod.Options;

	private async Task LogRequestAsync(Guid guid, HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (_logger?.IsEnabled(LogLevel.Debug) == true)
		{
			_logger.LogDebug("{Guid}:{RequestMethod}:{RequestUri}\nHeaders:{Headers}\nBody:{Body}",
				guid.ToString(),
				request.Method,
				request.RequestUri,
				request.Headers,
				request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
		}
	}

	private async Task LogResponseAsync(Guid guid, HttpRequestMessage request, HttpResponseMessage response, CancellationToken cancellationToken)
	{
		if (_logger?.IsEnabled(LogLevel.Debug) == true)
		{
			_logger.LogDebug("{Guid}:{ResponseStatusCode}:{Body}",
				guid.ToString(),
				response.StatusCode,
				request.Content is null ? null : await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
		}
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
