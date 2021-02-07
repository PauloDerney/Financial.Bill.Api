using System;

namespace Financial.Bill.Domain.ValueObjects.v1
{
    public class Versioning
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public void SetModifiedVersion(string user)
        {
            ModifiedBy = user;
            ModifiedDate = DateTime.Now;
        }

        public void SetCreatedVersion(string user)
        {
            CreatedBy = user;
            CreatedDate = DateTime.Now;
        }
    }
}