﻿using System;

namespace PS.Models.Entities
{
    public class BaseEntity
    {

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
