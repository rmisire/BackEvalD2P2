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
}