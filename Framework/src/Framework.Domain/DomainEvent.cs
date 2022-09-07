using System;

namespace Framework.Domain
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime PublishDateTime { get; private set; }
        public Guid EventId { get; private set; }
        protected DomainEvent()
        {
            this.PublishDateTime = DateTime.Now;
            this.EventId = Guid.NewGuid();
        }
    }
}