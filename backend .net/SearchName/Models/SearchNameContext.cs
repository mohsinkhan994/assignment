using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchName.Models
{
    public class SearchNameContext : DbContext
    {
        public SearchNameContext() : base("name=SearchNameContext")
        {
        }

        public System.Data.Entity.DbSet<SearchName.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<SearchName.Models.ClientAddress> ClientAddresses { get; set; }
    }
}
