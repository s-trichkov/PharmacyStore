using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PS.Models.Entities
{
    public class Brand : BaseEntity
    {
        public int BrandId { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string BrandName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string HQ { get; set; }
        public DateTime Founded { get; set; }
        public int Revenue { get; set; }
        public IList<Medicine> Medicines { get; set; }
    }
}
