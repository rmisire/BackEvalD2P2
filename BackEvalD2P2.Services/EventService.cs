using System.ComponentModel.Design;
using BackEvalD2P2.Entity;
using BackEvalD2P2.Repository.Contracts;
using BackEvalD2P2.Services.Contracts;

namespace BackEvalD2P2.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    
    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task AddEventAsync(Event even)
    {
        await _eventRepository.AddEventAsync(even);
    }
    
    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _eventRepository.GetAllEventsAsync();
    }
    
    public async Task UpdateEventAsync(Event updatedEvent)
    {
        await _eventRepository.UpdateEventAsync(updatedEvent);
    }
}