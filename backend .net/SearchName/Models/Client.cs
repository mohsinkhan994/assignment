using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchName.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Dob { get; set; }

        public ICollection<ClientAddress> clientObj { get; set; }
    }
}