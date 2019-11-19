using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchName.Models
{
    public class ClientAddress
    {
        public int id { get; set; }

        public int ClientId { get; set; }

        public string ClientAdd { get; set; }

        public Client client { get; set; }

    }
}