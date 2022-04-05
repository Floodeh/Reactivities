using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //Create a DB Set for our Activity entity
		//represents a table in our database, it will take the table name "Activities" we defined here.
        public DbSet<Activity> Activities { get; set; }


    }
}