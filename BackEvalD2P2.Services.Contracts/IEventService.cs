using BackEvalD2P2.Entity;

namespace BackEvalD2P2.Services.Contracts;

public interface IEventService
{
    Task AddEventAsync(Event even);
    
    Task<IEnumerable<Event>> GetAllEventsAsync();
}