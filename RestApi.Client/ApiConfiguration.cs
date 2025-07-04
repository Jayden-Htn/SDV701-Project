﻿namespace RestApi.Client;

public class ApiConfiguration : IApiConfiguration
{
    /// <summary>
    /// The url of the REST service
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The timeout in seconds for a http request
    /// </summary>
    public int Timeout { get; set; }

    public ApiConfiguration()
    {
        Timeout = 60;
    }
}
