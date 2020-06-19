using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PS.Models.Entities
{
    public class Client : BaseEntity
    {
        public int ClientId { get; set; }
        [StringLength(50, ErrorMessage = "Типът трябва да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Типът трябва да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PrescriptionId { get; set; }

    }
}
