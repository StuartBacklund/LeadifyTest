namespace LeadifyTest.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;

    public partial class LeadifyTestDbContext : DbContext
    {
        static LeadifyTestDbContext()
        {
            Database.SetInitializer<LeadifyTestDbContext>(null);
        }

        public LeadifyTestDbContext()
            : base("name=LeadifyTestConnection")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactMapping());
        }
    }
}