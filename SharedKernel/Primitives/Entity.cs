<<<<<<< HEAD
<<<<<<< HEAD:LMS.Domain/Primitives/Entity.cs
﻿
namespace LMS.Domain.Primitives
=======
﻿namespace SharedKernel.Primitives
>>>>>>> 4fece4006fdd198d575e376a602d69f8a6250f74:SharedKernel/Primitives/Entity.cs
=======
﻿namespace LeaveManagement.SharedKernel.Primitives
>>>>>>> cb790b9f44ac59bd67456e2c1f2c9ba195f66d26
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; protected set; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity() { }

        public bool Equals(Entity? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }

        public static bool operator ==(Entity? left, Entity? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity? left, Entity? right)
        {
            return !(left == right);
        }
    }
}
