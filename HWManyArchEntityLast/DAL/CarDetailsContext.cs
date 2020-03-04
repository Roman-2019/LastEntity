using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    public class CarDetailsContext: DbContext
    {
        public CarDetailsContext() : base(@"Data Source=.\SQLSERVER;Initial Catalog=CarDetails;Integrated Security=True")
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Manufacturers> Manufacturers { get; set; }

    }
}
