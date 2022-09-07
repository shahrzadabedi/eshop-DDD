using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        //TODO: add version property
        private List<IDomainEvent> _changes = new List<IDomainEvent>();
        protected void Causes(IDomainEvent @event)
        {
            this._changes.Add(@event);
        }
        public IReadOnlyList<IDomainEvent> GetChanges() => _changes.AsReadOnly();
        public void ClearChanges()
        {
            _changes.Clear();
        }
    }
}
