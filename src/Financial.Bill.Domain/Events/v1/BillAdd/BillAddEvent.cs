using Financial.Framework.Domain.Entities;

namespace Financial.Bill.Domain.Events.v1.BillAdd
{
    public class BillAddEvent : Event
    {
        public BillAddEvent(object payload, string correlationId)
        {
            Payload = payload;
            SetCorrelationId(correlationId);
        }

        public object Payload { get; set; }
    }
}