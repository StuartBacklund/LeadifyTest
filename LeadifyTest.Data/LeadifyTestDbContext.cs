namespace LeadifyTest.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LeadifyTestDbContext : DbContext
    {
        public LeadifyTestDbContext()
            : base("name=LeadifyTestConnection")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}