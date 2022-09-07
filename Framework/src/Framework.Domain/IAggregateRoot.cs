using System.Collections.Generic;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        public IReadOnlyList<IDomainEvent> GetChanges();
        void ClearChanges();
    }
}