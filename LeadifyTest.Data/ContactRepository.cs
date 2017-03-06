using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LeadifyTest.Entities;

namespace LeadifyTest.Data
{
    public interface IContactRepository
    {
        Contact GetById(Guid id);

        List<Contact> GetAllContacts();

        void Update(Contact contact);

        void Remove(Contact contact);

        void Create(Contact contact);

        void SaveChanges();
    }

    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(DbContext context)
              : base(context)
        {
        }

        public Contact GetById(Guid id)
        {
            return FindBy(x => x.ContactId == id).FirstOrDefault();
        }

        public List<Contact> GetAllContacts()
        {
            return GetAll().ToList();
        }

        public void Update(Contact contact)
        {
            Edit(contact);
        }

        public void Remove(Contact contact)
        {
            Delete(contact);
        }

        public void Create(Contact contact)
        {
            Add(contact);
        }

        public void SaveChanges()
        {
            base.Save();
        }
    }
}