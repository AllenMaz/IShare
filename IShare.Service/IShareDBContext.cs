using IShare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShare.Service
{
    public class IShareDBContext:DbContext
    {
        public DbSet<Test> Test { get; set; }

        protected void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
