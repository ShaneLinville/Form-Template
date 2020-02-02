using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Template.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }

        public string MarriedStatus { get; set; }

        public string StreetAddress { get; set; }
        public string AptSuite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }


    }
}
