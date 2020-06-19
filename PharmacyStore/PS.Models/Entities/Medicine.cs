using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Models.Entities
{
    public class Medicine : BaseEntity
    {
        public int MedicineId { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string MedicineName { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int MedicineLot { get; set; }
        public DateTime ExpiryDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public float MedicinePrice { get; set; }
    }
}
