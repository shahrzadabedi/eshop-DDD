using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    public interface IEvent
    {
        public DateTime PublishDateTime { get; }
        public Guid EventId { get; }
    }
}
