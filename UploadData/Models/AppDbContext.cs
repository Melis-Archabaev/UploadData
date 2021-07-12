using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadData.Models
{
    public class AppDbContext:DbContext
    {       
        public AppDbContext()
            : base("DbConnectionUpload")
        {
            if (!Database.Exists())
            {
                Database.Create();
            }
            if (Database.Exists())
                Database.BeginTransaction();

        }
        public DbSet<Text> Texts { get; set; }
    }
}
