using System.Net;
using System.Text.Json;
using BackEvalD2P2.Entity;
using BackEvalD2P2.Services.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace BackEvalD2P2.API;

public class EventFunction
{
    private readonly IEventService _eventService;
    private HttpClient _httpClient;
    
    public EventFunction(IEventService eventService, HttpClient httpClient)
    {
        _eventService = eventService;
        _httpClient = httpClient;
    }
    
    [Function("AddEvent")]
    public async Task<HttpResponseData> AddEvent([HttpTrigger(AuthorizationLevel.Function, "post", Route = "event")] HttpRequestData req, FunctionContext context)
    {
        var logger = context.GetLogger("EventFunction");
        logger.LogInformation("C# HTTP trigger function processed a request.");
        
        var content = await new StreamReader(req.Body).ReadToEndAsync();
        var even = JsonSerializer.Deserialize<Event>(content);
        
        await _eventService.AddEventAsync(even);
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        
        return response;
    }
    
    [Function("GetAllEvents")]
    public async Task<HttpResponseData> GetAllEvents([HttpTrigger(AuthorizationLevel.Function, "get", Route = "event")] HttpRequestData req, FunctionContext context)
    {
        var logger = context.GetLogger("EventFunction");
        logger.LogInformation("C# HTTP trigger function processed a request.");
        
        var events = await _eventService.GetAllEventsAsync();
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        
        await response.WriteStringAsync(JsonSerializer.Serialize(events));
        
        return response;
    }
}