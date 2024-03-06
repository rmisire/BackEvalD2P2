using System.ComponentModel.DataAnnotations;

namespace BackEvalD2P2.Entity;

public class Event
{
    [Key] 
    public Guid IdEvent { get; set; } = Guid.NewGuid();
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public string Hour { get; set; }
    
    [Required]
    public string Location { get; set; }
}