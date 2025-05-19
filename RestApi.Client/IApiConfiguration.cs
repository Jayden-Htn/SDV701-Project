namespace RestApi.Client;

public interface IApiConfiguration
{
    int Timeout { get; set; }
    string Url { get; set; }
}