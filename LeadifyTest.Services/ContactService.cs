using System;
using System.Collections.Generic;
using LeadifyTest.Data;
using LeadifyTest.Entities;

namespace LeadifyTest.Services
{
    public interface IContactService
    {
        Contact GetById(Guid Id);

        List<Contact> GetAllContacts();

        void Update(Contact contact);

        void Remove(Contact contact);

        void Create(Contact contact);
    }

    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact GetById(Guid Id)
        {
            return _contactRepository.GetById(Id);
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
            _contactRepository.SaveChanges();
        }

        public void Remove(Contact contact)
        {
            _contactRepository.Remove(contact);
            _contactRepository.SaveChanges();
        }

        public void Create(Contact contact)
        {
            _contactRepository.Create(contact);
            _contactRepository.SaveChanges();
        }
    }
}