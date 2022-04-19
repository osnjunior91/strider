using System;

namespace Strider.Lib.Strider.Lib.Infrastructure.Data.Models
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeleteAt { get; private set; }
        public bool IsDelete { get; private set; }

        public void DeleteEntity() 
        {
            IsDelete = true;
            DeleteAt = DateTime.Now;
        }
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
