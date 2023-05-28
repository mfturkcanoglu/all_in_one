using Newtonsoft.Json;
using System.Net;

namespace ApplicationCore.Dto.Response;

public class ResponseDto<T>
    where T : class
{
    public ResponseDto()
    {
    }

    public ResponseDto(T data)
    {
        Data = data;
    }

    [JsonProperty(propertyName: "status")]
    public int Status { get; set; } = ((int)HttpStatusCode.OK);

    [JsonProperty(propertyName: "status")]
    public bool Success { get; set; } = true;

    [JsonProperty(propertyName: "message", NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    [JsonProperty(propertyName: "data", NullValueHandling = NullValueHandling.Ignore)]
    public T Data { get; set; }
}