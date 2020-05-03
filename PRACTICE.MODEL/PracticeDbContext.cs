
using System;

using Microsoft.EntityFrameworkCore;

namespace PRACTICE.MODEL
{
    public partial class PracticeDbContext : DbContext
    {
        public PracticeDbContext()
        {

        }
        public PracticeDbContext(DbContextOptions<PracticeDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GJEI4K0;Database=lateWork;Trusted_Connection=True;");
            }
        }


    }
}
