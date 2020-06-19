using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Buisness.DTOs
{
    public class PrescriptionDto : IValidateable
    {
        public int PrescriptionId { get; set; }
        public int ClientId { get; set; }
        public int MedicineId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
