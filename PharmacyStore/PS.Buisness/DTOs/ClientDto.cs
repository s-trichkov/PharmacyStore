using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PS.Buisness.DTOs
{
    public class ClientDto : IValidateable
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && FirstName.Length < 50
                && !string.IsNullOrWhiteSpace(LastName) && LastName.Length < 50;
        }
    }
}
