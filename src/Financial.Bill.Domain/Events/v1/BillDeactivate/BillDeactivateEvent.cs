using Financial.Framework.Domain.Entities;

namespace Financial.Bill.Domain.Events.v1.BillDeactivate
{
    public class BillDeactivateEvent : Event
    {
        public BillDeactivateEvent(object payload, string correlationId)
        {
            Payload = payload;
            SetCorrelationId(correlationId);
        }

        public object Payload { get; set; }
    }
}