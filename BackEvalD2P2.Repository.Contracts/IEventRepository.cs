using BackEvalD2P2.Entity;

namespace BackEvalD2P2.Repository.Contracts;

public interface IEventRepository
{
    Task<Event>AddEventAsync(Event even);
    
    Task<IEnumerable<Event>> GetAllEventsAsync();
}