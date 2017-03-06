using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using LeadifyTest.Data;
using Moq;
using LeadifyTest.Entities;

namespace LeadifyTest.Services.Tests
{
    [TestClass()]
    public class ContactServiceTests
    {
        private Mock<IContactRepository> _mockRepository;
        private IContactService _service;
        private List<Contact> contactList;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IContactRepository>();

            contactList = new List<Contact>() {
                                    new Contact() {
                                        ContactId = Guid.NewGuid(),
                                        Firstname = "Test1"
                                    },
                                    new Contact() {
                                        ContactId =  Guid.NewGuid(),
                                        Firstname = "Test2"
                                    },
                                    new Contact() {
                                        ContactId =  Guid.NewGuid(),
                                        Firstname = "Test3"
                                    }
                                };
        }

        [TestMethod()]
        public void ContactServiceTest()
        {
            _service = new ContactService(_mockRepository.Object);
            Assert.IsNotNull(_service);
            Assert.IsInstanceOfType(_service, typeof(IContactService));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var contact = contactList.First();
            _mockRepository.Setup(x => x.GetById(contact.ContactId)).Returns(contactList.Where(x => x.ContactId == contact.ContactId).FirstOrDefault());
            _service = new ContactService(_mockRepository.Object);
            var result = _service.GetById(contact.ContactId) as Contact;
            Assert.AreEqual(contact.ContactId, result.ContactId);
        }

        [TestMethod()]
        public void GetAllContactsTest()
        {
            _mockRepository.Setup(x => x.GetAllContacts()).Returns(contactList);
            _service = new ContactService(_mockRepository.Object);
            //Act
            List<Contact> results = _service.GetAllContacts() as List<Contact>;
            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var contact = contactList.First();
            contact.Firstname = "FRED";
            _mockRepository.Setup(x => x.Update(It.IsAny<Contact>())).Callback(new Action<Contact>(x =>
                {
                    var i = contactList.FindIndex(q => q.ContactId.Equals(contact.ContactId));
                    contactList[i] = x;
                }));
            _service = new ContactService(_mockRepository.Object);
            _service.Update(contact);

            var updated = contactList.Where(x => x.ContactId == contact.ContactId).FirstOrDefault();
            Assert.AreEqual(contact.Firstname, updated.Firstname);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var contact = contactList.First();

            _mockRepository.Setup(m => m.Remove(contact)).Callback((Contact value) => contactList.Remove(value));
            _service = new ContactService(_mockRepository.Object);
            _service.Remove(contact);
            Assert.AreEqual(2, contactList.Count);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Guid Id = Guid.NewGuid();
            Contact contact = new Contact()
            {
                ContactId = Id,
                Firstname = "Jon",
                Lastname = "Doe",
                Email = "Jon@gmail.com",
                Cellphone = "0872114445",
            };

            _service = new ContactService(_mockRepository.Object);
            _mockRepository.Setup(m => m.Create(contact)).Callback((Contact e) =>
                    {
                        e.ContactId = Id;
                    });
            //Act
            _service.Create(contact);
            //Assert
            Assert.AreEqual(Id, contact.ContactId);
        }
    }
}