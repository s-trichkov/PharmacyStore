using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Buisness.DTOs
{
    public class MedicineDto : IValidateable
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int BrandId { get; set; }
        public BrandDto Brand { get; set; }
        public int MedicineLot { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal MedicinePrice { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(MedicineName) && MedicineName.Length < 100;
        }
    }
}
