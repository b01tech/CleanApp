namespace CleanApp.Domain.Entities;
public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}
