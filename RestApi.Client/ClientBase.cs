using Newtonsoft.Json;
using System.Text;

namespace RestApi.Client;

public abstract class ClientBase : IDisposable
{
    private readonly IApiConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private bool _disposed;

    public IApiConfiguration Configuration { get => _configuration; }

    protected HttpClient Client { get => _httpClient; }

    public ClientBase(IApiConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _httpClient.Timeout = TimeSpan.FromSeconds(configuration.Timeout);
        _httpClient.BaseAddress = new Uri(configuration.Url);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to 
    /// release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) { Client.Dispose(); }
        }
        _disposed = true;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources 
    /// related to the context.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected async Task<T> GetAsync<T>(string path)
    {
        var response = await Client.GetAsync(path);
        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(content, settings);
        }
        else
        {
            throw new Exception(content);
        }
    }

    protected async Task<int> AddAsync(string path, object model)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };
        var json = JsonConvert.SerializeObject(model, settings);
        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(path, jsonContent);
        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return Convert.ToInt32(content);
        }
        else
        {
            throw new Exception(content);
        }
    }

    protected async Task<int> UpdateAsync(string path, object model)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };
        var json = JsonConvert.SerializeObject(model, settings);
        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await Client.PutAsync(path, jsonContent);
        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return Convert.ToInt32(content);
        }
        else
        {
            throw new Exception(content);
        }
    }

    protected async Task DeleteAsync(string path)
    {
        await Client.DeleteAsync(path);
    }
}
