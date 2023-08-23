using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class QuanLyKhoDbContext : DbContext
    {
        public QuanLyKhoDbContext()
            : base("name=QuanLyKhoDbContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Input> Inputs { get; set; }
        public virtual DbSet<InputInfo> InputInfoes { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }
        public virtual DbSet<OutputInfo> OutputInfoes { get; set; }
        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
