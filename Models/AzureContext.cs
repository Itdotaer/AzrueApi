using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AzureContext:DbContext
    {
        public AzureContext()
            : base("name=AzureContext")
        {
        }

        //public AzureContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{
        //}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DetailInfo> DetailInfos { get; set; }

        public System.Data.Entity.DbSet<Models.Blob> Blobs { get; set; }
    }
}
