using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadifyTest.Entities
{
    public class ContactMapping : EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            // Primary Key
            this.HasKey(t => t.ContactId);

            this.Property(t => t.Firstname)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.Lastname)
               .IsRequired()
               .HasMaxLength(50);
            this.Property(t => t.Cellphone)
              .IsRequired()
              .HasMaxLength(50);
            this.Property(t => t.Email)
              .IsRequired()
              .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("dbo.tblContact");
            this.Property(t => t.ContactId).HasColumnName("contactId");
            this.Property(t => t.Firstname).HasColumnName("firstname");
            this.Property(t => t.Lastname).HasColumnName("lastname");
            this.Property(t => t.Cellphone).HasColumnName("cellphone");
            this.Property(t => t.Email).HasColumnName("email");
        }
    }
}