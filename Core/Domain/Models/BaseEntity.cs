namespace Domain.Models
{
    // Parent For all entities
    public abstract class BaseEntity<Tkey>
    {
       public Tkey Id { get; set; } //PK
    }
}
