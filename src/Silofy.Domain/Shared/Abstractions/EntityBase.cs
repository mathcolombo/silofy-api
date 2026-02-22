namespace Silofy.Domain.Shared.Abstractions;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    
    public void SetUpdateAt() => UpdatedAt = DateTime.Now;
}