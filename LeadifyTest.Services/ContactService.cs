using System;
using System.Collections.Generic;
using LeadifyTest.Data;

namespace LeadifyTest.Services
{
    public interface IContactService
    {
        Contact GetById(Guid Id);

        List<Contact> GetAllContacts();
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
    }
}