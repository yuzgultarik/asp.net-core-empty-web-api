using core_tarik_api_empty.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_tarik_api_empty.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /* <model ismi > veri tabanındaki kullanicilar ismi*/
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }


}

