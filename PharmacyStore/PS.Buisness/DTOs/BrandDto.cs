using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Buisness.DTOs
{
    public class BrandDto : IValidateable
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string HQ { get; set; }
        public DateTime Founded { get; set; }
        public int Revenue { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(BrandName) && BrandName.Length < 50;
        }
    }
}
