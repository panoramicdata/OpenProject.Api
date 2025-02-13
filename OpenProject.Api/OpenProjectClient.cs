using Newtonsoft.Json.Linq;
using System.Text;

namespace OpenProject.Api;

/// <summary>
/// API client is mainly responsible for making the HTTP call to the API backend.
/// </summary>
public class OpenProjectClient : IDisposable
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="options">OpenProject Client options</param>
	public OpenProjectClient(OpenProjectClientOptions options)
		: this(new HttpClient(new AuthenticatedHttpClientHandler(options))
		{
			BaseAddress = new Uri(options.Uri, new Uri("/api/v3", UriKind.Relative))
		})
	{
		_shouldDisposeHttpClient = true;
	}

	public OpenProjectClient(HttpClient client)
	{
		_httpClient = client;
		_refitSettings = new RefitSettings
		{
			//ContentSerializer = new NewtonsoftJsonContentSerializer(
			//	new JsonSerializerSettings
			//	{
			//		// By default nulls should not be rendered out, this will allow the receiving API to apply any defaults.
			//		// Use [JsonProperty(NullValueHandling = NullValueHandling.Include)] to send
			//		// nulls for specific properties, e.g. disassociating port schedule ids from a port
			//		NullValueHandling = NullValueHandling.Ignore,
			//	#if DEBUG
			//		MissingMemberHandling = MissingMemberHandling.Error,
			//	#endif
			//		Converters = new List<JsonConverter> { new StringEnumConverter() }
			//	})
		};

		Projects = RefitFor(Projects!);
	}

	private T RefitFor<T>(T _)
		=> RestService.For<T>(_httpClient, _refitSettings);

	private readonly HttpClient _httpClient;
	private readonly RefitSettings _refitSettings;
	private readonly bool _shouldDisposeHttpClient;
	private bool _isDisposed;

	/// <inheritdoc />
	public IProjects Projects { get; }

	public async Task<JObject?> GetJObjectAsync(string subUrl, CancellationToken cancellationToken)
	{
		var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, subUrl);
		var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
		if (httpResponseMessage.IsSuccessStatusCode)
		{
			var json = await httpResponseMessage
				.Content
				.ReadAsStringAsync(cancellationToken);
			return json == null ? null : JsonConvert.DeserializeObject<JObject>(json);
		}

		throw await ApiException.Create(httpRequestMessage, HttpMethod.Get, httpResponseMessage, _refitSettings);
	}

	/// <summary>
	/// Performs a GET request to the specified URL.
	/// </summary>
	/// <param name="subUrl"></param>
	/// <param name="cancellationToken"></param>
	/// <exception cref="FormatException"></exception>
	public Task<List<JObject>> GetAllAsync(string subUrl, CancellationToken cancellationToken)
		=> GetAllInternalAsync(HttpMethod.Get, subUrl, null, cancellationToken);

	/// <summary>
	/// Performs a GET request to the specified URL.
	/// </summary>
	/// <param name="subUrl"></param>
	/// <param name="cancellationToken"></param>
	/// <exception cref="FormatException"></exception>
	public Task<List<JObject>> GetAllAsync(string subUrl, string body, CancellationToken cancellationToken)
		=> GetAllInternalAsync(HttpMethod.Post, subUrl, body, cancellationToken);

	/// <summary>
	/// Perform a query using HTTP POST and return all the results.
	/// </summary>
	/// <param name="subUrl"></param>
	/// <param name="body"></param>
	/// <param name="cancellationToken"></param>
	/// <exception cref="FormatException"></exception>
	private async Task<List<JObject>> GetAllInternalAsync(
		HttpMethod httpMethod,
		string subUrl,
		string? body,
		CancellationToken cancellationToken)
	{
		var list = new List<JObject>();
		while (true)
		{
			var httpRequestMessage = new HttpRequestMessage(httpMethod, subUrl);
			if (body is not null)
			{
				httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
			}
			var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				var json = await httpResponseMessage
					.Content
					.ReadAsStringAsync();
				var jObject = json == null ? null : JsonConvert.DeserializeObject<JObject>(json);

				list.AddRange(jObject?["items"]?.ToObject<List<JObject>>() ?? throw new FormatException("Cannot deserialize items."));

				var nextPageUrl = jObject?["pageDetails"]?["nextPageUrl"]?.ToString();

				// Do we have another page?
				if (string.IsNullOrWhiteSpace(nextPageUrl))
				{
					// No
					return list;
				}
				// Yes

				// Get the next page
				subUrl = nextPageUrl;
			}
			else
			{
				throw await ApiException.Create(httpRequestMessage, HttpMethod.Get, httpResponseMessage, _refitSettings);
			}
		}
	}

	/// <summary>
	/// Perform a query using HTTP POST and return all the results.
	/// </summary>
	/// <param name="subUrl"></param>
	/// <param name="cancellationToken"></param>
	/// <exception cref="FormatException"></exception>
	public async Task DeleteAsync(
		string subUrl,
		CancellationToken cancellationToken)
	{
		var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, subUrl);
		var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
		if (!httpResponseMessage.IsSuccessStatusCode)
		{
			throw await ApiException.Create(httpRequestMessage, HttpMethod.Get, httpResponseMessage, _refitSettings);
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing)
			{
				if (_shouldDisposeHttpClient)
				{
					_httpClient.Dispose();
				}
			}

			_isDisposed = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
