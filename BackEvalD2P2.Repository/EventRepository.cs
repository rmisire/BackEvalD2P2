using BackEvalD2P2.DAL;
using BackEvalD2P2.Entity;
using BackEvalD2P2.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BackEvalD2P2.Repository;

public class EventRepository : IEventRepository
{
    private readonly   BackEvalD2P2DbContext _context;
    
    public EventRepository(BackEvalD2P2DbContext context)
    {
        _context = context;
    }
    
    public async Task<Event> AddEventAsync(Event even)
    {
        await _context.Events.AddAsync(even);
        await _context.SaveChangesAsync();
        return even;
    }
    
    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }
    
    public async Task UpdateEventAsync(Event updatedEvent)
    {
        var existingEvent = await _context.Events.FindAsync(updatedEvent.IdEvent);
        if (existingEvent == null)
        {
            throw new Exception("Event introuvable.");
        }
        _context.Entry(existingEvent).CurrentValues.SetValues(updatedEvent);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteEventAsync(Guid idEvent)
    {
        var existingEvent = await _context.Events.FindAsync(idEvent);
        if (existingEvent == null)
        {
            throw new Exception("Event introuvable.");
        }
        _context.Events.Remove(existingEvent);
        await _context.SaveChangesAsync();
    }
}