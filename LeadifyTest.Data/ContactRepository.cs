using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LeadifyTest.Data
{
    public interface IContactRepository
    {
        Contact GetById(Guid id);

        List<Contact> GetAllContacts();
    }

    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(DbContext context)
              : base(context)
        {
        }

        public Contact GetById(Guid id)
        {
            return FindBy(x => x.contactId == id).FirstOrDefault();
        }

        public List<Contact> GetAllContacts()
        {
            return GetAll().ToList();
        }
    }
}